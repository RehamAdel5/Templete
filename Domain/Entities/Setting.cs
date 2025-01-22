using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Setting : Entity
    {
        [Required]
        public string CondtionAr { get; set; }
        [Required]
        public string CondtionEn { get; set; } 
       
        public string? Image { get; set; }
    }
}
