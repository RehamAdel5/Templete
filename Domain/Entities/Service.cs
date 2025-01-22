namespace Domain.Entities
{
    public class Service : Entity
    {
        public required string TitleAr { get; set; }
        public required string TitleEn { get; set; }
        public required string ShortDescAr { get; set; }
        public required string ShortDescEn { get; set; }
        public required string LongDescAr { get; set; }
        public required string LongDescEn { get; set; }
        public   string? Image  { get; set; }
        public required bool ShowHome { get; set; }
    }
}
