using Domain.ViewModels;

namespace Domain.Abstractions
{
    public interface IProjectCategoryService : IAsyncRepository<ProjectCategoryViewModel>
    {
        Task<List<ProjectCategoryViewModel>> GetProjectCategoriesAsync();
    }
}
