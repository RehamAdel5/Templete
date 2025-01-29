using Domain.ViewModels;
using MediatR;

namespace Application.Handeler.Queries.Team.Queries
{
    public class GetTeamQuery : IRequest<List<TeamViewModel>>
    {
    }
}
