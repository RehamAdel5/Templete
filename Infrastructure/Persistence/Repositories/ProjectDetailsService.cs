using Domain.Abstractions;
using Domain.Entities;
using Domain.ViewModels;
using External.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace External.Infrastructure.Persistence.Repositories
{
    public class ProjectDetailsService :BaseRepository<ProjectDetailsViewModel> ,IProjectDetailsService
    {
        private readonly ApplicationDbContext _context;
        public ProjectDetailsService(ApplicationDbContext context):base(context)
        {
            _context = context; 
        }
        public async Task<(ProjectDetails, List<ProjectImage>)> GetProjectDetailsAndImagesAsync(int id)
        {
            var projectDetails = await _context.ProjectDetails.Include(pd => pd.Project)
                .ThenInclude(p => p.ProjectCategory)
                .Include(pd => pd.Testimonial)
                .FirstOrDefaultAsync(pd => pd.Id == id);
            if (projectDetails != null)
            {
                var projectImages = await _context.ProjectImages.Where(pi => pi.ProjectId == projectDetails.ProjectId).Select(pi => new ProjectImage
                {
                    Id = pi.Id,
                    ImagePath = pi.ImagePath
                })
            .ToListAsync();
                return (projectDetails, projectImages);
            }
            return (null, null);


        }
    }
}
