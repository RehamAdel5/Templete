using Domain.ViewModels;
using MediatR;

namespace Application.Handeler.CQRS.Testimonial.Queries
{
    public class GetTestimonialQuery : IRequest<List<TestimonialViewModel>>
    {
    }
}
