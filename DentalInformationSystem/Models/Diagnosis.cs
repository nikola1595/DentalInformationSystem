using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DentalInformationSystem.Models
{
    public class Diagnosis
    {
        public int DiagnosisID { get; set; }

        [Required, MaxLength(5), Display(Name = "Šifra dijagnoze")]
        public string DiagnosisCode { get; set; }
        [Required, Display(Name = "Dijagnoza srpski")]
        public string DiagnosisNameSrb { get; set; }
        [Required, Display(Name = "Dijagnoza latinski")]
        public string DiagnosisNameLatin { get; set; }
    }
}
