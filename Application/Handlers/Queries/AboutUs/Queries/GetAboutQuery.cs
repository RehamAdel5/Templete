using Domain.ViewModels;
using MediatR;

namespace Application.Handeler.Queries.AboutUs.Queries
{
    public class GetAboutQuery : IRequest<List<AboutViewModel>>
    {
    }
}
