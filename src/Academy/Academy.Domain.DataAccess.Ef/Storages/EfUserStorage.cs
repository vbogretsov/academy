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
    internal class EfUserStorage : IUserStorage
    {
        private readonly AcademyEntities academyEntities;

        public EfUserStorage(AcademyEntities academyEntities)
        {
            this.academyEntities = academyEntities;
        }

        public void Add(User user)
        {
            academyEntities.Users.Add(user);
            academyEntities.SaveChanges();
        }

        public void Update(User user)
        {
            academyEntities.Users.Attach(user);
            academyEntities.Entry(user).State = EntityState.Modified;
            academyEntities.SaveChanges();
        }

        public void Update()
        {
            academyEntities.SaveChanges();
        }

        public void Delete(User user)
        {
            academyEntities.Users.Remove(user);
            academyEntities.SaveChanges();
        }

        public void Delete(string email)
        {
            throw new NotImplementedException();
        }

        public User Get(string emial)
        {
            if (String.IsNullOrEmpty(emial))
            {
                throw new ArgumentNullException("emial");
            }
            return academyEntities.Users.SingleOrDefault(x => x.Email == emial);
        }

        public User Get(int id)
        {
            return academyEntities.Users.SingleOrDefault(x => x.UserId == id);
        }

        public bool Contains(string email)
        {
            return Get(email) != null;
        }

        public IEnumerable<User> Resolve(IEnumerable<string> emails)
        {
            return emails.Select(Get).Where(x => x != null);
        }
    }
}
