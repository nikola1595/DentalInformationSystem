using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DentalInformationSystem.Data;
using DentalInformationSystem.Models;
using Microsoft.AspNetCore.Authorization;

namespace DentalInformationSystem.Controllers
{
    [Authorize]
    public class AnamnesesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AnamnesesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Anamneses
        public async Task<IActionResult> Index()
        {
            return View(await _context.Anamneses.ToListAsync());
        }

        // GET: Anamneses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anamnesis = await _context.Anamneses
                .FirstOrDefaultAsync(m => m.AnamnesisID == id);
            if (anamnesis == null)
            {
                return NotFound();
            }

            return View(anamnesis);
        }

        // GET: Anamneses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Anamneses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AnamnesisID,AnamnesisName")] Anamnesis anamnesis)
        {
            if (ModelState.IsValid)
            {
                _context.Add(anamnesis);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(anamnesis);
        }

        // GET: Anamneses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anamnesis = await _context.Anamneses.FindAsync(id);
            if (anamnesis == null)
            {
                return NotFound();
            }
            return View(anamnesis);
        }

        // POST: Anamneses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AnamnesisID,AnamnesisName")] Anamnesis anamnesis)
        {
            if (id != anamnesis.AnamnesisID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(anamnesis);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnamnesisExists(anamnesis.AnamnesisID))
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
            return View(anamnesis);
        }

        // GET: Anamneses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anamnesis = await _context.Anamneses
                .FirstOrDefaultAsync(m => m.AnamnesisID == id);
            if (anamnesis == null)
            {
                return NotFound();
            }

            return View(anamnesis);
        }

        // POST: Anamneses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var anamnesis = await _context.Anamneses.FindAsync(id);
            _context.Anamneses.Remove(anamnesis);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnamnesisExists(int id)
        {
            return _context.Anamneses.Any(e => e.AnamnesisID == id);
        }
    }
}
