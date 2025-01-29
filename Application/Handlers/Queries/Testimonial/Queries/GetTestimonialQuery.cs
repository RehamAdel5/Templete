using Domain.ViewModels;
using MediatR;

namespace Application.Handeler.Queries.Testimonial.Queries
{
    public class GetTestimonialQuery : IRequest<List<TestimonialViewModel>>
    {
    }
}
