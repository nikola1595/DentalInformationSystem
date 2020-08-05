using DentalInformationSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DentalInformationSystem.ViewModels
{
    public class ProtocolDatesViewModel
    {
        public IEnumerable<Protocol> Protocols { get; set; }
        public IEnumerable<Expense> Expenses { get; set; }
        public IEnumerable<Procurement> Procurements { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
    }
}
