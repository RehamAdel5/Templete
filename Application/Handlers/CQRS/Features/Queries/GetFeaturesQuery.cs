using Domain.ViewModels;
using MediatR;

namespace Application.Handeler.CQRS.Features.Queries
{
    public class GetFeaturesQuery : IRequest<List<PricingViewModel>>
    {
    }
}
