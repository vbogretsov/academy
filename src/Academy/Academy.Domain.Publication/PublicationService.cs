using System;
using System.Collections.Generic;
using System.Linq;
using Academy.Domain.DataAccess;
using Academy.Domain.Objects;

namespace Academy.Domain.Services
{
    public class PublicationService
    {
        private readonly UserStorage userStorage;

        private readonly ArticleStorage articleStorage;

        private readonly DisciplineStorage disciplineStorage;

        public PublicationService(
            UserStorage userStorage,
            ArticleStorage articleStorage,
            DisciplineStorage disciplineStorage)
        {
            this.userStorage = userStorage;
            this.articleStorage = articleStorage;
            this.disciplineStorage = disciplineStorage;
        }

        public void PublishArticle(User author, Article article)
        {
            try
            {
                Resolve(author, article);
                articleStorage.Add(article);
            }
            catch (Exception e)
            {
                var s = e.Message;
            }
        }

        public void CommentArticle(User author, Article article, Comment comment)
        {
            var resolvedArticle = articleStorage.Get(article.ArticleId);
            if (resolvedArticle != null)
            {
                comment.User = author;
                comment.Article = resolvedArticle;
                comment.CreationDate = DateTime.Now;
                resolvedArticle.Comments.Add(comment);
                articleStorage.Update(article);
            }
        }

        private void Resolve(User author, Article article)
        {
            IEnumerable<User> users = userStorage.Resolve(
                article.Authors.Select(x => x.Email));
            article.Authors = (new[] {author}).Union(users).ToList();
            article.Disciplines = disciplineStorage.Resolve(
                    article.Disciplines.Select(x => x.DisciplineId)).ToList();
        }
    }
}
