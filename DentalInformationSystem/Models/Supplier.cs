using Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Manage.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DentalInformationSystem.Models
{
    public class Supplier
    {
        public int SupplierID { get; set; }
        [Required, Display(Name = "Naziv dobavljača")]
        public string SupplierName { get; set; }
        [Required,Display(Name = "Broj računa")]
        public string AccountNumber {get;set;}
        [Display(Name = "Adresa")]
        public string Address { get; set; }
        [Display(Name = "Telefon")]
        public string Telephone { get; set; }
        public string PIB { get; set; }
        [Display(Name = "Email adresa")]
        public string Email { get; set; }
    }
}
