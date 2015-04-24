using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PenaltyCalculator.Models
{
    public class Country 
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int CurrencyID { get; set; }
        public Currency Currency { get; set; }
        // Weekdays is a flag enum, so the binar or will be used to combine them as follows
        //Weekdays weekends = Weekdays.Saturday | Weekdays.Sundays;
       public Weekdays weekends { get; set; }
    }
}