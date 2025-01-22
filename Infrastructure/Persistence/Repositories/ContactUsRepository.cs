using AutoMapper;
using Domain.Abstractions;
using Domain.ViewModels;
using External.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;
namespace External.Infrastructure.Persistence.Repositories
{

    public class ContactUsRepository : BaseRepository<ContactUsViewModel>, IContactUsRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ContactUsRepository(ApplicationDbContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ContactUsViewModel> GetContactUsAsync()
        {
            var contactUs = await _context.ContactUs.FirstOrDefaultAsync();
            return _mapper.Map<ContactUsViewModel>(contactUs);
        }
    }
}
