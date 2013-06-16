using System;
using Academy.Domain.Objects;

namespace Academy.Domain.DataAccess
{
    public abstract class ArticleStorage
    {
        public abstract void Add(Article article);

        public abstract void Update(Article article);

        public abstract void Remove(Article article);

        public abstract void Resolve(Article article);
    }
}
