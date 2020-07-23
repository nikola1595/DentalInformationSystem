using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DentalInformationSystem.Models
{
    public class Patient
    {
        public int PatientID { get; set; }
        [Required,Display(Name="Ime"),StringLength(25)]
        public string Name { get; set; }
        [Required, Display(Name = "Prezime"), StringLength(25)]
        public string Surname { get; set; }
        [Required, Display(Name = "Ime jednog roditelja"), StringLength(25)]
        public string NameOfOneParent { get; set; }
        [Required, Display(Name = "Adresa"), StringLength(50)]
        public string Address { get; set; }
        [Required, Display(Name = "Grad"), StringLength(25)]
        public string City { get; set; }
        [Required, Display(Name = "Kontakt telefon"), StringLength(30)]
        public string Telephone { get; set; }
        [Required, Display(Name = "Godina rodjenja"), MaxLength(4)]
        public int YearOfBirth { get; set; }

    }
}
