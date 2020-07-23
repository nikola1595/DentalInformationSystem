using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DentalInformationSystem.Models
{
    public class Protocol
    {
        public int ProtocolID { get; set; }
        public Patient Patient { get; set; }
        public int PatientID { get; set; }
        [Required, Display(Name = "Datum"), DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{dddd, dd MMMM yyyy}")]
        public DateTime Date { get; set; }

        [Required, Display(Name = "Ime"), StringLength(25)]
        public string Name { get; set; }
        [Required, Display(Name = "Prezime"), StringLength(25)]
        public string Surname { get; set; }
        [Required, Display(Name = "Ime jednog roditelja"), StringLength(25)]
        public string NameOfOneParent { get; set; }
        [Required, Display(Name = "Godina rodjenja"), MaxLength(4)]
        public int YearOfBirth { get; set; }
        [Required, Display(Name = "Adresa"), StringLength(50)]
        public string Address { get; set; }
        [Required, Display(Name = "Grad"), StringLength(25)]
        public string City { get; set; }
        [Required, Display(Name="Anamneza"),MaxLength(255)]
        public string Anamnesis { get; set; }
        [Required, Display(Name = "Dijagnoza"), MaxLength(255)]
        public string Diagnosis { get; set; }
        [Required, Display(Name = "Terapija"), MaxLength(255)]
        public string Therapy { get; set; }
        [Required, Display(Name = "Pecat"), MaxLength(255)]
        public string Signet { get; set; }





    }
}
