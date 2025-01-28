using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using External.Infrastructure.Persistence.Data;
using Domain.Entities;

namespace AdminPanelWithApi.Controllers
{
    public class WhyUsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WhyUsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: WhyUs
        public async Task<IActionResult> Index()
        {
            return View("~/Views/AdminPanel/WhyUs/Index.cshtml", await _context.WhyUs.ToListAsync());
        }

        // GET: WhyUs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var whyUs = await _context.WhyUs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (whyUs == null)
            {
                return NotFound();
            }

            return View("~/Views/AdminPanel/WhyUs/Details.cshtml", whyUs);
        }

        // GET: WhyUs/Create
        public IActionResult Create()
        {
            return View("~/Views/AdminPanel/WhyUs/Create.cshtml");
        }

        // POST: WhyUs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Question,Answer")] WhyUs whyUs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(whyUs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View("~/Views/AdminPanel/WhyUs/Create.cshtml", whyUs);
        }

        // GET: WhyUs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var whyUs = await _context.WhyUs.FindAsync(id);
            if (whyUs == null)
            {
                return NotFound();
            }
            return View("~/Views/AdminPanel/WhyUs/Edit.cshtml", whyUs);
        }

        // POST: WhyUs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Question,Answer")] WhyUs whyUs)
        {
            if (id != whyUs.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(whyUs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WhyUsExists(whyUs.Id))
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
            return View("~/Views/AdminPanel/WhyUs/Edit.cshtml", whyUs);
        }

        // GET: WhyUs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var whyUs = await _context.WhyUs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (whyUs == null)
            {
                return NotFound();
            }

            return View("~/Views/AdminPanel/WhyUs/Delete.cshtml", whyUs);
        }

        // POST: WhyUs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var whyUs = await _context.WhyUs.FindAsync(id);
            if (whyUs != null)
            {
                _context.WhyUs.Remove(whyUs);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WhyUsExists(int id)
        {
            return _context.WhyUs.Any(e => e.Id == id);
        }
    }
}
