using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace GenericCrudDto.Dto
{
    public class SettingDto
    {
        public required string CondtionAr { get; set; }
        public required string CondtionEn { get; set; }
        public IFormFile? Image { get; set; }
    }
}
