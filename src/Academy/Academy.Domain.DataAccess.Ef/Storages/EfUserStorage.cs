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
        private const string UpdateUserQuery =
            @"
                update academy_User
                    set
                        Email = {0},
                        FirstName = {1},
                        LastName = {2},
                        University = {3},
                        BirthDate = {4},
                        LastAccessDate = {5},
                        PhotoFileName = {6}
                    where UserId = {7}
            ";


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
            Entities.Database.ExecuteSqlCommand(
                UpdateUserQuery,
                user.Email,
                user.FirstName,
                user.LastName,
                user.University,
                user.BirthDate,
                user.LastAccessDate,
                user.PhotoFileName,
                user.Id);
        }

        public void UpdateDisciplines(int userId, IEnumerable<int> disciplineIds)
        {
            var user = Entities.Users.Find(userId);
            if (user.Disciplines != null)
            {
                user.Disciplines.Clear();
            }
            user.Disciplines = new List<Discipline>();
            foreach (var disciplineId in disciplineIds)
            {
                var discipline = Entities.Disciplines.Find(disciplineId);
                user.Disciplines.Add(discipline);
            }
            Commit();
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
    }
}
