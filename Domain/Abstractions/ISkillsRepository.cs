using Domain.ViewModels;

namespace Domain.Abstractions
{
    public interface ISkillsRepository:IAsyncRepository<SkillsViewModel>
    {
        Task<List<SkillsViewModel>> GetSkillsAsync();
    }
}
