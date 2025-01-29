using Domain.ViewModels;
using MediatR;

namespace Application.Handeler.Queries.Features.Queries
{
    public class GetFeaturesQuery : IRequest<List<PricingViewModel>>
    {
    }
}
