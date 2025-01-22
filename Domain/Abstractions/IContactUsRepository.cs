using Domain.ViewModels;

namespace Domain.Abstractions
{
    public interface IContactUsRepository : IAsyncRepository<ContactUsViewModel>
    {
        Task<ContactUsViewModel> GetContactUsAsync();
    }
}
