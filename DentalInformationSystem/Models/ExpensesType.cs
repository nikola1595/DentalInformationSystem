using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DentalInformationSystem.Models
{
    public class ExpensesType
    {
        public int ExpensesTypeID { get; set; }
        [Required, Display(Name ="Naziv tipa rashoda")]
        public string ExpensesTypeName { get; set; }

    }
}
