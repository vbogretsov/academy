﻿using System;
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

        public IEnumerable<Article> GetUserArticles(int userId)
        {
            return Entities.Articles.Where(x => x.Authors.Any(u => u.Id == userId));
        }

        public IEnumerable<Article> FindArticles(ArticleSearchCriteria criteria)
        {
            return Entities.Articles;
        }

        private void Resolve(Article article)
        {
            article.Authors = article.Authors.Select(
                a => Entities.Users.Single(x => x.Email.Equals(a.Email))).ToList();
        }
    }
}
