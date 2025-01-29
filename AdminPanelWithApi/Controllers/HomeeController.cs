using Application.Handeler.Queries.AboutUs.Queries;
using Application.Handeler.Queries.AskedQuestion.Queries;
using Application.Handeler.Queries.ContactUs.Queries;
using Application.Handeler.Queries.Features.Queries;
using Application.Handeler.Queries.HorizontalSlider.Queries;
using Application.Handeler.Queries.Project.Queries;
using Application.Handeler.Queries.Service.Queries;
using Application.Handeler.Queries.Skills.Queries;
using Application.Handeler.Queries.Team.Queries;
using Application.Handeler.Queries.Testimonial.Queries;
using Application.Handeler.Queries.WhyUs.Queries;
using Domain.Abstractions;
using Domain.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HomeController.Controllers
{
    [AllowAnonymous]
    public class HomeeController : Controller
    {
        private readonly IServicesRepository _servicesRepository;
        private readonly IHorizontalSliderRepository _horizontalSliderRepository;
        private readonly IAboutRepository _aboutRepository;
        private readonly IWhyUsRepository _whyUsRepository;
        private readonly ISkillsRepository _skillsRepository;
        private readonly IProjectsRepository _projectsRepository;
        private readonly ITeamRepository _teamRepository;
        private readonly IFeaturesRepository _featuresRepository;
        private readonly ITestimonialRepository _testimonialRepository;
        private readonly IAskedQuestionRepository _askedQuestionRepository;
        private readonly IContactUsRepository _contactUsRepository;
        private readonly IMediator _mediator;

        public HomeeController(

            IServicesRepository servicesRepository,
            IHorizontalSliderRepository horizontalSliderRepository,
            IAboutRepository aboutRepository,
            IWhyUsRepository whyUsRepository,
            ISkillsRepository skillsRepository,
            IProjectsRepository projectsRepository,
            ITeamRepository teamRepository,
            IFeaturesRepository featuresRepository, 
            ITestimonialRepository testimonialRepository,
            IAskedQuestionRepository askedQuestionRepository, 
            IContactUsRepository contactUsRepository,
            IMediator mediator)
        {
            _servicesRepository = servicesRepository;
            _horizontalSliderRepository = horizontalSliderRepository;
            _aboutRepository = aboutRepository;
            _whyUsRepository = whyUsRepository;
            _skillsRepository = skillsRepository;
            _projectsRepository = projectsRepository;
            _teamRepository = teamRepository;
            _featuresRepository = featuresRepository;
            _testimonialRepository = testimonialRepository;
            _askedQuestionRepository = askedQuestionRepository;
            _contactUsRepository = contactUsRepository;
            
            _mediator = mediator;
        }
        // Return partial views for each method

        public async Task<IActionResult> Index()
        {
            var services = await _mediator.Send(new GetServiceQuery());
            var slider = await _mediator.Send(new GetHorizontalSliderQuery());
            var about = await _mediator.Send(new GetAboutQuery());
            var whyUs = await _mediator.Send(new GetWhyUsQuery());
            var skills = await _mediator.Send(new GetSkillsQuery());
            var projects = await _mediator.Send(new GetProjectsQuery());
            var team = await _mediator.Send(new GetTeamQuery());
            var featuresList = await _mediator.Send(new GetFeaturesQuery());
            var testimonial = await _mediator.Send(new GetTestimonialQuery());
            var askedQuestion = await _mediator.Send(new GetAskedQuestionQuery());
            var contactUs = await _mediator.Send(new GetContactUsQuery());

            var viewModel = new IndexViewModel
            {
                ServicesList = services,
                HorizontalSliderList = slider,
                AboutList = about,
                WhyUsList = whyUs,
                SkillsList = skills,
                ProjectList = projects,
                TeamList = team,
                FeaturesList = featuresList,
                TestimonialList = testimonial,
                AskedQuestionList = askedQuestion,
                ContactUs = contactUs
            };
             projects = await _mediator.Send(new GetProjectsQuery());
            ViewBag.ProjectCategories = projects.Select(p => new
            {
                p.ProjectCategoryId,
                p.ProjectCategoryName
            }).Distinct().ToList();
             featuresList = await _mediator.Send(new GetFeaturesQuery());
            ViewBag.PricingList = featuresList.Select(p => new
            {
                p.PlanName,
                p.Price,
                p.PriceId
            }).Distinct().ToList();
            return View("~/Views/Site/Home/Index.cshtml", viewModel);
        }
        public async Task<PartialViewResult> GetHorizontalSliders()
        {
            var sliders = await _horizontalSliderRepository.GetHorizontalSliderAsync();
            return PartialView("~/Views/Site/Home/_HorizontalSlider", sliders);
        }
        public async Task<PartialViewResult> GetAbout()
        {
            var about = await _aboutRepository.GetAboutAsync();
            return PartialView("~/Views/Site/Home/_About", about);
        }
        public async Task<PartialViewResult> GetWhyUs()
        {
            var whyUs = await _whyUsRepository.GetWhyUsAsync();
            return PartialView("~/Views/Site/Home/_WhyUs", whyUs);
        }
        public async Task<PartialViewResult> GetSkills()
        {
            var skills = await _skillsRepository.GetSkillsAsync();
            return PartialView("~/Views/Site/Home/_Skills", skills);
        }
        public async Task<PartialViewResult> GetServices()
        {
            var services = await _servicesRepository.GetServicesAsync();
            return PartialView("~/Views/Site/Home/_Services", services);
        }

        public async Task<PartialViewResult> GetProjects()
        {
            var projects = await _projectsRepository.GetProjectsAsync();
            return PartialView("~/Views/Site/Home/_Projects", projects);
        }
        public async Task<PartialViewResult> GetTeam()
        {
            var teams = await _teamRepository.GetTeamAsync();
            return PartialView("~/Views/Site/Home/_Team", teams);
        }
        public async Task<PartialViewResult> GetFeatures()
        {
            var features = await _featuresRepository.GetFeaturesAsync();
            return PartialView("~/Views/Site/Home/_Pricing", features);
        }
        public async Task<PartialViewResult> GetTestimonials()
        {
            var testimonials = await _testimonialRepository.GetTestimonialAsync();
            return PartialView("~/Views/Site/Home/_Testimonials", testimonials);
        }
        public async Task<PartialViewResult> GetAskedQuestions()
        {
            var askedQuestions = await _askedQuestionRepository.GetAskedQuestionAsync();
            return PartialView("~/Views/Site/Home/_AskedQuestions", askedQuestions);
        }
        public async Task<PartialViewResult> GetContactUs()
        {
            var contactUs = await _contactUsRepository.GetContactUsAsync();

            return PartialView("~/Views/Site/Home/_ContactUs", contactUs);
        }
    }
}







