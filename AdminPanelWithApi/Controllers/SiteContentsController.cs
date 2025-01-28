using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using External.Infrastructure.Persistence.Data;
using AdminPanelWithApi.Helpers.Image;

namespace AdminPanelWithApi.Controllers
{
    public class SiteContentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IImageHelper _imageHelper;
        public SiteContentsController(
            ApplicationDbContext context,
            IWebHostEnvironment webHostEnvironment,
            IImageHelper imageHelper)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _imageHelper = imageHelper;
        }

        // GET: SiteContents
        public async Task<IActionResult> Index()
        {
            return View("~/Views/AdminPanel/SiteContents/Index.cshtml", await _context.SiteContents.ToListAsync());
        }

       

        // GET: SiteContents/Create
        public IActionResult Create()
        {
            return View("~/Views/AdminPanel/SiteContents/Create.cshtml");
        }

        // POST: SiteContents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( SiteContent siteContent,IFormFile? Img,IFormFile? Video1File, IFormFile? Video2File)
        {
            if (ModelState.IsValid)
            {
                siteContent.Id = Guid.NewGuid();
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
                if (Img is not null)
                    siteContent.Image = (await _imageHelper.ProcessImageUpload(Img, uploadsFolder)).Item2;
                if (Video1File is not null)
                    siteContent.Video1 = await _imageHelper.ProcessFileUpload(Video1File, uploadsFolder);
                if (Video2File is not null)
                    siteContent.Video2 = await _imageHelper.ProcessFileUpload(Video1File, uploadsFolder);
                _context.Add(siteContent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View("~/Views/AdminPanel/SiteContents/Create.cshtml", siteContent);
        }

        // GET: SiteContents/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var siteContent = await _context.SiteContents.FindAsync(id);
            if (siteContent == null)
            {
                return NotFound();
            }
            return View("~/Views/AdminPanel/SiteContents/Edit.cshtml", siteContent);
        }

        // POST: SiteContents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, SiteContent siteContent,IFormFile? Img, IFormFile? Video1File, IFormFile? Video2File)
        {
            if (id != siteContent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var siteContentEntity = await _context.SiteContents.FirstOrDefaultAsync(e => e.Id == id);
                    if (siteContentEntity == null)
                    {
                        return NotFound();
                    }
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
                    siteContent.Image = Img is not null ? (await _imageHelper.ProcessImageUpload(Img, uploadsFolder)).Item2 : siteContentEntity.Image;                   
                    siteContent.Video1 = Video1File is not null ? await _imageHelper.ProcessFileUpload(Video1File, uploadsFolder) : siteContentEntity.Video1;
                    siteContent.Video2 = Video2File is not null ? await _imageHelper.ProcessFileUpload(Video2File, uploadsFolder) : siteContentEntity.Video2;
                    siteContent.Page = siteContentEntity.Page;
                    _context.Entry(siteContentEntity).CurrentValues.SetValues(siteContent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SiteContentExists(siteContent.Id))
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
            return View("~/Views/AdminPanel/SiteContents/Edit.cshtml", siteContent);
        }

        // GET: SiteContents/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var siteContent = await _context.SiteContents
                .FirstOrDefaultAsync(m => m.Id == id);
            if (siteContent == null)
            {
                return NotFound();
            }

            return View("~/Views/AdminPanel/SiteContents/Delete.cshtml", siteContent);
        }

        // POST: SiteContents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var siteContent = await _context.SiteContents.FindAsync(id);
            if (siteContent != null)
            {
                _context.SiteContents.Remove(siteContent);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SiteContentExists(Guid id)
        {
            return _context.SiteContents.Any(e => e.Id == id);
        }
    }
}
