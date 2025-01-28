using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using External.Infrastructure.Persistence.Data;

namespace AdminPanelWithApi.Controllers
{
    public class SocialMediasController : Controller
    {
        private readonly ApplicationDbContext _context;
        public SocialMediasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SocialMedias
        public async Task<IActionResult> Index()
        {
            return View("~/Views/AdminPanel/SocialMedias/Index.cshtml", await _context.SocialMedias.ToListAsync());
        }

       

        // GET: SocialMedias/Create
        public IActionResult Create()
        {
            return View("~/Views/AdminPanel/SocialMedias/Create.cshtml");
        }

        // POST: SocialMedias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Link,Id,IsActive")] SocialMedia socialMedia)
        {
            if (ModelState.IsValid)
            {
                socialMedia.Id = Guid.NewGuid();
                _context.Add(socialMedia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View("~/Views/AdminPanel/SocialMedias/Create.cshtml", socialMedia);
        }

        // GET: SocialMedias/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var socialMedia = await _context.SocialMedias.FindAsync(id);
            if (socialMedia == null)
            {
                return NotFound();
            }
            return View("~/Views/AdminPanel/SocialMedias/Edit.cshtml", socialMedia);
        }

        // POST: SocialMedias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Title,Link,Id,IsActive")] SocialMedia socialMedia)
        {
            if (id != socialMedia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(socialMedia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SocialMediaExists(socialMedia.Id))
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
            return View("~/Views/AdminPanel/SocialMedias/Edit.cshtml", socialMedia);
        }

        // GET: SocialMedias/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var socialMedia = await _context.SocialMedias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (socialMedia == null)
            {
                return NotFound();
            }

            return View("~/Views/AdminPanel/SocialMedias/Delete.cshtml", socialMedia);
        }

        // POST: SocialMedias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var socialMedia = await _context.SocialMedias.FindAsync(id);
            if (socialMedia != null)
            {
                _context.SocialMedias.Remove(socialMedia);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SocialMediaExists(Guid id)
        {
            return _context.SocialMedias.Any(e => e.Id == id);
        }
    }
}
