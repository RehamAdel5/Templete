namespace Domain.Entities
{
    public class Partner : Entity
    {

        public required string TitleAr { get; set; }
        public required string TitleEn { get; set; }
        public   string? Image { get; set; }
    }
}
