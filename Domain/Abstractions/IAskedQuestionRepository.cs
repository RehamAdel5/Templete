using Domain.ViewModels;

namespace Domain.Abstractions
{
    public interface IAskedQuestionRepository:IAsyncRepository<AskedQuestionsViewModel>
    {
        Task<List<AskedQuestionsViewModel>> GetAskedQuestionAsync();
    }
}
