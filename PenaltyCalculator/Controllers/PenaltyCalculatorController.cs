using PenaltyCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PenaltyCalculator.Controllers
{
    public class PenaltyCalculatorController : Controller
    {
        private PenaltyCalculatorContext db = new PenaltyCalculatorContext();
        // GET: PenaltyCalculator
        public ActionResult Index()
        {
            Penalty penalty = new Penalty();
            penalty.CheckoutDate = DateTime.Today;
            penalty.ReturnDate = DateTime.Today;
            penalty.CountryList = db.Countries.Select(m => new SelectListItem
            {
                Text = m.Name 
                ,
                Value = m.ID.ToString()
            }).AsEnumerable<SelectListItem>();
            return View(penalty);
        }
        [HttpPost]
        public ActionResult Index(Penalty penalty)
        {
            penalty.CountryList = db.Countries.Select(m => new SelectListItem
            {
                Text = m.Name
                ,
                Value = m.ID.ToString()
            }).AsEnumerable<SelectListItem>();
            var country = db.Countries.Find(penalty.CountryID);
            // include method should be used insted of an explicit find.
            penalty.Currency = db.Currencies.Find(country.CurrencyID).Name;
           penalty.CalculatedBusinessDays = BusinessDayCalculator.GetNumberOfWorkingDays
               (penalty.CheckoutDate, penalty.ReturnDate, country.weekends);
           
            if(penalty.CalculatedBusinessDays > 10)
            {
                var calculatedPenalty = (penalty.CalculatedBusinessDays - 10) * 5;
                penalty.CalculatedPenalty = calculatedPenalty;
            }
            return View(penalty);
        }
        
    }
}