using AdminPanelWithApi.Helpers.Image;
using AutoMapper;
using Dapper;
using External.Infrastructure.Persistence.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AdminPanelWithApi.Controllers.Api
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CrudControllerBase<T, TDto, ResDto> : ControllerBase where T : class where TDto : class where ResDto : class
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IImageHelper _imageHelper;
        public CrudControllerBase(
            ApplicationDbContext dbContext,
            IMapper mapper,
            IWebHostEnvironment webHostEnvironment, 
            IImageHelper imageHelper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment; 
            _imageHelper = imageHelper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //string? lang = HttpContext.Request.Headers["lang"];
            //var entities = await _dbContext.Set<T>().ToListAsync();
            //List<ResDto> dtos = _mapper.Map<List<ResDto>>(entities, opt => opt.Items["Lang"] = lang ?? "en");
            //return Ok(dtos);
            string lang = HttpContext.Request.Headers["lang"];
            using (var connection = _dbContext.Database.GetDbConnection())
            {
                var entities = await connection.QueryAsync<T>($"SELECT * FROM [{typeof(T).Name}s]");
                List<ResDto> dtos = _mapper.Map<List<ResDto>>(entities, opt => opt.Items["Lang"] = lang ?? "en");
                return Ok(dtos);
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            //T? entity = await _dbContext.Set<T>().FindAsync(id);

            //if (entity == null)
            //{
            //    return NotFound();
            //}
            //string? lang = HttpContext.Request.Headers["lang"];

            //ResDto dto = _mapper.Map<ResDto>(entity, opt => opt.Items["Lang"] = lang ?? "en");
            //return Ok(dto);
            string lang = HttpContext.Request.Headers["lang"];
            using (var connection = _dbContext.Database.GetDbConnection())
            {
                T entity = await connection.QueryFirstOrDefaultAsync<T>($"SELECT * FROM [{typeof(T).Name}s] WHERE [Id] = @Id", new { Id = id });

                if (entity == null)
                {
                    return NotFound();
                }

                ResDto dto = _mapper.Map<ResDto>(entity, opt => opt.Items["Lang"] = lang ?? "en");
                return Ok(dto);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] TDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            dto = await HasPropertyOfIformFile(dto);
            T entity = _mapper.Map<T>(dto);
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();
            string? lang = HttpContext.Request.Headers["lang"];
            ResDto updatedDto = _mapper.Map<ResDto>(entity, opt => opt.Items["Lang"] = lang ?? "en");           
            return Ok(updatedDto);
        }

        [HttpPost("update/{id}")]
        public async Task<IActionResult> Update(Guid id, [FromForm] TDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            T? existingEntity = await _dbContext.Set<T>().FindAsync(id);

            if (existingEntity == null)
            {
                return NotFound();
            }

            dto = await HasPropertyOfIformFile(dto);
            T updatedEntity = _mapper.Map(dto, existingEntity);
            _dbContext.Entry(existingEntity).CurrentValues.SetValues(updatedEntity);
            await _dbContext.SaveChangesAsync();
            string? lang = HttpContext.Request.Headers["lang"];
            ResDto updatedDto = _mapper.Map<ResDto>(updatedEntity, opt => opt.Items["Lang"] = lang ?? "en");            
            return Ok(updatedDto);
        }

        [HttpPost("UpdateShow/{id}")]
        public async Task<IActionResult> UpdateShow(Guid id)
        {
            T? entity = await _dbContext.Set<T>().FindAsync(id);

            if (entity == null)
            {
                return NotFound();
            }
            
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();            
            return NoContent();
        }

        // Other CRUD actions...

        
        private async Task<TDto> HasPropertyOfIformFile(TDto obj)
        {
            Type type = typeof(IFormFile);

            PropertyInfo[] properties = obj.GetType().GetProperties();

            foreach (PropertyInfo property in properties)
            {
                if (property.PropertyType == type)
                {
                    var file = (IFormFile?)property.GetValue(obj, null);
                    if (file is not null)
                    {
                        string fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
                        FormFile newFile = new FormFile(file.OpenReadStream(), 0, file.Length, string.Empty, fileName);
                        property.SetValue(obj, newFile);
                        string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
                        await _imageHelper.ProcessImageUpload(newFile, uploadsFolder);
                    }

                }
            }
            return obj;
        }
    }
}
