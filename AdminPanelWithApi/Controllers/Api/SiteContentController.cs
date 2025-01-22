using AdminPanelWithApi.Helpers.Image;
using Application.GenericCrudDto.SiteContant;
using AutoMapper;
using Domain.Entities;
using External.Infrastructure.Persistence.Data;
using Microsoft.AspNetCore.Mvc;
namespace AdminPanelWithApi.Controllers.Api
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [ApiExplorerSettings(GroupName = "SiteContentCrud")]
    public class SiteContentController : CrudControllerBase<SiteContent, SiteContentDto, SiteContentResponseDto>
    {
        public SiteContentController(ApplicationDbContext dbContext,
            IMapper mapper, IWebHostEnvironment webHostEnvironment,
            IImageHelper imageHelper) : base(dbContext, mapper, webHostEnvironment, imageHelper)
        {
        }

    }
}
