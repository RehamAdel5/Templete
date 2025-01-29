using Domain.Abstractions;
using Domain.ViewModels;
using MediatR;

namespace Application.Handeler.Queries.HorizontalSlider.Queries
{
    public class GetHorizontalSliderQueryHandler : IRequestHandler<GetHorizontalSliderQuery, List<HorizontalSliderViewModel>>
    {
        private readonly IHorizontalSliderRepository _horizontalSliderRepository; 
        public GetHorizontalSliderQueryHandler(IHorizontalSliderRepository horizontalSliderRepository)
        {
            _horizontalSliderRepository = horizontalSliderRepository;
        }
        public async Task<List<HorizontalSliderViewModel>> Handle(GetHorizontalSliderQuery request, CancellationToken cancellationToken)
        {
            return await _horizontalSliderRepository.GetHorizontalSliderAsync();
        }
    }
}
