using DentalInformationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentalInformationSystem.ViewModels
{
    public class PatientProtocolViewModel
    {
        public IEnumerable<Patient> Patients { get; set; }
        public IEnumerable<Protocol> Protocols { get; set; }
    }
}
