using Domain.ViewModels;
using MediatR;

namespace Application.Handeler.CQRS.HorizontalSlider.Queries
{
    public class GetHorizontalSliderQuery : IRequest<List<HorizontalSliderViewModel>>
    {
    }
}
