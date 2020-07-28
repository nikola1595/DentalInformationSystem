using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DentalInformationSystem.Models
{
    public class Expense
    {
        public int ExpenseID { get; set; }
        [Required,DataType(DataType.Date),Display(Name="Datum rashoda")]
        public DateTime ExpenseDate { get; set; }
        public ExpensesType ExpensesType { get; set; }
        [Required, Display(Name = "Naziv rashoda")]
        public int ExpensesTypeID { get; set; }
        [Required,Display(Name = "Cena rashoda"), Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

    }
}
