using Domain.Abstractions;
using Domain.ViewModels;
using MediatR;

namespace Application.Handeler.CQRS.Skills.Queries
{
    public class GetSkillsQueryHandler : IRequestHandler<GetSkillsQuery, List<SkillsViewModel>>
    {
        private readonly ISkillsRepository _skillsRepository;
        public GetSkillsQueryHandler(ISkillsRepository skillsRepository)
        {
            _skillsRepository = skillsRepository;
        }
        public async Task<List<SkillsViewModel>> Handle(GetSkillsQuery request, CancellationToken cancellationToken)
        {
            return await _skillsRepository.GetSkillsAsync();
        }
    }
}
