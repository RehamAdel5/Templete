using Application.GenericCrudDto.ContactUs;
using Application.GenericCrudDto.Partner;
using Application.GenericCrudDto.Service;
using Application.GenericCrudDto.SiteContant;
using Application.GenericCrudDto.SocialMedia;
using Application.GenericCrudDto.Tag;
using Application.Handeler.Queries.ProjectDetails.Queries;
using AutoMapper;
using Domain.Entities;
using Domain.ViewModels;
using GenericCrudDto.Dto;
using System.Reflection;

namespace Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region CRUD
            CreateMap<SettingDto, Setting>()
               .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Image.FileName));
            CreateMap<Setting, SettingResponseDto>();
            CreateMap<AboutUs, AboutViewModel>().ReverseMap();

            CreateMap<AskedQuestion, AskedQuestionsViewModel>().ReverseMap();
            CreateMap<CompanyInformation, CompanyInformationViewModel>().ReverseMap();
            CreateMap<ContactUs, ContactUsViewModel>().ReverseMap();
            CreateMap<HorizontalSlider, HorizontalSliderViewModel>().ReverseMap();

            CreateMap<Features, PricingViewModel>()
                .ForMember(dest => dest.PlanName, opt => opt.MapFrom(src => src.Pricing.PlanName))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Pricing.Price))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.Pricing.IsActive))
                .ForMember(dest => dest.FeatureId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.PriceId, opt => opt.MapFrom(src => src.Pricing.Id));

            CreateMap<Project, ProjectViewModel>()
                .ForMember(dest => dest.ProjectCategoryName, opt => opt.MapFrom(src => src.ProjectCategory.Name))
                .ForMember(dest => dest.ProjectCategoryDescription, opt => opt.MapFrom(src => src.ProjectCategory.Description))
                .ReverseMap();
            CreateMap<ProjectCategory, ProjectCategoryViewModel>().ReverseMap();
            CreateMap<ProjectDetails, ProjectDetailsViewModel>().ReverseMap();
            CreateMap<Service, ServicesViewModel>().ReverseMap();
            CreateMap<Skill, SkillsViewModel>().ReverseMap();
            CreateMap<Team, TeamViewModel>().ReverseMap();
            CreateMap<WhyUs, WhyUsViewModel>().ReverseMap();
            CreateMap<Testimonial, TestimonialViewModel>().ReverseMap();

            CreateMap<ProjectCategory, ProjectCategoryViewModel>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.MainImagePath, opt => opt.MapFrom(src => src.ImagePath))
                .ForMember(dest => dest.ProjectName, opt => opt.MapFrom(src => src.Projects.FirstOrDefault().Name))
                .ForMember(dest => dest.ProjectBio, opt => opt.MapFrom(src => src.Projects.FirstOrDefault().Bio))
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));


            CreateMap<ProjectDetails, GetProjectDetailsViewModel>()
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate))
                .ForMember(dest => dest.URL, opt => opt.MapFrom(src => src.URL))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.ProjectId, opt => opt.MapFrom(src => src.ProjectId))
                .ForMember(dest => dest.TestimonialId, opt => opt.MapFrom(src => src.TestimonialId));

            CreateMap<ProjectImage, ImageViewModel>();

            CreateMap<SiteContentDto, SiteContent>()
                .ForMember(dest => dest.Image, opt => {
                    opt.PreCondition(src => (src.Image != null));
                    opt.MapFrom(src => src.Image!.FileName);
                })
               .ForMember(dest => dest.Video1, opt => {
                   opt.PreCondition(src => (src.Video1 != null));
                   opt.MapFrom(src => src.Video1!.FileName);
               })
               .ForMember(dest => dest.Video2, opt => {
                   opt.PreCondition(src => (src.Video2 != null));
                   opt.MapFrom(src => src.Video2!.FileName);
               });
            CreateMap<SiteContent, SiteContentResponseDto>()
                 .ForMember(dest => dest.Title, opt => opt.MapFrom((src, dest, destMember, context) =>
                 {
                     return (context.Items.ContainsKey("Lang") && context.Items["Lang"].ToString() == "ar") ? src.TitleAr : src.TitleEn;
                 }))
                .ForMember(dest => dest.SubTitle, opt => opt.MapFrom((src, dest, destMember, context) =>
                {
                    return (context.Items.ContainsKey("Lang") && context.Items["Lang"].ToString() == "ar") ? src.SubTitleAr : src.SubTitleEn;
                }))
                .ForMember(dest => dest.Desc, opt => opt.MapFrom((src, dest, destMember, context) =>
                {
                    return (context.Items.ContainsKey("Lang") && context.Items["Lang"].ToString() == "ar") ? src.DescAr : src.DescEn;
                }));

            CreateMap<SocialMediaDto, SocialMedia>();
            CreateMap<SocialMedia, SocialMediaResponseDto>();

            CreateMap<PartnerDto, Partner>()
                .ForMember(dest => dest.Image, opt => {
                    opt.PreCondition(src => (src.Image != null));
                    opt.MapFrom(src => src.Image!.FileName);
                });
            CreateMap<Partner, PartnerResponseDto>()
                 .ForMember(dest => dest.Title, opt => opt.MapFrom((src, dest, destMember, context) =>
                 {
                     return (context.Items.ContainsKey("Lang") && context.Items["Lang"].ToString() == "ar") ? src.TitleAr : src.TitleEn;
                 }));
            CreateMap<ContactUsDto, ContactUs>();
            CreateMap<ContactUs, ContactUsResponseDto>();
            CreateMap<ServiceDto, Service>()
             .ForMember(dest => dest.Image, opt => {
                 opt.PreCondition(src => (src.Image != null));
                 opt.MapFrom(src => src.Image!.FileName);
             });
            CreateMap<Service, ServiceResponseDto>()
                 .ForMember(dest => dest.Title, opt => opt.MapFrom((src, dest, destMember, context) =>
                 {
                     return (context.Items.ContainsKey("Lang") && context.Items["Lang"].ToString() == "ar") ? src.TitleAr : src.TitleEn;
                 }))
                .ForMember(dest => dest.LongDesc, opt => opt.MapFrom((src, dest, destMember, context) =>
                {
                    return (context.Items.ContainsKey("Lang") && context.Items["Lang"].ToString() == "ar") ? src.LongDescAr : src.LongDescEn;
                }))
                .ForMember(dest => dest.ShortDesc, opt => opt.MapFrom((src, dest, destMember, context) =>
                {
                    return (context.Items.ContainsKey("Lang") && context.Items["Lang"].ToString() == "ar") ? src.ShortDescAr : src.ShortDescEn;
                }));
           

            CreateMap<TagDto, Tag>();
            CreateMap<Tag, TagResponseDto>()
                 .ForMember(dest => dest.Name, opt => opt.MapFrom((src, dest, destMember, context) =>
                 {
                     return (context.Items.ContainsKey("Lang") && context.Items["Lang"].ToString() == "ar") ? src.NameAr : src.NameEn;
                 }))
                 .ForMember(dest => dest.Content, opt => opt.MapFrom((src, dest, destMember, context) =>
                 {
                     return (context.Items.ContainsKey("Lang") && context.Items["Lang"].ToString() == "ar") ? src.ContentAr : src.ContentEn;
                 }))
                 .ForMember(dest => dest.Property, opt => opt.MapFrom((src, dest, destMember, context) =>
                 {
                     return (context.Items.ContainsKey("Lang") && context.Items["Lang"].ToString() == "ar") ? src.PropertyAr : src.PropertyEn;
                 }));
            #endregion


            ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
        }

        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            dynamic types = assembly.GetExportedTypes()
                .Where(t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)))
                .ToList();

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);
                var methodInfo = type.GetMethod("Mapping");
                methodInfo?.Invoke(instance, new object[] { this });
            }
        }
    }
}
