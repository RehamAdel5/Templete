using AutoMapper;
using Domain.Abstractions;
using Domain.ViewModels;
using External.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace External.Infrastructure.Persistence.Repositories
{

    public class ServicesRepository : BaseRepository<ServicesViewModel>, IServicesRepository
    {
    
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ServicesRepository(ApplicationDbContext context,IMapper mapper):base(context)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<ServicesViewModel>> GetServicesAsync()
        {
         var services=   await _context.Services.ToListAsync();
            return _mapper.Map<List<ServicesViewModel>>(services);

        }
    }
}

