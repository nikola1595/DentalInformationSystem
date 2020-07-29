﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DentalInformationSystem.Models
{
    public class Procurement
    {
        [Key,Display(Name ="Redni broj nabavke")]
        public int ProcurmentID { get; set; }
        [Required,DataType(DataType.Date),Display(Name ="Datum nabavke")]
        public DateTime ProcurmentDate { get; set; }
        public Supplier Supplier { get; set; }
        [Required, Display(Name ="Ime dobavljača")]
        public int SupplierID { get; set; }
        [Required, Display(Name = "Račun-otpremnica No.")]
        public string DeliveryNoteNumber { get; set; }
        [Required, Display(Name = "Naziv robe")]
        public string MerchandiseName { get; set; }
        [Required,Display(Name = "j/m")]
        public string MeasureUnit { get; set; }
        [Required,Display(Name = "Količina")]
        public int Quantity { get; set; }
        [Required,Display(Name = "Ukupno za plaćanje")]
        public int TotalPrice { get; set; }


    }
}
