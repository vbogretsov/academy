using System;
using System.Collections.Generic;
using Academy.Domain.Objects;
using Academy.Domain.Search;

namespace Academy.Domain.DataAccess
{
    public interface IArticleStorage
    {
        Article Get(int articleId);

        void Add(Article article);

        void Remove(int articleId);

        IEnumerable<Article> GetUserArticles(int userId);

        IEnumerable<Article> FindArticles(ArticleSearchCriteria criteria);
    }
}
