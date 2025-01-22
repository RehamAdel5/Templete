using Domain.ViewModels;

namespace Domain.Abstractions
{
    public interface IFeaturesRepository:IAsyncRepository<PricingViewModel>
    {
        Task<List<PricingViewModel>> GetFeaturesAsync();
    }
}
