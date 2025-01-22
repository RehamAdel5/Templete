using Domain.ViewModels;
using MediatR;

namespace Application.Handeler.CQRS.Skills.Queries
{
    public class GetSkillsQuery : IRequest<List<SkillsViewModel>>
    {
    }
}
