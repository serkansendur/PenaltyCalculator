using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;

using System.Web.Mvc;

namespace PenaltyCalculator.Models
{
    public class PenaltyCalculatorInitializer : DropCreateDatabaseAlways<PenaltyCalculatorContext>
    {
        protected override void Seed(PenaltyCalculatorContext context)
        {
            context.Currencies.AddOrUpdate(new Currency
            {
                ID = 1,
                Name = "Turkish Liras"
            },
            new Currency
            {
                ID = 2,
                Name = "United States Dollars"
            });
            context.Countries.AddOrUpdate(
                new Country { ID = 1, Name = "Turkey", CurrencyID = 1 ,
                weekends = Weekdays.Sunday | Weekdays.Saturday
                },
                 new Country { ID = 2, Name = "United States", CurrencyID = 2 ,
                 // here I am setting the US weekends somedays other than the regular weekends to prove the calculation
                 weekends = Weekdays.Monday | Weekdays.Wednesday
                 }
                );
            base.Seed(context);
        }
    }

}