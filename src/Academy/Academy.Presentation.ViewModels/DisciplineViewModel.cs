using System;

namespace Academy.Presentation.ViewModels
{
    public class DisciplineViewModel : EntityViewModel
    {
        public override bool Equals(object obj)
        {
            bool result = false;
            if (obj != null)
            {
                DisciplineViewModel other = obj as DisciplineViewModel;
                if (other != null)
                {
                    result = Id == other.Id;
                }
            }
            return result;
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public override string ToString()
        {
            return Name;
        }

        public int ParentId
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }
    }
}
