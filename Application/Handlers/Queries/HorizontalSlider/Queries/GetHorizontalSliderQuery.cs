using Domain.ViewModels;
using MediatR;

namespace Application.Handeler.Queries.HorizontalSlider.Queries
{
    public class GetHorizontalSliderQuery : IRequest<List<HorizontalSliderViewModel>>
    {
    }
}
