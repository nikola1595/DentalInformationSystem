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
    public class ProcurementsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProcurementsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Procurements
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Procurements.Include(p => p.Supplier);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Procurements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var procurement = await _context.Procurements
                .Include(p => p.Supplier)
                .FirstOrDefaultAsync(m => m.ProcurementID == id);
            if (procurement == null)
            {
                return NotFound();
            }

            return View(procurement);
        }

        // GET: Procurements/Create
        public IActionResult Create()
        {
            ViewData["SupplierID"] = new SelectList(_context.Suppliers, "SupplierID", "SupplierName");


            return View();
        }

        // POST: Procurements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProcurementID,ProcurementDate,SupplierID,DeliveryNoteNumber,MerchandiseName,MeasureUnit,UnitPrice,Quantity")] Procurement procurement)
        {
            if (ModelState.IsValid)
            {
                procurement.TotalPrice = procurement.UnitPrice * procurement.Quantity;
                _context.Add(procurement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SupplierID"] = new SelectList(_context.Suppliers, "SupplierID", "SupplierName", procurement.SupplierID);
            return View(procurement);
        }

        // GET: Procurements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var procurement = await _context.Procurements.FindAsync(id);
            if (procurement == null)
            {
                return NotFound();
            }
            ViewData["SupplierID"] = new SelectList(_context.Suppliers, "SupplierID", "SupplierName", procurement.SupplierID);
            return View(procurement);
        }

        // POST: Procurements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProcurementID,ProcurementDate,SupplierID,DeliveryNoteNumber,MerchandiseName,MeasureUnit,UnitPrice,Quantity")] Procurement procurement)
        {
            if (id != procurement.ProcurementID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                procurement.TotalPrice = procurement.UnitPrice * procurement.Quantity;
                try
                {

                    _context.Update(procurement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProcurementExists(procurement.ProcurementID))
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
            ViewData["SupplierID"] = new SelectList(_context.Suppliers, "SupplierID", "SupplierName", procurement.SupplierID);
            return View(procurement);
        }

        // GET: Procurements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var procurement = await _context.Procurements
                .Include(p => p.Supplier)
                .FirstOrDefaultAsync(m => m.ProcurementID == id);
            if (procurement == null)
            {
                return NotFound();
            }

            return View(procurement);
        }

        // POST: Procurements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var procurement = await _context.Procurements.FindAsync(id);
            _context.Procurements.Remove(procurement);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProcurementExists(int id)
        {
            return _context.Procurements.Any(e => e.ProcurementID == id);
        }
    }
}
