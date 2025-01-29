using Domain.ViewModels;
using MediatR;

namespace Application.Handeler.Queries.ContactUs.Queries
{
    public class GetContactUsQuery : IRequest<ContactUsViewModel>
    {
    }
}
