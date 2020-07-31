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
        public Protocol Protocol { get; set; }
        public Patient Patient { get; set; }
        public Anamnesis Anamnesis { get; set; }
        public Diagnosis Diagnosis { get; set; }
        public Therapy Therapy { get; set; }
        [DataType(DataType.Date),Display(Name ="Početni datum")]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date), Display(Name = "Završni datum")]
        public DateTime EndDate { get; set; }
    }
}
