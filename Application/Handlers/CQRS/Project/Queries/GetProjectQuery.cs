using Domain.ViewModels;
using MediatR;

namespace Application.Handeler.CQRS.Project.Queries
{
    public class GetProjectsQuery : IRequest<List<ProjectViewModel>>
    {
    }
}
