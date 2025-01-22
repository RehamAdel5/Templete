using AutoMapper;
using Domain.Abstractions;
using Domain.ViewModels;
using External.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace External.Infrastructure.Persistence.Repositories
{
    public class SkillsRepository : BaseRepository<SkillsViewModel>,ISkillsRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public SkillsRepository(ApplicationDbContext context,IMapper mapper):base(context)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<SkillsViewModel>> GetSkillsAsync()
        {
          var skills= await _context.Skills.ToListAsync();
            return _mapper.Map<List<SkillsViewModel>>(skills);

        }
    }
}
