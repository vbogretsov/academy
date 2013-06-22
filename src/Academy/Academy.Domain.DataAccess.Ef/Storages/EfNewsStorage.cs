using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Academy.Domain.Objects;

namespace Academy.Domain.DataAccess.Ef.Storages
{
    internal abstract class EfNewsStorage<T> : EfEntityStorage, INewsStorage<T> where T : News
    {
        private readonly IDbSet<T> entities;

        protected EfNewsStorage(IDbSet<T> entities, AcademyEntities academyEntities)
            :base(academyEntities)
        {
            this.entities = entities;
        }

        public void Add(T news)
        {
            entities.Add(news);
            Commit();
        }

        public void Read(int newsId)
        {
            var news = entities.SingleOrDefault(x => x.Id == newsId);
            if (news != null)
            {
                news.Read = true;
                Commit();
            }
        }

        public void Remove(int newsId)
        {
            var news = entities.SingleOrDefault(x => x.Id == newsId);
            if (news != null)
            {
                entities.Remove(news);
                Commit();
            }
        }

        public bool Exists(int userId, int entityId)
        {
            return entities.Any(x => x.UserId == userId && x.EntityId == entityId);
        }

        public IEnumerable<T> Get(int userId)
        {
            return entities.Where(x => x.UserId == userId);
        }
    }
}
