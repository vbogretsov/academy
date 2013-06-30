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
            try
            {
                entities.Add(entity);
                Commit();
            }
            catch (Exception exception)
            {
                // TODO: process exception
                var s = exception.Message;
            }
        }

        protected void Remove<T>(int entityId, IDbSet<T> entities)
            where T : Entity
        {
            T entity = entities.SingleOrDefault(x => x.Id == entityId);
            if (entity != null)
            {
                try
                {
                    entities.Remove(entity);
                    Commit();
                }
                catch (Exception exception)
                {
                    
                }
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
            return new PageData<T>(data, page, totalCount / size + 1);
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
