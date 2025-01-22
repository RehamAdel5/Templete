using Domain.Enums;

namespace Domain.Entities
{
    public class SiteContent : Entity
    {
        public  string? TitleAr { get; set; }
        public  string? TitleEn { get; set; }
        public  string? SubTitleAr { get; set; }
        public  string? SubTitleEn  { get; set; }
        public  string? DescAr { get; set; }
        public  string? DescEn { get; set; }
        public  string? Link  { get; set; }
        public Page Page  { get; set; }
        public  string? Position   { get; set; }
        public  string? Image   { get; set; }
        public  string? Video1   { get; set; }
        public  string? Video2   { get; set; }
    }
}
