using Domain.Abstractions;
using Domain.ViewModels;
using MediatR;

namespace Application.Handeler.Queries.ProjectCategory.Queries
{
    public class GetProjectCategoryQueryHandler : IRequestHandler<GetProjectCategoryQuery, List<ProjectCategoryViewModel>>
    {
        private readonly IProjectCategoryService _projectCategoryRepository; 
        public GetProjectCategoryQueryHandler(IProjectCategoryService projectCategoryRepository)
        {
            _projectCategoryRepository = projectCategoryRepository;
        }
        public async Task<List<ProjectCategoryViewModel>> Handle(GetProjectCategoryQuery request, CancellationToken cancellationToken)
        {
            return await _projectCategoryRepository.GetProjectCategoriesAsync();
        }
    }
}
