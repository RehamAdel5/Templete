using AdminPanelWithApi.Helpers.Image;
using Application.GenericCrudDto.Service;
using AutoMapper;
using Domain.Entities;
using External.Infrastructure.Persistence.Data;
using Microsoft.AspNetCore.Mvc;

namespace AdminPanelWithApi.Controllers.Api
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [ApiExplorerSettings(GroupName = "ServiceCrud")]
    public class ServiceController : CrudControllerBase<Service, ServiceDto, ServiceResponseDto>
    {
        public ServiceController(
            ApplicationDbContext dbContext, 
            IMapper mapper, IWebHostEnvironment webHostEnvironment, 
            IImageHelper imageHelper) : base(dbContext, mapper, webHostEnvironment, imageHelper)
        {
        }        
    }
}
