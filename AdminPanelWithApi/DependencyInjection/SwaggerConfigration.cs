using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Web.DependencyInjection
{
    public class SwaggerConfigration : IConfigureOptions<SwaggerGenOptions>
    {
        public void Configure(SwaggerGenOptions c)
        {
            var info = new OpenApiInfo
            {
                Title = "Tamplete",
                Version = "v1",
                Description = "Tamplete For AimStyle",
                TermsOfService = new Uri("https://example.com/terms"),
                Contact = new OpenApiContact
                {
                    Name = "Example Contact",
                    Url = new Uri("https://example.com/contact")
                },
                License = new OpenApiLicense
                {
                    Name = "Example License",
                    Url = new Uri("https://example.com/license")
                }
            };
             
            c.SwaggerDoc("AuthAPI", info); 
            c.SwaggerDoc("SettingCrud", info); 
            c.SwaggerDoc("PartnerCrud", info);
            c.SwaggerDoc("SiteContentCrud", info);
            c.SwaggerDoc("SocialMediaCrud", info);
            c.SwaggerDoc("ContactUsCrud", info);
            c.SwaggerDoc("ServiceCrud", info);
            c.SwaggerDoc("SeoCrud", info);
            c.SwaggerDoc("TagCrud", info);


            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "JWT Authorization header using the Bearer scheme."
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}

                    }
                });
             

        }
    }
    public class SwaggerUIConfiguration : IConfigureOptions<SwaggerUIOptions>
    {
        public void Configure(SwaggerUIOptions options)
        {

            options.RoutePrefix = "Swagger"; 
            options.SwaggerEndpoint("/swagger/AuthAPI/swagger.json", "Auth API V1");  
            options.SwaggerEndpoint("/swagger/SettingCrud/swagger.json", "SettingCrud API V1");  
            options.SwaggerEndpoint("/swagger/PartnerCrud/swagger.json", "PartnerCrud API V1");
            options.SwaggerEndpoint("/swagger/SiteContentCrud/swagger.json", "SiteContentCrud API V1");
            options.SwaggerEndpoint("/swagger/SocialMediaCrud/swagger.json", "SocialMediaCrud API V1");
            options.SwaggerEndpoint("/swagger/ContactUsCrud/swagger.json", "ContactUsCrud API V1");
            options.SwaggerEndpoint("/swagger/ServiceCrud/swagger.json", "ServiceCrud API V1");
            options.SwaggerEndpoint("/swagger/SeoCrud/swagger.json", "SeoCrud API V1");
            options.SwaggerEndpoint("/swagger/TagCrud/swagger.json", "TagCrud API V1");





        }
    }
}
