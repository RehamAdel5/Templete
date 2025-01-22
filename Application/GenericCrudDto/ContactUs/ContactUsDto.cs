namespace Application.GenericCrudDto.ContactUs
{
    public class ContactUsDto
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
        public required string Message { get; set; }
        public required string Subject { get; set; }
    }
}
