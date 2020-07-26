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
            var applicationDbContext = _context.Protocols.Include(p => p.Patient).Include(d => d.Diagnosis);
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
                .Include(p => p.Patient).Include(d => d.Diagnosis)
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
            //patients
            var patients = _context.Patients
                .Select(p => new
                {
                    p.PatientID,
                    FullName = p.Name + " " + p.Surname

                }).ToList();

            ViewData["PatientID"] = new SelectList(patients, "PatientID", "FullName");

            // //diagnoses
            // var diagnoses = _context.Diagnoses
            //.Select(d => new
            //{
            //    d.DiagnosisID,
            //    DiagnoseBothNames = d.DiagnosisNameSrb + " | " + d.DiagnosisNameLatin

            //}).ToList();

            // ViewData["DiagnosisID"] = new SelectList(diagnoses, "DiagnosisID", "DiagnoseBothNames");

            ViewBag.Dijagnoza = _context.Diagnoses.ToList();

            ViewBag.Pacijent = _context.Patients.ToList();


            return View();

        }

        // POST: Protocols/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProtocolID,PatientID,Date,Anamnesis,DiagnosisID,Therapy,Signet")] Protocol protocol, string Dijagnoza,string Pacijent)
        {

            //var PatientInDb = _context.Patients.Single(p => p.PatientID == protocol.PatientID);
            //protocol.Name = PatientInDb.Name;
            //protocol.Surname = PatientInDb.Surname;
            //protocol.NameOfOneParent = PatientInDb.NameOfOneParent;
            //protocol.Address = PatientInDb.Address;
            //protocol.City = PatientInDb.City;
            //protocol.YearOfBirth = PatientInDb.YearOfBirth;

            var DijagnozaIme = _context.Diagnoses.Single(d => d.DiagnosisNameSrb == Dijagnoza);

            var PacijentIme = _context.Patients.Single(p => p.Surname == Pacijent);

            protocol.PatientID = PacijentIme.PatientID;

            protocol.DiagnosisID = DijagnozaIme.DiagnosisID;

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

            //var diagnoses = _context.Diagnoses
            //    .Select(d => new
            //    {
            //       d.DiagnosisID,
            //       DiagnoseBothNames = d.DiagnosisNameSrb + " | " + d.DiagnosisNameLatin

            //    }).ToList();


            ViewBag.Dijagnoza = _context.Diagnoses.ToList();

            

            //ViewData["DiagnosisID"] = new SelectList(diagnoses, "DiagnosisID", "DiagnoseBothNames",protocol.DiagnosisID);


            return View(protocol);
        }

        // POST: Protocols/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProtocolID,PatientID,Date,Anamnesis,DiagnosisID,Therapy,Signet")] Protocol protocol, string Dijagnoza)
        {
            if (id != protocol.ProtocolID)
            {
                return NotFound();
            }
            

            //var PatientInDb = _context.Patients.Single(p => p.PatientID == protocol.PatientID);
            //protocol.Name = PatientInDb.Name;
            //protocol.Surname = PatientInDb.Surname;
            //protocol.NameOfOneParent = PatientInDb.NameOfOneParent;
            //protocol.Address = PatientInDb.Address;
            //protocol.City = PatientInDb.City;
            //protocol.YearOfBirth = PatientInDb.YearOfBirth;

            var DijagnozaIme = _context.Diagnoses.Single(d => d.DiagnosisNameSrb == Dijagnoza);

            protocol.DiagnosisID = DijagnozaIme.DiagnosisID;

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
