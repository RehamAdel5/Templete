using Domain.Abstractions;
using Domain.ViewModels;
using MediatR;

namespace Application.Handeler.CQRS.AboutUs.Queries
{
    public class GetAboutQueryHandler : IRequestHandler<GetAboutQuery, List<AboutViewModel>>
    {
        private readonly IAboutRepository _aboutRepository; 
        public GetAboutQueryHandler(IAboutRepository aboutRepository)
        {
            _aboutRepository = aboutRepository;
        }
        public async Task<List<AboutViewModel>> Handle(GetAboutQuery request, CancellationToken cancellationToken)
        {
            return await _aboutRepository.GetAboutAsync();
        }
    }
}
