namespace Application.GenericCrudDto.Tag
{
    public class TagResponseDto
    { 
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Property { get; set; }
        public string? Content { get; set; }
    }
}
