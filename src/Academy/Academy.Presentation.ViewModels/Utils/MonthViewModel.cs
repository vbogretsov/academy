using System;
using Academy.Resources;

namespace Academy.Presentation.ViewModels.Utils
{
    public class MonthViewModel
    {
        private readonly string name;

        public MonthViewModel(int number)
        {
            Number = number;
            name = String.Format("month{0}", number);
        }

        //public MonthViewModel(string name, int number)
        //{
        //    Name = name;
        //    Number = number;
        //}

        public string Name
        {
            get
            {
                return Localization.GetString(name);
            }
        }

        public int Number
        {
            get;
            private set;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
