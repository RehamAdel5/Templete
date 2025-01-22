
using Domain.Entities;
using Infrastructure.Persistence.Data.Extensions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace External.Infrastructure.Persistence.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        private readonly IMemoryCache _cache;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,IMemoryCache cache)
             : base(options)
        {
            _cache = cache;
        }
      
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
        public DbSet<SiteContent> SiteContents { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Configuration> Configurations { get; set; }
     
        public DbSet<Project> Projects { get; set; }
        public DbSet<AboutUs> AboutUs { get; set; }
        public DbSet<ProjectDetails> ProjectDetails { get; set; }
        public DbSet<ProjectCategory> ProjectCategories { get; set; }
        public DbSet<HorizontalSlider> HorizontalSliders { get; set; }
        public DbSet<AskedQuestion> AskedQuestions { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<Skill> Skills { get; set; }
        public DbSet<ProjectImage> ProjectImages { get; set; }
        public DbSet<Pricing> Pricings { get; set; }
        public DbSet<Newsletter> Newsletters { get; set; }
     
        public DbSet<Team> Teams { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<CompanyInformation> CompanyInformation { get; set; }
        public DbSet<WhyUs> WhyUs { get; set; }
        public DbSet<Features> Features { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplySoftDeleteQueryFilter();
            base.OnModelCreating(modelBuilder);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified || e.State == EntityState.Deleted))
            {
                const string cacheKeyAr = "MyData_ar";
                const string cacheKeyEn = "MyData_en";
                _cache.Remove(cacheKeyAr);
                _cache.Remove(cacheKeyEn);
                if (entry is not { State: EntityState.Deleted, Entity: HasIsActive isActive }) continue;
                entry.State = EntityState.Modified;
                isActive.IsActive = false;
            }

            return base.SaveChangesAsync(cancellationToken);
        }

    }
     
}
