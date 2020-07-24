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

        [Required, Display(Name = "Dijagnoza srpski naziv")]
        public string DiagnosisNameSrb { get; set; }
        [Required, Display(Name = "Dijagnoza latinski naziv")]
        public string DiagnosisNameLatin { get; set; }
    }
}
