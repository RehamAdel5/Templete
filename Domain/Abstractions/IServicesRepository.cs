using Domain.ViewModels;

namespace Domain.Abstractions
{
    public interface IServicesRepository: IAsyncRepository<ServicesViewModel>
    {
        Task<List<ServicesViewModel>> GetServicesAsync();
    }
}
