using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DentalInformationSystem.Data;
using DentalInformationSystem.Models;
using Newtonsoft.Json;

namespace DentalInformationSystem.Controllers
{
    public class ProtocolsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProtocolsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Protocols
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Protocols.Include(p => p.Patient);
            return View(await applicationDbContext.ToListAsync());
        }




        // GET: Protocols/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var protocol = await _context.Protocols
                .Include(p => p.Patient)
                .FirstOrDefaultAsync(m => m.ProtocolID == id);
            if (protocol == null)
            {
                return NotFound();
            }

            return View(protocol);
        }

        // GET: Protocols/Create
        public IActionResult Create()
        {
            var patients = _context.Patients
                .Select(p => new
                {
                    p.PatientID,
                    FullName = p.Name + " " + p.Surname

                }).ToList();

            ViewData["PatientID"] = new SelectList(patients, "PatientID", "FullName");
            return View();

        }

        // POST: Protocols/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProtocolID,PatientID,Date,Anamnesis,Diagnosis,Therapy,Signet")] Protocol protocol)
        {
            var PatientInDb = _context.Patients.Single(p => p.PatientID == protocol.PatientID);
            protocol.Name = PatientInDb.Name;
            protocol.Surname = PatientInDb.Surname;
            protocol.NameOfOneParent = PatientInDb.NameOfOneParent;
            protocol.Address = PatientInDb.Address;
            protocol.City = PatientInDb.City;
            protocol.YearOfBirth = PatientInDb.YearOfBirth;

            _context.Add(protocol);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


            //ViewData["PatientID"] = new SelectList(_context.Patients, "PatientID", "Name", protocol.PatientID);
            //return View(protocol);
        }

        // GET: Protocols/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var protocol = await _context.Protocols.FindAsync(id);
            if (protocol == null)
            {
                return NotFound();
            }
             var patients = _context.Patients
            .Select(p => new
            {
                p.PatientID,
                FullName = p.Name + " " + p.Surname

            }).ToList();

            ViewData["PatientID"] = new SelectList(patients, "PatientID", "FullName", protocol.PatientID);
            return View(protocol);
        }

        // POST: Protocols/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProtocolID,PatientID,Date,Anamnesis,Diagnosis,Therapy,Signet")] Protocol protocol)
        {
            if (id != protocol.ProtocolID)
            {
                return NotFound();
            }

            var PatientInDb = _context.Patients.Single(p => p.PatientID == protocol.PatientID);
            protocol.Name = PatientInDb.Name;
            protocol.Surname = PatientInDb.Surname;
            protocol.NameOfOneParent = PatientInDb.NameOfOneParent;
            protocol.Address = PatientInDb.Address;
            protocol.City = PatientInDb.City;
            protocol.YearOfBirth = PatientInDb.YearOfBirth;

            try
            {
                _context.Update(protocol);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProtocolExists(protocol.ProtocolID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));

            //if (ModelState.IsValid)
            //{

            //}
            //ViewData["PatientID"] = new SelectList(_context.Patients, "PatientID", "Name", protocol.PatientID);
            //return View(protocol);
        }

        // GET: Protocols/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var protocol = await _context.Protocols
                .Include(p => p.Patient)
                .FirstOrDefaultAsync(m => m.ProtocolID == id);
            if (protocol == null)
            {
                return NotFound();
            }

            return View(protocol);
        }

        // POST: Protocols/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var protocol = await _context.Protocols.FindAsync(id);
            _context.Protocols.Remove(protocol);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProtocolExists(int id)
        {
            return _context.Protocols.Any(e => e.ProtocolID == id);
        }
    }
}
