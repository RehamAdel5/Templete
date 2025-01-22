using Domain.ViewModels;

namespace Domain.Abstractions
{
    public interface IProjectsRepository: IAsyncRepository<ProjectViewModel>
    {
        Task<List<ProjectViewModel>> GetProjectsAsync();
    }
}
