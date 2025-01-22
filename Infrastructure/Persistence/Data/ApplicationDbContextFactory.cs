using External.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace Infrastructure.Persistence.Data
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        private readonly IMemoryCache _cache;

        public ApplicationDbContextFactory()
        {
        }

        public ApplicationDbContextFactory(IMemoryCache cache)
        {
            _cache = cache;
        }

        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=templeteDB;User ID=adminTemplete;Password=00000;MultipleActiveResultSets=true;TrustServerCertificate=True;");

            return new ApplicationDbContext(optionsBuilder.Options,_cache);
        }
    }
}
