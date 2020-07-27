using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DentalInformationSystem.Models
{
    public class Protocol
    {
        [Display(Name="Redni broj")]
        public int ProtocolID { get; set; }
        public Patient Patient { get; set; }
        public int PatientID { get; set; }
        [Required, DataType(DataType.Date), Display(Name = "Datum")]
        public DateTime Date { get; set; }

        [Required, Display(Name="Anamneza"),MaxLength(255)]
        public Anamnesis Anamnesis { get; set; }
        [Display(Name ="Anamneza")]
        public int AnamnesisID { get; set; }
        public Diagnosis Diagnosis { get; set; }
        [Required, Display(Name = "Dijagnoza")]
        public int DiagnosisID { get; set; }
        public Therapy Therapy { get; set; }
        [Display(Name = "Terapija")]
        public int TherapyID { get; set; }
        [Required, Display(Name = "Pečat"), MaxLength(255)]
        public string Signet { get; set; }





    }
}
