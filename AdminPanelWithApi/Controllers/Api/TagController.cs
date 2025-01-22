using AdminPanelWithApi.Helpers.Image;
using Application.GenericCrudDto.Tag;
using AutoMapper;
using Domain.Entities;
using External.Infrastructure.Persistence.Data;
using Microsoft.AspNetCore.Mvc;
namespace AdminPanelWithApi.Controllers.Api
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [ApiExplorerSettings(GroupName = "TagCrud")]
    public class TagController : CrudControllerBase<Tag, TagDto, TagResponseDto>
    {
        public TagController(ApplicationDbContext dbContext,
            IMapper mapper, IWebHostEnvironment webHostEnvironment,
            IImageHelper imageHelper) : base(dbContext, mapper, webHostEnvironment, imageHelper)
        {
        }

    }
}
