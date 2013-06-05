using System;

namespace Academy.Presentation.Utils
{
    public class Month
    {
        public Month(string name, int number)
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