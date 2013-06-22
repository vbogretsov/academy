using System;
using System.Collections.Generic;
using Academy.Domain.Objects;

namespace Academy.Domain.DataAccess
{
    public interface IUserStorage
    {
        void Add(User user);

        void Update(User user);

        void UpdateDisciplines(int userId, IEnumerable<int> disciplineIds);

        void Remove(int userId);

        void Remove(string email);

        User Get(string emial);

        User Get(int id);

        IEnumerable<User> GetByDiscipline(int disciplineId);

        bool Exists(string email);
    }
}
