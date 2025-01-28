﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using External.Infrastructure.Persistence.Data;
using Domain.Entities;

namespace AdminPanelWithApi.Controllers
{
    public class PricingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PricingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Pricings
        public async Task<IActionResult> Index()
        {
            return View("~/Views/AdminPanel/Pricings/Index.cshtml", await _context.Pricings.ToListAsync());
        }

        // GET: Pricings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pricing = await _context.Pricings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pricing == null)
            {
                return NotFound();
            }

            return View("~/Views/AdminPanel/Pricings/Details.cshtml", pricing);
        }

        // GET: Pricings/Create
        public IActionResult Create()
        {
            return View("~/Views/AdminPanel/Pricings/Create.cshtml");
        }

        // POST: Pricings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PlanName,Price,IsActive")] Pricing pricing)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pricing);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View("~/Views/AdminPanel/Pricings/Create.cshtml", pricing);
        }

        // GET: Pricings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pricing = await _context.Pricings.FindAsync(id);
            if (pricing == null)
            {
                return NotFound();
            }
            return View("~/Views/AdminPanel/Pricings/Edit.cshtml", pricing);
        }

        // POST: Pricings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PlanName,Price,IsActive")] Pricing pricing)
        {
            if (id != pricing.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pricing);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PricingExists(pricing.Id))
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
            return View("~/Views/AdminPanel/Pricings/Edit.cshtml", pricing);
        }

        // GET: Pricings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pricing = await _context.Pricings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pricing == null)
            {
                return NotFound();
            }

            return View("~/Views/AdminPanel/Pricings/Delete.cshtml", pricing);
        }

        // POST: Pricings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pricing = await _context.Pricings.FindAsync(id);
            if (pricing != null)
            {
                _context.Pricings.Remove(pricing);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PricingExists(int id)
        {
            return _context.Pricings.Any(e => e.Id == id);
        }
    }
}
