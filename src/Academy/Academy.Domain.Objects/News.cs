using System;

namespace Academy.Domain.Objects
{
    public abstract class News : Entity
    {
        public int UserId
        {
            get;
            set;
        }

        public int EntityId
        {
            get;
            set;
        }

        public bool Read
        {
            get;
            set;
        }
    }
}
