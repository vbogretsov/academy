using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using Academy.Utils.Collections;
using Academy.Domain.Objects;

namespace Academy.Domain.DataAccess.Ef.Storages
{
    internal class EfUserStorage : EfEntityStorage, IUserStorage
    {
        public EfUserStorage(AcademyEntities academyEntities)
            :base(academyEntities)
        {
        }

        public void Add(User user)
        {
            Add(user, Entities.Users);
        }

        public void Update(User user)
        {
            Entities.Users.Attach(user);
            Entities.Entry(user).State = EntityState.Modified;
            Entities.SaveChanges();
        }

        public void UpdateDisciplines(int userId, IEnumerable<int> disciplineIds)
        {
            var user = Get(userId);
            user.Disciplines = new List<Discipline>();
            foreach (var disciplineId in disciplineIds)
            {
                var discipline = Entities.Disciplines.Single(x => x.Id == disciplineId);
                user.Disciplines.Add(discipline);
            }
        }

        public void Update()
        {
            Entities.SaveChanges();
        }

        public void Remove(int userId)
        {
            Remove(userId, Entities.Users);
        }

        public void Remove(string email)
        {
            throw new NotImplementedException();
        }

        public User Get(int userId)
        {
            return Get(userId, Entities.Users);
        }

        public User Get(string emial)
        {
            if (String.IsNullOrEmpty(emial))
            {
                throw new ArgumentNullException("emial");
            }
            return Entities.Users.SingleOrDefault(x => x.Email.Equals(emial));
        }

        public IEnumerable<User> GetByDiscipline(int disciplineId)
        {
            return Entities.Users.Where(
                u => u.Disciplines.Any(d => d.Id == disciplineId));
        }

        public bool Exists(string email)
        {
            return Entities.Users.Any(x => x.Email.Equals(email));
        }

        //public IEnumerable<User> Resolve(IEnumerable<string> emails)
        //{
        //    return emails.Select(Get).Where(x => x != null);
        //}
    }
}
