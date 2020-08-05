using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DentalInformationSystem.Data;
using DentalInformationSystem.Models;
using Rotativa.AspNetCore;
using Microsoft.AspNetCore.Authorization;

namespace DentalInformationSystem.Controllers
{
    [Authorize]
    public class TherapiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TherapiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Therapies
        public async Task<IActionResult> Index()
        {
            return View(await _context.Therapies.ToListAsync());
        }

        // GET: Therapies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var therapy = await _context.Therapies
                .FirstOrDefaultAsync(m => m.TherapyID == id);
            if (therapy == null)
            {
                return NotFound();
            }

            return View(therapy);
        }

        // GET: Therapies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Therapies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TherapyID,TherapyName,Price")] Therapy therapy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(therapy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(therapy);
        }

        // GET: Therapies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var therapy = await _context.Therapies.FindAsync(id);
            if (therapy == null)
            {
                return NotFound();
            }
            return View(therapy);
        }

        // POST: Therapies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TherapyID,TherapyName,Price")] Therapy therapy)
        {
            if (id != therapy.TherapyID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(therapy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TherapyExists(therapy.TherapyID))
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
            return View(therapy);
        }

        // GET: Therapies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var therapy = await _context.Therapies
                .FirstOrDefaultAsync(m => m.TherapyID == id);
            if (therapy == null)
            {
                return NotFound();
            }

            return View(therapy);
        }

        // POST: Therapies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var therapy = await _context.Therapies.FindAsync(id);
            _context.Therapies.Remove(therapy);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TherapyExists(int id)
        {
            return _context.Therapies.Any(e => e.TherapyID == id);
        }



        public IActionResult PrintListOfRates()
        {

            var listOfRates = _context.Therapies.ToList();

            return new ViewAsPdf("ListOfRates", listOfRates);
        }
    }
}
