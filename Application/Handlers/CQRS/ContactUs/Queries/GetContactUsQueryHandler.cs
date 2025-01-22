using Domain.Abstractions;
using Domain.ViewModels;
using MediatR;

namespace Application.Handeler.CQRS.ContactUs.Queries
{
    public class GetContactUsQueryHandler : IRequestHandler<GetContactUsQuery, ContactUsViewModel>
    {
        private readonly IContactUsRepository _contactUsRepository;
        public GetContactUsQueryHandler(IContactUsRepository contactUsRepository)
        {
            _contactUsRepository = contactUsRepository;
        }
        public async Task<ContactUsViewModel> Handle(GetContactUsQuery request, CancellationToken cancellationToken)
        {
            return await _contactUsRepository.GetContactUsAsync();
        }

    }
}
