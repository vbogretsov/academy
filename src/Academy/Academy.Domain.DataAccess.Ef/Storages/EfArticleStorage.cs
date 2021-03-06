﻿using System;
using System.Collections.Generic;
using System.Linq;
using Academy.Domain.DataAccess.Ef.Search;
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
            var query = GetUserArticlesQuery(userId);
            return GetPage(query, page, size, GetUserArticlesCount(userId));
        }

        public IEnumerable<Article> FindArticles(ArticleSearchCriteria criteria)
        {
            var filter = new ArticleFilter(criteria);
            return filter.Select(Entities.Articles);
            //return criteria.Disciplines != null
            //    ? from article in Entities.Articles
            //      where
            //          article.Title.Contains(criteria.Title) &&
            //          article.Text.Contains(criteria.Description) &&
            //          (article.Authors.Any(a =>
            //              a.Email.Contains(criteria.Author) ||
            //              a.FirstName.Contains(criteria.Author) ||
            //              a.LastName.Contains(criteria.Author))) &&
            //          article.Disciplines.Any(d => criteria.Disciplines.Contains(d.Id))
            //      orderby article.PostedDate descending
            //      select article
            //    : from article in Entities.Articles
            //      where
            //          article.Title.Contains(criteria.Title) &&
            //          article.Text.Contains(criteria.Description) &&
            //          (article.Authors.Any(a =>
            //              a.Email.Contains(criteria.Author) ||
            //              a.FirstName.Contains(criteria.Author) ||
            //              a.LastName.Contains(criteria.Author)))
            //      orderby article.PostedDate descending
            //      select article;
        }

        private int GetUserArticlesCount(int userId)
        {
            return Entities.Articles.Count(x => x.Authors.Any(a => a.Id == userId));
        }

        private IEnumerable<Article> GetUserArticlesQuery(int userId)
        {
            return from article in Entities.Articles
                where
                    article.Authors.Any(x => x.Id == userId)
                orderby
                   article.PostedDate descending
                select article;
        }

        private void Resolve(Article article)
        {
            article.Authors = article.Authors.Select(
                a => Entities.Users.Single(x => x.Email.Equals(a.Email))).ToList();
        }
    }
}
