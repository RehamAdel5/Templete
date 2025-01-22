using AutoMapper;
using Domain.Abstractions;
using Domain.ViewModels;
using External.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace External.Infrastructure.Persistence.Repositories
{
    public class AboutRepository :  BaseRepository<AboutViewModel>, IAboutRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AboutRepository(ApplicationDbContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<AboutViewModel>> GetAboutAsync()
        {

            var aboutUs = await _context.AboutUs.ToListAsync();

            return _mapper.Map<List<AboutViewModel>>(aboutUs);
        }
    }
}