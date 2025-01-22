using AdminPanelWithApi.Helpers.Image;
using Application.GenericCrudDto.ContactUs;
using AutoMapper;
using Domain.Entities;
using External.Infrastructure.Persistence.Data;
using Microsoft.AspNetCore.Mvc;
namespace AdminPanelWithApi.Controllers.Api
{
    [ApiExplorerSettings(GroupName = "ContactUsCrud")]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ContactUsController : CrudControllerBase<ContactUs, ContactUsDto, ContactUsResponseDto>
    {
        public ContactUsController(ApplicationDbContext dbContext,
            IMapper mapper, IWebHostEnvironment webHostEnvironment,
            IImageHelper imageHelper) : base(dbContext, mapper, webHostEnvironment, imageHelper)
        {
        }

    }
}
