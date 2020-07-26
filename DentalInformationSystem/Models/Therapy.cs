using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DentalInformationSystem.Models
{
    public class Therapy
    {
        [Display(Name = "Redni broj")]
        public int TherapyID { get; set; }
        [Required, Display(Name = "Naziv terapije")]
        public string TherapyName { get; set; }
        [Required, Display(Name = "Cena")]
        public decimal Price { get; set; }
    }
}
