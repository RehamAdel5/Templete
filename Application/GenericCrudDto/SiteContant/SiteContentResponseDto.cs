using Domain.Enums;

namespace Application.GenericCrudDto.SiteContant
{
    public class SiteContentResponseDto
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? SubTitle { get; set; }
        public string? Desc { get; set; }
        public string? Link { get; set; }
        public Page Page { get; set; }
        public string? Position { get; set; }
        public string? Image { get; set; }
        public string? Video1 { get; set; }
        public string? Video2 { get; set; }
    }
}
