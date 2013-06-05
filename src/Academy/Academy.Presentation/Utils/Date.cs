using System;
using System.Collections.Generic;
using System.Linq;

namespace Academy.Presentation.Utils
{
    public class Date
    {
        private static readonly IEnumerable<int> days;
        private static readonly Month[] months;
        private static readonly IEnumerable<int> years;

        static Date()
        {
            days = Enumerable.Range(1, 31);
            years = Enumerable.Range(1900, 150);
            months = new []
                {
                    new Month("Januar", 1),
                    new Month("Februar", 2),
                    new Month("Marth", 3),
                    new Month("April", 4),
                    new Month("May", 5),
                    new Month("June", 6),
                    new Month("July", 7),
                    new Month("August", 8),
                    new Month("September", 9),
                    new Month("October", 10),
                    new Month("November", 11),
                    new Month("December", 12)
                };
        }

        public Date()
        {
        }

        public Date(DateTime dateTime)
        {
            Day = dateTime.Day;
            Month = dateTime.Month;
            Year = dateTime.Year;
        }

        public int Day
        {
            get;
            set;
        }

        public int Month
        {
            get;
            set;
        }

        public int Year
        {
            get;
            set;
        }

        public DateTime ToDateTime()
        {
            return new DateTime(Year, Month, Day);
        }

        public static IEnumerable<int> Days
        {
            get
            {
                return days;
            }
        }

        public static IEnumerable<Month> Months
        {
            get
            {
                return months;
            }
        }

        public static IEnumerable<int> Years
        {
            get
            {
                return years;
            }
        }
    }
}