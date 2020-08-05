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
    public class ExpensesTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExpensesTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ExpensesTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.ExpensesTypes.ToListAsync());
        }

        // GET: ExpensesTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expensesType = await _context.ExpensesTypes
                .FirstOrDefaultAsync(m => m.ExpensesTypeID == id);
            if (expensesType == null)
            {
                return NotFound();
            }

            return View(expensesType);
        }

        // GET: ExpensesTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ExpensesTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExpensesTypeID,ExpensesTypeName")] ExpensesType expensesType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(expensesType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(expensesType);
        }

        // GET: ExpensesTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expensesType = await _context.ExpensesTypes.FindAsync(id);
            if (expensesType == null)
            {
                return NotFound();
            }
            return View(expensesType);
        }

        // POST: ExpensesTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ExpensesTypeID,ExpensesTypeName")] ExpensesType expensesType)
        {
            if (id != expensesType.ExpensesTypeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(expensesType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpensesTypeExists(expensesType.ExpensesTypeID))
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
            return View(expensesType);
        }

        // GET: ExpensesTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expensesType = await _context.ExpensesTypes
                .FirstOrDefaultAsync(m => m.ExpensesTypeID == id);
            if (expensesType == null)
            {
                return NotFound();
            }

            return View(expensesType);
        }

        // POST: ExpensesTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var expensesType = await _context.ExpensesTypes.FindAsync(id);
            _context.ExpensesTypes.Remove(expensesType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExpensesTypeExists(int id)
        {
            return _context.ExpensesTypes.Any(e => e.ExpensesTypeID == id);
        }
    }
}
