using AutoMapper;
using Domain.Abstractions;
using Domain.ViewModels;
using External.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace External.Infrastructure.Persistence.Repositories
{
    public class HorizontalSliderRepository : BaseRepository<HorizontalSliderViewModel>, IHorizontalSliderRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public HorizontalSliderRepository(ApplicationDbContext context, IMapper mapper):base(context)
        { _context = context;
            _mapper = mapper;
        }
        public async Task<List<HorizontalSliderViewModel>> GetHorizontalSliderAsync()
        {
            var horizontalSliders= await _context.HorizontalSliders.ToListAsync();
            return _mapper.Map<List<HorizontalSliderViewModel>>(horizontalSliders);

        }
    }
}
