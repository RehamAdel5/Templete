using AdminPanelWithApi.Helpers.Image;
using Application.GenericCrudDto.SocialMedia;
using AutoMapper;
using Domain.Entities;
using External.Infrastructure.Persistence.Data;
using Microsoft.AspNetCore.Mvc;
namespace AdminPanelWithApi.Controllers.Api
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [ApiExplorerSettings(GroupName = "SocialMediaCrud")]
    public class SocialMediaController : CrudControllerBase<SocialMedia, SocialMediaDto, SocialMediaResponseDto>
    {
        public SocialMediaController(ApplicationDbContext dbContext,
            IMapper mapper, IWebHostEnvironment webHostEnvironment,
            IImageHelper imageHelper) : base(dbContext, mapper, webHostEnvironment, imageHelper)
        {
        }

    }
}
