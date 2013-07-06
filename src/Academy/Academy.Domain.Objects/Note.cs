using System;

namespace Academy.Domain.Objects
{
    public class Note : TitledPost
    {
        public int UserId
        {
            get;
            set;
        }

        public User User
        {
            get;
            set;
        }
    }
}
