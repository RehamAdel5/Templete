using Microsoft.AspNetCore.Http;

namespace Application.GenericCrudDto.Partner
{
    public class PartnerDto
    {
        public required string TitleAr { get; set; }
        public required string TitleEn { get; set; }
        public IFormFile? Image { get; set; }
    }
}
