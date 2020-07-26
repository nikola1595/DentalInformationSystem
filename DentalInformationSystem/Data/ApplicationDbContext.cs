using System;
using System.Collections.Generic;
using System.Text;
using DentalInformationSystem.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DentalInformationSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Protocol> Protocols { get; set; }

        public DbSet<Diagnosis> Diagnoses { get; set; }

        public DbSet<Therapy> Therapies { get; set; }

        public DbSet<Anamnesis> Anamneses { get; set; }

    }
}
