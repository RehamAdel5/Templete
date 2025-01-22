using AutoMapper;
using Domain.Abstractions;
using Domain.ViewModels;
using External.Infrastructure.Persistence.Data;
using External.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace External.Infrastructure.Persistence.Repositories
{
}
public class TestimonialRepository : BaseRepository<TestimonialViewModel>,ITestimonialRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public TestimonialRepository(ApplicationDbContext context,IMapper mapper):base(context)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<List<TestimonialViewModel>> GetTestimonialAsync()
    {
      var testimonials = await _context.Testimonials.ToListAsync();
        return _mapper.Map<List<TestimonialViewModel>>(testimonials);

    }
}
