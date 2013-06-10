using System;
using System.Data;
using System.Linq;
using Academy.Domain.Objects;

namespace Academy.Domain.DataAccess.Ef.Storages
{
    internal class EfUserStorage : UserStorage
    {
        private readonly AcademyEntities academyEntities;

        public EfUserStorage(AcademyEntities academyEntities)
        {
            this.academyEntities = academyEntities;
        }

        public override void Add(User user)
        {
            academyEntities.Users.Add(user);
            academyEntities.SaveChanges();
        }

        public override void Update(User user)
        {
            // TODO: update single user or remove this method.
            academyEntities.SaveChanges();
        }

        public override void Update()
        {
            academyEntities.SaveChanges();
        }

        public override void Delete(User user)
        {
            academyEntities.Users.Remove(user);
            academyEntities.SaveChanges();
        }

        public override void Delete(string email)
        {
            throw new NotImplementedException();
        }

        public override User Get(string emial)
        {
            if (String.IsNullOrEmpty(emial))
            {
                throw new ArgumentNullException("emial");
            }
            return academyEntities.Users.SingleOrDefault(x => x.Email == emial);
        }

        public override bool Contains(string email)
        {
            return Get(email) != null;
        }
    }
}
