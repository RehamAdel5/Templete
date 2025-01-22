using Domain.ViewModels;
using MediatR;

namespace Application.Handeler.CQRS.ContactUs.Queries
{
    public class GetContactUsQuery : IRequest<ContactUsViewModel>
    {
    }
}
