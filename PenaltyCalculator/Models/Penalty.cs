using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PenaltyCalculator.Models
{
    [NotMapped]
    public class Penalty
    {
        [DataType(DataType.Date)]
        public DateTime CheckoutDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReturnDate { get; set; }
        public int CountryID { get; set; }
        public decimal CalculatedPenalty { get; set; }
        public int CalculatedBusinessDays { get; set; }
        public IEnumerable<SelectListItem> CountryList { get; set; }
        public string Currency { get; set; }
    }
}