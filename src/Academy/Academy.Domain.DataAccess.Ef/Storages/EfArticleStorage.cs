using System;
using System.Collections.Generic;
using System.Linq;
using Academy.Domain.Objects;
using Academy.Domain.Search;

namespace Academy.Domain.DataAccess.Ef.Storages
{
    internal class EfArticleStorage : EfEntityStorage, IArticleStorage
    {
        public EfArticleStorage(AcademyEntities academyEntities)
            : base(academyEntities)
        {
        }

        public Article Get(int articleId)
        {
            return Get(articleId, Entities.Articles);
        }

        public void Add(Article article)
        {
            Resolve(article); // TODO: try avoid resolving
            Add(article, Entities.Articles);
        }

        public void Remove(int articleId)
        {
            Remove(articleId, Entities.Articles);
        }

        public IPageData<Article> GetUserArticles(int userId, int page, int size)
        {
            var query = from article in Entities.Articles
                where
                    article.Authors.Any(x => x.Id == userId)
                select article;
            return GetPage(query, page, size, GetUserArticlesCount(userId));
        }

        public IEnumerable<Article> FindArticles(ArticleSearchCriteria criteria)
        {
            return from article in Entities.Articles
                where
                    article.Title.Contains(criteria.Title) &&
                    article.Description.Contains(criteria.Description) &&
                    (article.Authors.Any(a =>
                        a.Email.Contains(criteria.Author) ||
                        a.FirstName.Contains(criteria.Author) ||
                        a.LastName.Contains(criteria.Author))) &&
                    article.Disciplines.Any(d => criteria.Disciplines.Contains(d.Id))
                select article;
        }

        private int GetUserArticlesCount(int userId)
        {
            return (from article in Entities.Articles
                    where
                        article.Authors.Any(x => x.Id == userId)
                    select article).Count();
        }

        private void Resolve(Article article)
        {
            article.Authors = article.Authors.Select(
                a => Entities.Users.Single(x => x.Email.Equals(a.Email))).ToList();
        }
    }
}
