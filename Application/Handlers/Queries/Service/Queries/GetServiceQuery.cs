using Domain.ViewModels;
using MediatR;

namespace Application.Handeler.Queries.Service.Queries
{
    public class GetServiceQuery : IRequest<List<ServicesViewModel>>
    {
    }
}
