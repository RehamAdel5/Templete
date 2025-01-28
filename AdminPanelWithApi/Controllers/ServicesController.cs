using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using External.Infrastructure.Persistence.Data;
using AdminPanelWithApi.Helpers.Image;

namespace AdminPanelWithApi.Controllers
{
    public class ServicesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IImageHelper _imageHelper;

        public ServicesController(
            ApplicationDbContext context, 
            IWebHostEnvironment webHostEnvironment,
            IImageHelper imageHelper)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _imageHelper = imageHelper;
        }

        // GET: Services
        public async Task<IActionResult> Index()
        {
            return View("~/Views/AdminPanel/Services/Index.cshtml", await _context.Services.ToListAsync());
        }

       

        // GET: Services/Create
        public IActionResult Create()
        {
            return View("~/Views/AdminPanel/Services/Create.cshtml");
        }

        // POST: Services/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Service service,IFormFile? Img)
        {
            if (ModelState.IsValid)
            {
                service.Id = Guid.NewGuid();
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
                if (Img is not null)
                    service.Image = (await _imageHelper.ProcessImageUpload(Img, uploadsFolder)).Item2;
                _context.Add(service);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View("~/Views/AdminPanel/Services/Create.cshtml", service);
        }

        // GET: Services/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = await _context.Services.FindAsync(id);
            if (service == null)
            {
                return NotFound();
            }
            return View("~/Views/AdminPanel/Services/Edit.cshtml", service);
        }

        // POST: Services/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Service service,IFormFile? Img)
        {
            if (id != service.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var serviceEntity = await _context.Services.FirstOrDefaultAsync(e => e.Id == id);
                    if (serviceEntity == null)
                    {
                        return NotFound();
                    }
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
                    service.Image = Img is not null ? (await _imageHelper.ProcessImageUpload(Img, uploadsFolder)).Item2 : serviceEntity.Image;
                    _context.Entry(serviceEntity).CurrentValues.SetValues(service);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceExists(service.Id))
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
            return View("~/Views/AdminPanel/Services/Edit.cshtml", service);
        }

        // GET: Services/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = await _context.Services
                .FirstOrDefaultAsync(m => m.Id == id);
            if (service == null)
            {
                return NotFound();
            }

            return View("~/Views/AdminPanel/Services/Delete.cshtml", service);
        }

        // POST: Services/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var service = await _context.Services.FindAsync(id);
            if (service != null)
            {
                _context.Services.Remove(service);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServiceExists(Guid id)
        {
            return _context.Services.Any(e => e.Id == id);
        }
    }
}
