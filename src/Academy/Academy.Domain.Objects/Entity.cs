using System;

namespace Academy.Domain.Objects
{
    public abstract class Entity : IEntity
    {
        public int Id
        {
            get;
            set;
        }
    }
}
