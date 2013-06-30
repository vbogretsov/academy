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

        IPageData<Article> GetUserArticles(int userId, int page, int size);

        IEnumerable<Article> FindArticles(ArticleSearchCriteria criteria);
    }
}
