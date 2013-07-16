using System;
using System.Collections.Generic;
using System.Linq;

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
                    new MonthViewModel(1),
                    new MonthViewModel(2),
                    new MonthViewModel(3),
                    new MonthViewModel(4),
                    new MonthViewModel(5),
                    new MonthViewModel(6),
                    new MonthViewModel(7),
                    new MonthViewModel(8),
                    new MonthViewModel(9),
                    new MonthViewModel(10),
                    new MonthViewModel(11),
                    new MonthViewModel(12)
                };
        }

        public DateViewModel()
        {
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
