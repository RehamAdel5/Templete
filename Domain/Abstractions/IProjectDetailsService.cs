using Domain.Entities;
using Domain.ViewModels;

namespace Domain.Abstractions
{
    public interface IProjectDetailsService:IAsyncRepository<ProjectDetailsViewModel>
    {
        Task<(ProjectDetails, List<ProjectImage>)> GetProjectDetailsAndImagesAsync(int id);

    }
}
