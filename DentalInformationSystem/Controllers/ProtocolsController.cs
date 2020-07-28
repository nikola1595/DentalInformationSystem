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
            var applicationDbContext = _context.Protocols.Include(p => p.Patient)
                .Include(d => d.Diagnosis)
                .Include(t => t.Therapy)
                .Include(a => a.Anamnesis);
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
                .Include(d => d.Diagnosis)
                .Include(t => t.Therapy)
                .Include(a => a.Anamnesis)
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

            // ViewData["Pacijent"] = new SelectList(patients, "PatientID", "FullName");

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

            ViewBag.Terapija = _context.Therapies.ToList();

            ViewBag.Anamneza = _context.Anamneses.ToList();

            return View();

        }

        // POST: Protocols/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProtocolID,PatientID,Date,AnamnesisID,DiagnosisID,TherapyID")] Protocol protocol, string Dijagnoza,string Pacijent,string Terapija, string Anamneza)
        {


            var DijagnozaIme = _context.Diagnoses.Single(d => d.DiagnosisNameSrb == Dijagnoza);

            var PacijentIme = _context.Patients.Single(p => p.Name + " " + p.Surname == Pacijent);

            var TerapijaIme = _context.Therapies.Single(t => t.TherapyName == Terapija);

            var AnamnezaIme = _context.Anamneses.Single(a => a.AnamnesisName == Anamneza);

            protocol.AnamnesisID = AnamnezaIme.AnamnesisID;

            protocol.PatientID = PacijentIme.PatientID;

            protocol.DiagnosisID = DijagnozaIme.DiagnosisID;

            protocol.TherapyID = TerapijaIme.TherapyID;

            protocol.Signet = "Pacijentima dato obaveštenje o članu 11 zakona o pravima pacijenata";


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

            ViewBag.Terapija = _context.Therapies.ToList();

            ViewBag.Anamneza = _context.Anamneses.ToList();

            //ViewData["DiagnosisID"] = new SelectList(diagnoses, "DiagnosisID", "DiagnoseBothNames",protocol.DiagnosisID);


            return View(protocol);
        }

        // POST: Protocols/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProtocolID,PatientID,Date,AnamnesisID,DiagnosisID,TherapyID")] Protocol protocol, string Dijagnoza, string Terapija, string Anamneza)
        {
            if (id != protocol.ProtocolID)
            {
                return NotFound();
            }

            var PacijentInDb = _context.Patients.Single(p => p.PatientID == protocol.PatientID);

            var DijagnozaIme = _context.Diagnoses.Single(d => d.DiagnosisNameSrb == Dijagnoza);

            var TerapijaIme = _context.Therapies.Single(t => t.TherapyName == Terapija);

            var AnamnezaIme = _context.Anamneses.Single(a => a.AnamnesisName == Anamneza);

            protocol.TherapyID = TerapijaIme.TherapyID;
            protocol.DiagnosisID = DijagnozaIme.DiagnosisID;

            protocol.AnamnesisID = AnamnezaIme.AnamnesisID;

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
                .Include(d => d.Diagnosis)
                .Include(t => t.Therapy)
                .Include(a => a.Anamnesis)
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
