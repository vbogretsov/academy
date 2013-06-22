﻿using System;
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

        protected AcademyEntities Entities
        {
            get
            {
                return academyEntities;
            }
        }
    }
}
