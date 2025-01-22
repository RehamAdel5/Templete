using Domain.ViewModels;
using MediatR;

namespace Application.Handeler.CQRS.Team.Queries
{
    public class GetTeamQuery : IRequest<List<TeamViewModel>>
    {
    }
}
