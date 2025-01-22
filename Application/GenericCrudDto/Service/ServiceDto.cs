using Microsoft.AspNetCore.Http;

namespace Application.GenericCrudDto.Service
{
    public class ServiceDto
    {
        public required string TitleAr { get; set; }
        public required string TitleEn { get; set; }       
        public required string ShortDescAr { get; set; }
        public required string ShortDescEn { get; set; }
        public required string LongDescAr { get; set; }
        public required string LongDescEn { get; set; }
        public IFormFile? Image { get; set; }
        public required bool ShowHome { get; set; }
    }
}
