using Application.Handeler.CQRS.ProjectDetails.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AdminPanelWithApi.Controllers
{
    public class ProjectDetailsController : Controller
    {
        private readonly IMediator _mediator;
        public ProjectDetailsController(IMediator mediator) 
        {
            _mediator = mediator; 
        }
        public async Task<IActionResult> Index(int id) 
        {
            var query = new GetProjectDetailsQuery { Id = id };
            var projectDetails = await _mediator.Send(query); 
            if (projectDetails == null) 
            
            { 
                return View("NotFound"); 
            
            } 
            ViewBag.ProjectImages = projectDetails.ProjectImages;
            
            return View(projectDetails);
        }
    }
}
