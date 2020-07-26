using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DentalInformationSystem.Models
{
    public class Anamnesis
    {
        public int AnamnesisID { get; set; }
        [Required, Display(Name = "Naziv anamneze")]
        public string AnamnesisName { get; set; }
    }
}
