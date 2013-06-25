using System;

namespace Academy.Domain.Objects
{
    public class Note : Entity
    {
        public string Title
        {
            get;
            set;
        }

        public string Text
        {
            get;
            set;
        }

        public int UserId
        {
            get;
            set;
        }

        public virtual User User
        {
            get;
            set;
        }

        public DateTime PostedDate
        {
            get;
            set;
        }
    }
}
