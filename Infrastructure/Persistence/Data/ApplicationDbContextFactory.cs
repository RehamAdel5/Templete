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
            optionsBuilder.UseSqlServer("Server=DESKTOP-1RHRIEA;Database=TemplateDb;User Id=myNewUser;password=12345;TrustServerCertificate=True;MultipleActiveResultSets=true;");

            return new ApplicationDbContext(optionsBuilder.Options,_cache);
        }
    }
}
