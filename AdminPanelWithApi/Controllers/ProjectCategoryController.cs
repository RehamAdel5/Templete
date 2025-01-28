using Application.Handeler.CQRS.ProjectCategory.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AdminPanelWithApi.Controllers
{
    public class ProjectCategoryController : Controller
    {
        
        private readonly IMediator _mediator;

        public ProjectCategoryController( IMediator mediator)
        {
            _mediator = mediator;
        
        
        }
        public async Task<IActionResult> Index()
        {
            var categoryList = await _mediator.Send(new GetProjectCategoryQuery());
            ViewBag.CategoryNames = categoryList.Select
                (p => new
                {
                    p.Id,
                    p.CategoryName
                }).Distinct()
                .ToList();
            return View("~/Views/AdminPanel/ProjectCategory/Index.cshtml", categoryList);
        }
        public IActionResult GetProjectCategory()
        {

            return View();

        }
    }
}