using Domain.ViewModels;
using MediatR;

namespace Application.Handeler.CQRS.WhyUs.Queries
{
    public class GetWhyUsQuery : IRequest<List<WhyUsViewModel>>
    {
    }
}
