using System;
using Academy.Domain.Objects;

namespace Academy.Domain.DataAccess
{
    public interface IArticleStorage
    {
        Article Get(int articleId);

        void Add(Article article);

        void Update(Article article);

        void Remove(Article article);

        void Resolve(Article article);
    }
}
