using System;

namespace Academy.Presentation.ViewModels.Utils
{
    public class MonthViewModel
    {
         public MonthViewModel(string name, int number)
        {
            Name = name;
            Number = number;
        }

        public string Name
        {
            get;
            private set;
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
