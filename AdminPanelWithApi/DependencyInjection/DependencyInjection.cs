using AdminPanelWithApi.Helpers.CompressImage;
using AdminPanelWithApi.Helpers.Image;
using AdminPanelWithApi.Services.EmailService;
using Application.Behaviors;
using Auth.Middlewares;
using Domain.Abstractions;
using Domain.Entities;
using Domain.Enums;
using Domain.Models;
using Domain.Seeds;
using Domain.ViewModels;
using External.Infrastructure.Persistence.Data;
using External.Infrastructure.Persistence.Repositories;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Text;
using Web.DependencyInjection;
namespace Auth.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            var applicationAssembly = typeof(Application.AssemblyReference).Assembly;
            services.AddMediatR(applicationAssembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.AddValidatorsFromAssembly(applicationAssembly);
            services.AddAutoMapper(applicationAssembly);






            services.Configure<JwtSetting>(configuration.GetSection("JwtSetting"));
            services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<CustomExceptionHandlerMiddleware>();
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, SwaggerConfigration>();
            services.AddTransient<IConfigureOptions<SwaggerUIOptions>, SwaggerUIConfiguration>();
            services.AddTransient<IEmailSender, EmailService>();
            services.AddTransient<IImageHelper, ImageHelper>();
            services.AddTransient<IServicesRepository, ServicesRepository>();
            services.AddTransient<IHorizontalSliderRepository, HorizontalSliderRepository>();
            services.AddTransient<IAboutRepository, AboutRepository>();
            services.AddTransient<IWhyUsRepository, WhyUsRepository>();
            services.AddTransient<ISkillsRepository, SkillsRepository>();
            services.AddTransient<IProjectsRepository, ProjectsRepository>();
            services.AddTransient<ITeamRepository, TeamRepository>();
            services.AddTransient<IFeaturesRepository, FeaturesRepository>();
            services.AddTransient<ITestimonialRepository, TestimonialRepository>();
            services.AddTransient<IAskedQuestionRepository, AskedQuestionRepository>();
            services.AddTransient<IContactUsRepository, ContactUsRepository>();
            services.AddTransient<IProjectCategoryService, ProjectCategoryService>();
            services.AddTransient<IProjectDetailsService, ProjectDetailsService>();
            services.AddTransient<IAsyncRepository<AboutViewModel>, BaseRepository<AboutViewModel>>();
            services.AddTransient<IAsyncRepository<AskedQuestionsViewModel>, BaseRepository<AskedQuestionsViewModel>>();
            services.AddTransient<IAsyncRepository<WhyUsViewModel>, BaseRepository<WhyUsViewModel>>();
            services.AddTransient<IAsyncRepository<ContactUsViewModel>, BaseRepository<ContactUsViewModel>>();
            services.AddTransient<IAsyncRepository<PricingViewModel>, BaseRepository<PricingViewModel>>();
            services.AddTransient<IAsyncRepository<ServicesViewModel>, BaseRepository<ServicesViewModel>>();
            services.AddTransient<IAsyncRepository<HorizontalSliderViewModel>, BaseRepository<HorizontalSliderViewModel>>();
            services.AddTransient<IAsyncRepository<SkillsViewModel>, BaseRepository<SkillsViewModel>>();
            services.AddTransient<IAsyncRepository<ProjectViewModel>, BaseRepository<ProjectViewModel>>();
            services.AddTransient<IAsyncRepository<TeamViewModel>, BaseRepository<TeamViewModel>>();
            services.AddTransient<IAsyncRepository<TestimonialViewModel>, BaseRepository<TestimonialViewModel>>();
            services.AddTransient<IAsyncRepository<ProjectCategoryViewModel>, BaseRepository<ProjectCategoryViewModel>>();
            services.AddTransient<IAsyncRepository<ProjectDetailsViewModel>, BaseRepository<ProjectDetailsViewModel>>();

            return services;
        }
         
        public static IServiceCollection AddCorsPolicy(this IServiceCollection services, string policyName)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: policyName, policy =>
                {
                    policy.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            return services;
        }

        public static IServiceCollection AddIdentityServer(this IServiceCollection services, IConfiguration configuration)
        {
             
            // Adding Authentication  
            services.AddAuthentication(options =>
            {
                //options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                //options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                //options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })

            // Adding Jwt Bearer  
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = configuration["JwtSetting:Issuer"],
                    ValidAudience = configuration["JwtSetting:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSetting:Key"] ?? ""))
                };
            });

            return services;
        }
        public static async Task<bool> AddSeedAsync(this IServiceCollection services)
        {
            using var scope = services.BuildServiceProvider().CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            if (dbContext.Database.GetPendingMigrations().Any())
            {
                dbContext.Database.Migrate();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var applicationDbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                await ContextSeed.Seed(userManager, roleManager);
                ConfigurationSeed.Seed(dbContext);

                return true;
            }
            return false;
        }
        public static class ConfigurationSeed
        {
            public static void Seed(ApplicationDbContext context)
            {
                context.Database.EnsureCreated();

                if (context.Configurations.Any())
                {
                    return;
                }

                var configuration = new Configuration
                {
                    Id = Guid.NewGuid(),
                    IsActive = true,
                    Key = ConfigurationKeys.IsCompressedImage,
                    Value = "False",
                };

                context.Configurations.Add(configuration);
                context.SaveChanges();
            }
        }

    }
}
