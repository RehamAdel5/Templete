using Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace Application.GenericCrudDto.SiteContant
{
    public class SiteContentDto
    {
        public required string TitleAr { get; set; }
        public required string TitleEn { get; set; }
        public required string SubTitleAr { get; set; }
        public required string SubTitleEn { get; set; }
        public required string DescAr { get; set; }
        public required string DescEn { get; set; }
        public required string Link { get; set; }
        public required Page Page { get; set; }
        public required string Position { get; set; }
        public IFormFile? Image { get; set; }
        public IFormFile? Video1 { get; set; }
        public IFormFile? Video2 { get; set; }
    }
}
