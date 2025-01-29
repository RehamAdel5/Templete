using Domain.ViewModels;
using MediatR;

namespace Application.Handeler.Queries.Project.Queries
{
    public class GetProjectsQuery : IRequest<List<ProjectViewModel>>
    {
    }
}
