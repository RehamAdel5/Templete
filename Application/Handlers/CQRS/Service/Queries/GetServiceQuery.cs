using Domain.ViewModels;
using MediatR;

namespace Application.Handeler.CQRS.Service.Queries
{
    public class GetServiceQuery : IRequest<List<ServicesViewModel>>
    {
    }
}
