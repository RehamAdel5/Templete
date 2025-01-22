using Domain.ViewModels;

namespace Domain.Abstractions
{
    public interface ITeamRepository:IAsyncRepository<TeamViewModel>
    {
        Task<List<TeamViewModel>> GetTeamAsync();
    }
}
