using AdminPanelWithApi.Helpers.Image;
using Application.GenericCrudDto.Partner;
using AutoMapper;
using Domain.Entities;
using External.Infrastructure.Persistence.Data;
using Microsoft.AspNetCore.Mvc;
namespace AdminPanelWithApi.Controllers.Api
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [ApiExplorerSettings(GroupName = "PartnerCrud")]
    public class PartnerController : CrudControllerBase<Partner, PartnerDto, PartnerResponseDto>
    {
        public PartnerController(ApplicationDbContext dbContext,
            IMapper mapper, IWebHostEnvironment webHostEnvironment,
            IImageHelper imageHelper) : base(dbContext, mapper, webHostEnvironment, imageHelper)
        {
        }

    }
}
