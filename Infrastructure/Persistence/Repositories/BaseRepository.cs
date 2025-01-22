using Domain.Abstractions;
using External.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace External.Infrastructure.Persistence.Repositories
{
    public class BaseRepository<T> : IAsyncRepository<T> where T : class
    {

        private readonly ApplicationDbContext _context;
        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }
    }
}
