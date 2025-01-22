using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using External.Infrastructure.Persistence.Data;
using AdminPanelWithApi.Helpers.Image;

namespace AdminPanelWithApi.Controllers
{
    public class PartnersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IImageHelper _imageHelper;

        public PartnersController(ApplicationDbContext context, 
            IWebHostEnvironment webHostEnvironment,
            IImageHelper imageHelper)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _imageHelper = imageHelper;
        }

        // GET: Partners
        public async Task<IActionResult> Index()
        {
            return View(await _context.Partners.ToListAsync());
        }

        
        // GET: Partners/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Partners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Partner partner,IFormFile? Img)
        {
            if (ModelState.IsValid)
            {
                partner.Id = Guid.NewGuid();
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
                if (Img is not null)
                    partner.Image = (await _imageHelper.ProcessImageUpload(Img, uploadsFolder)).Item2;
                _context.Add(partner);
                await _context.SaveChangesAsync();                
                return RedirectToAction(nameof(Index));
            }
            return View(partner);
        }

        // GET: Partners/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partner = await _context.Partners.FindAsync(id);
            if (partner == null)
            {
                return NotFound();
            }
            return View(partner);
        }

        // POST: Partners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Partner partner,IFormFile? Img)
        {
            if (id != partner.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var PartnerEntity = await _context.Partners.FirstOrDefaultAsync(e => e.Id == id);
                    if (PartnerEntity == null)
                    {
                        return NotFound();
                    }
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
                    partner.Image = Img is not null ? (await _imageHelper.ProcessImageUpload(Img, uploadsFolder)).Item2 : PartnerEntity.Image;
                    _context.Entry(PartnerEntity).CurrentValues.SetValues(partner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PartnerExists(partner.Id))
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
            return View(partner);
        }

        // GET: Partners/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partner = await _context.Partners
                .FirstOrDefaultAsync(m => m.Id == id);
            if (partner == null)
            {
                return NotFound();
            }

            return View(partner);
        }

        // POST: Partners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var partner = await _context.Partners.FindAsync(id);
            if (partner != null)
            {
                _context.Partners.Remove(partner);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PartnerExists(Guid id)
        {
            return _context.Partners.Any(e => e.Id == id);
        }        
    }
}
