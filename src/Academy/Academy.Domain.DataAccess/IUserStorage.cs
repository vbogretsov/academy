using System;
using System.Collections.Generic;
using Academy.Domain.Objects;

namespace Academy.Domain.DataAccess
{
    public interface IUserStorage
    {
        void Add(User user);

        void Update(User user);

        void Update();

        void Delete(User user);

        void Delete(string email);

        User Get(string emial);

        User Get(int id);

        bool Contains(string email);

        IEnumerable<User> Resolve(IEnumerable<string> emails);
    }
}
