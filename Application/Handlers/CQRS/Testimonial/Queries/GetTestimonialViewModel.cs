﻿namespace Application.Handeler.CQRS.Testimonial.Queries
{
    public class GetTestimonialViewModel
    {
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string PositionTitle { get; set; }
        public string ClientOpinion { get; set; }
        public int Stars { get; set; }
    }
}
