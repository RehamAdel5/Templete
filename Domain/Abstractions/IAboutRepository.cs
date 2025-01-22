
using Domain.ViewModels;

namespace Domain.Abstractions
{
    public interface IAboutRepository : IAsyncRepository<AboutViewModel>
    {
        Task<List<AboutViewModel>> GetAboutAsync();
    }
}
