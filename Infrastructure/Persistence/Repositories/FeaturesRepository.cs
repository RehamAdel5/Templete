using AutoMapper;
using Domain.Abstractions;
using Domain.ViewModels;
using External.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace External.Infrastructure.Persistence.Repositories
{
    public class FeaturesRepository : BaseRepository<PricingViewModel>, IFeaturesRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public FeaturesRepository(ApplicationDbContext context,IMapper mapper):base (context)
        { 
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<PricingViewModel>> GetFeaturesAsync()
        {
            var features = await _context.Features.Include(f => f.Pricing).ToListAsync(); 
            return _mapper.Map<List<PricingViewModel>>(features);

        }
    }
}
