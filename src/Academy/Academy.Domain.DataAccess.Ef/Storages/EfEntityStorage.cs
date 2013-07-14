using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Academy.Domain.Objects;

namespace Academy.Domain.DataAccess.Ef.Storages
{
    internal abstract class EfEntityStorage
    {
        private readonly AcademyEntities academyEntities;

        protected EfEntityStorage(AcademyEntities academyEntities)
        {
            this.academyEntities = academyEntities;
        }

        protected void Add<T>(T entity, IDbSet<T> entities)
            where T : Entity
        {
            entities.Add(entity);
            Commit();
        }

        protected void Remove<T>(int entityId, IDbSet<T> entities)
            where T : Entity
        {
            T entity = entities.SingleOrDefault(x => x.Id == entityId);
            if (entity != null)
            {
                entities.Remove(entity);
                Commit();
            }
        }

        protected void Commit()
        {
            academyEntities.SaveChanges();
        }

        protected T Get<T>(int entityId, IDbSet<T> entities)
            where T : Entity
        {
            return entities.SingleOrDefault(x => x.Id == entityId);
        }

        protected IPageData<T> GetPage<T>(
            IEnumerable<T> items,
            int page,
            int size,
            int totalCount)
        {
            var data = items.Skip((page - 1)*size).Take(size).ToList();
            int rem = totalCount % size;
            int pagesCount = rem > 0 ? (totalCount/size) + 1 : totalCount/size;
            return new PageData<T>(data, page, size, pagesCount);
        }

        protected AcademyEntities Entities
        {
            get
            {
                return academyEntities;
            }
        }
    }
}
