using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Academy.Presentation.ViewModels.Utils
{
    public class DateViewModel
    {
        private static readonly IEnumerable<int> days;
        private static readonly MonthViewModel[] months;
        private static readonly IEnumerable<int> years;

        static DateViewModel()
        {
            days = Enumerable.Range(1, 31);
            years = Enumerable.Range(1900, 150);
            months = new []
                {
                    new MonthViewModel("Januar", 1),
                    new MonthViewModel("Februar", 2),
                    new MonthViewModel("Marth", 3),
                    new MonthViewModel("April", 4),
                    new MonthViewModel("May", 5),
                    new MonthViewModel("June", 6),
                    new MonthViewModel("July", 7),
                    new MonthViewModel("August", 8),
                    new MonthViewModel("September", 9),
                    new MonthViewModel("October", 10),
                    new MonthViewModel("November", 11),
                    new MonthViewModel("December", 12)
                };
        }

        public DateViewModel(DateTime dateTime)
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

        public static IEnumerable<int> Days
        {
            get
            {
                return days;
            }
        }

        public static IEnumerable<MonthViewModel> Months
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
