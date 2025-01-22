using Domain.ViewModels;
using MediatR;

namespace Application.Handeler.CQRS.AboutUs.Queries
{
    public class GetAboutQuery : IRequest<List<AboutViewModel>>
    {
    }
}
