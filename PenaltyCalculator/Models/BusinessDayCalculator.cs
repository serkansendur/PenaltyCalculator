using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace PenaltyCalculator.Models
{
    public class BusinessDayCalculator
    {
        public static int GetNumberOfWorkingDays(DateTime start, DateTime stop,Weekdays weekendsOfCountry)
        {
            int days = 0;
            while (start <= stop)
            {
                if (IsWeekDay( start.DayOfWeek,weekendsOfCountry))
                {
                    ++days;
                }
                start = start.AddDays(1);
            }
            return days;
        }

        public static bool IsWeekDay(DayOfWeek dayOfWeek, Weekdays weekendsOfCountry)
        {
            // get the matching flag enum
            Weekdays day = (Weekdays) Enum.Parse(typeof(Weekdays),dayOfWeek.ToString());
            if ((weekendsOfCountry & day) == day) 
             {
                // this is a weekend for that country
                 return false;
             }
            // this is a week day for that country
            return true;
        }

        public static string GetWeekendDays(Weekdays weekendsOfCountry)
        {
            CommaDelimitedStringCollection names = new CommaDelimitedStringCollection();
           
            foreach (Weekdays day in Enum.GetValues(typeof(Weekdays)))
            {
                if ((weekendsOfCountry & day) == day)
                {
                    names.Add(day.ToString());
                }
            }
            return names.ToString();
        }
    }
}