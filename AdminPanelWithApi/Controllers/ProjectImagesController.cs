using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using External.Infrastructure.Persistence.Data;
using Domain.Entities;

namespace AdminPanelWithApi.Controllers
{
    public class ProjectImagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProjectImagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProjectImages
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ProjectImages.Include(p => p.Project);
            return View("~/Views/AdminPanel/ProjectImages/Index.cshtml", await applicationDbContext.ToListAsync());
        }

        // GET: ProjectImages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectImage = await _context.ProjectImages
                .Include(p => p.Project)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projectImage == null)
            {
                return NotFound();
            }

            return View("~/Views/AdminPanel/ProjectImages/Details.cshtml", projectImage);
        }

        // GET: ProjectImages/Create
        public IActionResult Create()
        {
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Id");
            return View("~/Views/AdminPanel/ProjectImages/Create.cshtml");
        }

        // POST: ProjectImages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ImagePath,ProjectId")] ProjectImage projectImage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(projectImage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Id", projectImage.ProjectId);
            return View("~/Views/AdminPanel/ProjectImages/Create.cshtml", projectImage);
        }

        // GET: ProjectImages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectImage = await _context.ProjectImages.FindAsync(id);
            if (projectImage == null)
            {
                return NotFound();
            }
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Id", projectImage.ProjectId);
            return View("~/Views/AdminPanel/ProjectImages/Edit.cshtml", projectImage);
        }

        // POST: ProjectImages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ImagePath,ProjectId")] ProjectImage projectImage)
        {
            if (id != projectImage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projectImage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectImageExists(projectImage.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Id", projectImage.ProjectId);
            return View("~/Views/AdminPanel/ProjectImages/Edit.cshtml", projectImage);
        }

        // GET: ProjectImages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectImage = await _context.ProjectImages
                .Include(p => p.Project)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projectImage == null)
            {
                return NotFound();
            }

            return View("~/Views/AdminPanel/ProjectImages/Delete.cshtml", projectImage);
        }

        // POST: ProjectImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var projectImage = await _context.ProjectImages.FindAsync(id);
            if (projectImage != null)
            {
                _context.ProjectImages.Remove(projectImage);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectImageExists(int id)
        {
            return _context.ProjectImages.Any(e => e.Id == id);
        }
    }
}
