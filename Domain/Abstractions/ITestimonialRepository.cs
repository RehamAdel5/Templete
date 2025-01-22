
using Domain.ViewModels;

namespace Domain.Abstractions
{
    public interface ITestimonialRepository:IAsyncRepository<TestimonialViewModel>
    {
        Task<List<TestimonialViewModel>> GetTestimonialAsync();
    }
}
