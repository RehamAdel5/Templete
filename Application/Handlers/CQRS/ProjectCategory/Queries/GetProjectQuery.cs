using Domain.ViewModels;
using MediatR;

namespace Application.Handeler.CQRS.ProjectCategory.Queries
{
    public class GetProjectCategoryQuery : IRequest<List<ProjectCategoryViewModel>>
    {
    }
}
