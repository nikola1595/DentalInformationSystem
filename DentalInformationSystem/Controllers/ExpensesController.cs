using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DentalInformationSystem.Data;
using DentalInformationSystem.Models;
using System.Security.Cryptography.X509Certificates;
using DentalInformationSystem.ViewModels;
using Rotativa.AspNetCore;

namespace DentalInformationSystem.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExpensesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Expenses
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Expenses.Include(e => e.ExpensesType);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Expenses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expense = await _context.Expenses
                .Include(e => e.ExpensesType)
                .FirstOrDefaultAsync(m => m.ExpenseID == id);
            if (expense == null)
            {
                return NotFound();
            }

            return View(expense);
        }

        // GET: Expenses/Create
        public IActionResult Create()
        {
            ViewData["ExpensesTypeID"] = new SelectList(_context.ExpensesTypes, "ExpensesTypeID", "ExpensesTypeName");


            ViewBag.Rashod = _context.ExpensesTypes.ToList();

            return View();
        }

        // POST: Expenses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExpenseID,ExpenseDate,ExpensesTypeID,Price")] Expense expense, string Rashod)
        {
            if (ModelState.IsValid)
            {
                var RashodIme = _context.ExpensesTypes.Single(e => e.ExpensesTypeName == Rashod);
                expense.ExpensesTypeID = RashodIme.ExpensesTypeID;
                _context.Add(expense);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ExpensesTypeID"] = new SelectList(_context.ExpensesTypes, "ExpensesTypeID", "ExpensesTypeName", expense.ExpensesTypeID);
            return View(expense);
        }

        // GET: Expenses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var expense = await _context.Expenses.Include(et => et.ExpensesType).FirstOrDefaultAsync(e => e.ExpenseID == id);
            


            if (expense == null)
            {
                return NotFound();
            }
            ViewData["ExpensesTypeID"] = new SelectList(_context.ExpensesTypes, "ExpensesTypeID", "ExpensesTypeName", expense.ExpensesTypeID);

            ViewBag.Rashod = _context.ExpensesTypes.ToList();

            return View(expense);
        }

        // POST: Expenses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ExpenseID,ExpenseDate,ExpensesTypeID,Price")] Expense expense,string Rashod)
        {
            if (id != expense.ExpenseID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var RashodIme = _context.ExpensesTypes.Single(et => et.ExpensesTypeName == Rashod);
                    expense.ExpensesTypeID = RashodIme.ExpensesTypeID;

                    _context.Update(expense);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpenseExists(expense.ExpenseID))
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
            ViewData["ExpensesTypeID"] = new SelectList(_context.ExpensesTypes, "ExpensesTypeID", "ExpensesTypeName", expense.ExpensesTypeID);
            return View(expense);
        }

        // GET: Expenses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expense = await _context.Expenses
                .Include(e => e.ExpensesType)
                .FirstOrDefaultAsync(m => m.ExpenseID == id);
            if (expense == null)
            {
                return NotFound();
            }

            return View(expense);
        }

        // POST: Expenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var expense = await _context.Expenses.FindAsync(id);
            _context.Expenses.Remove(expense);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExpenseExists(int id)
        {
            return _context.Expenses.Any(e => e.ExpenseID == id);
        }


        public IActionResult DatePicker2ExpensesPDF()
        {
            return View("DatePicker2ExpensesPDF");
        }


        public IActionResult GenerateExpenses(DateTime date1, DateTime date2)
        {
            var expenses = _context.Expenses
                .Include(et => et.ExpensesType)
                .Where(x => x.ExpenseDate >= date1 && x.ExpenseDate <= date2).OrderBy(x => x.ExpenseDate).ToList();


            var ProcurementExpenses = _context.Procurements
                .Include(s => s.Supplier)
                .Where(x => x.ProcurementDate >= date1 && x.ProcurementDate <= date2).ToList();


            var vm = new ExpensesProcurementsViewModel()
            {
                Expenses = expenses,
                Procurements = ProcurementExpenses,
                StartDate = date1,
                EndDate = date2
            };


            return new ViewAsPdf("ExpensesReport", vm);

        }
    }
}
