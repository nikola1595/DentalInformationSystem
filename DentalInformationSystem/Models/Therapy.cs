using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DentalInformationSystem.Models
{
    public class Therapy
    {
        [Display(Name = "Redni broj")]
        public int TherapyID { get; set; }
        [Required, Display(Name = "Naziv usluge")]
        public string TherapyName { get; set; }
        [Required, Display(Name = "Cena"),Column(TypeName = "decimal(18,0)")]
        public decimal Price { get; set; }
    }
}
