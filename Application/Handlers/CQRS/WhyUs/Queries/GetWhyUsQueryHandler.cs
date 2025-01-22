using Domain.Abstractions;
using Domain.ViewModels;
using MediatR;

namespace Application.Handeler.CQRS.WhyUs.Queries
{
    public class GetWhyUsQueryHandler : IRequestHandler<GetWhyUsQuery, List<WhyUsViewModel>>
    {
        private readonly IWhyUsRepository _whyUsRepository; 
        public GetWhyUsQueryHandler(IWhyUsRepository whyUsRepository)
        {
            _whyUsRepository = whyUsRepository;
        }
        public async Task<List<WhyUsViewModel>> Handle(GetWhyUsQuery request, CancellationToken cancellationToken)
        {
            return await _whyUsRepository.GetWhyUsAsync();
        }
    }
}
