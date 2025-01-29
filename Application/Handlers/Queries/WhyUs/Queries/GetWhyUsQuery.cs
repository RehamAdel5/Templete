using Domain.ViewModels;
using MediatR;

namespace Application.Handeler.Queries.WhyUs.Queries
{
    public class GetWhyUsQuery : IRequest<List<WhyUsViewModel>>
    {
    }
}
