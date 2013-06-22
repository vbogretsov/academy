using System;
using System.Collections.Generic;
using Academy.Domain.Objects;

namespace Academy.Domain.DataAccess
{
    public interface IArticleStorage
    {
        Article Get(int articleId);

        void Add(Article article);

        void Remove(int articleId);

        IEnumerable<Article> GetUserArticles(int userId);
    }
}
