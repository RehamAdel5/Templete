using External.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;

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
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            // Get the connection string
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            // Use the connection string
            optionsBuilder.UseSqlServer(connectionString);

            return new ApplicationDbContext(optionsBuilder.Options, _cache);
        }
    }
}
