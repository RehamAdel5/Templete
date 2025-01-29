using Domain.Abstractions;
using Domain.ViewModels;
using MediatR;

namespace Application.Handeler.Queries.Project.Queries
{
    public class GetProjectQueryHandler : IRequestHandler<GetProjectsQuery, List<ProjectViewModel>>
    {
        private readonly IProjectsRepository _projectsRepository; 
        public GetProjectQueryHandler(IProjectsRepository projectsRepository)
        {
            _projectsRepository = projectsRepository;
        }
        public async Task<List<ProjectViewModel>> Handle(GetProjectsQuery request, CancellationToken cancellationToken)
        {
            return await _projectsRepository.GetProjectsAsync();
        }
    }
}
