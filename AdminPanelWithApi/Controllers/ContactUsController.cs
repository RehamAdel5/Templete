using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using External.Infrastructure.Persistence.Data;

namespace AdminPanelWithApi.Controllers
{
    public class ContactUsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContactUsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ContactUs
        public async Task<IActionResult> Index()
        {
            return View("~/Views/AdminPanel/ContactUs/Index.cshtml",await _context.ContactUs.ToListAsync());
        }

        // GET: ContactUs/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactUs = await _context.ContactUs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactUs == null)
            {
                return NotFound();
            }

            return View("~/Views/AdminPanel/ContactUs/Delete.cshtml",contactUs);
        }

        // POST: ContactUs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var contactUs = await _context.ContactUs.FindAsync(id);
            if (contactUs != null)
            {
                _context.ContactUs.Remove(contactUs);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        // GET: ContactUs Details
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var contactUs = await _context.ContactUs.FirstOrDefaultAsync(item=>item.Id == id);
            return View("~/Views/AdminPanel/ContactUs/Details.cshtml",contactUs);
        }
    }
}
