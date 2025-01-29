using Domain.ViewModels;
using MediatR;

namespace Application.Handeler.Queries.ProjectCategory.Queries
{
    public class GetProjectCategoryQuery : IRequest<List<ProjectCategoryViewModel>>
    {
    }
}
