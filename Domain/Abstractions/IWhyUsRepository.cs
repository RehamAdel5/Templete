
using Domain.ViewModels;

namespace Domain.Abstractions
{
    public interface IWhyUsRepository:IAsyncRepository<WhyUsViewModel>
    {
        Task<List<WhyUsViewModel>> GetWhyUsAsync();
    }
}
