using System;
using Academy.Domain.Objects;

namespace Academy.Domain.DataAccess
{
    public abstract class UserStorage
    {
        public abstract void Add(User user);

        public abstract void Update(User user);

        public abstract void Update();

        public abstract void Delete(User user);

        public abstract void Delete(string email);

        public abstract User Get(string emial);

        public abstract bool Contains(string email);
    }
}
