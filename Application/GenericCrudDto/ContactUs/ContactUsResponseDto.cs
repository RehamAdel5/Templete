﻿namespace Application.GenericCrudDto.ContactUs
{
    public class ContactUsResponseDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Message { get; set; }
        public string? Subject { get; set; }
    }
}
