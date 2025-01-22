namespace Application.GenericCrudDto.Service
{
    public class ServiceResponseDto
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? ShortDesc { get; set; }
        public string? LongDesc { get; set; }

        public string? Image { get; set; }
        public bool ShowHome { get; set; }
    }
}
