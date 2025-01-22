using Domain.ViewModels;

namespace Domain.Abstractions
{
    public interface IHorizontalSliderRepository:IAsyncRepository<HorizontalSliderViewModel>
    {
        Task<List<HorizontalSliderViewModel>> GetHorizontalSliderAsync();
    }
}
