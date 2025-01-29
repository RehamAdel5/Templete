using Domain.ViewModels;
using MediatR;

namespace Application.Handeler.Queries.Skills.Queries
{
    public class GetSkillsQuery : IRequest<List<SkillsViewModel>>
    {
    }
}
