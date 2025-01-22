using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using External.Infrastructure.Persistence.Data;

namespace AdminPanelWithApi.Controllers
{
    public class ConfigurationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ConfigurationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Configurations
        public async Task<IActionResult> Index()
        {
            return View(await _context.Configurations.ToListAsync());
        }

        // GET: Configurations/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var configuration = await _context.Configurations.FindAsync(id);
            if (configuration == null)
            {
                return NotFound();
            }
            return View(configuration);
        }

        // POST: Configurations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id,Configuration configuration)
        {
            if (id != configuration.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var configEntity =_context.Configurations.FirstOrDefault(configuration => configuration.Id == id);
                    if (configEntity == null)
                    {
                        return NotFound();
                    }
                    configuration.Key = configEntity.Key;
                    _context.Entry(configEntity).CurrentValues.SetValues(configuration);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConfigurationExists(configuration.Id))
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
            return View(configuration);
        }


        private bool ConfigurationExists(Guid id)
        {
            return _context.Configurations.Any(e => e.Id == id);
        }
    }
}
