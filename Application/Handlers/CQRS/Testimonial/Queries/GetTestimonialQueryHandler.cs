using Domain.Abstractions;
using Domain.ViewModels;
using MediatR;

namespace Application.Handeler.CQRS.Testimonial.Queries
{
    public class GetTestimonialQueryHandler : IRequestHandler<GetTestimonialQuery, List<TestimonialViewModel>>
    {
        private readonly ITestimonialRepository _testimonialRepository;
        public GetTestimonialQueryHandler(ITestimonialRepository testimonialRepository)
        {
            _testimonialRepository = testimonialRepository;
        }
        public async Task<List<TestimonialViewModel>> Handle(GetTestimonialQuery request, CancellationToken cancellationToken)
        {
            return await _testimonialRepository.GetTestimonialAsync();
        }
    }
}
