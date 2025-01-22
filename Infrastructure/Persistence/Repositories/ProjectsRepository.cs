using AutoMapper;
using Domain.Abstractions;
using Domain.ViewModels;
using External.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace External.Infrastructure.Persistence.Repositories
{

    public class ProjectsRepository : BaseRepository<ProjectViewModel>, IProjectsRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ProjectsRepository(ApplicationDbContext context, IMapper mapper):base(context) 
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<ProjectViewModel>> GetProjectsAsync()
        {
            var projects = await _context.Projects.Include(p => p.ProjectCategory).ToListAsync();
            return _mapper.Map<List<ProjectViewModel>>(projects);
        }
    }
}

