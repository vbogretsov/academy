using System;
using System.Collections.Generic;
using System.Linq;
using Academy.Domain.DataAccess;
using Academy.Domain.Interface;
using Academy.Domain.Objects;

namespace Academy.Domain.Services
{
    public class PublicationService : IPublicationService
    {
        private readonly UserStorage userStorage;

        private readonly ArticleStorage articleStorage;

        private readonly DisciplineStorage disciplineStorage;

        private readonly CommentStorage commentStorage;

        public PublicationService(IStorageFactory storageFactory)
        {
            articleStorage = storageFactory.CreateArticleStorage();
            disciplineStorage = storageFactory.CreateDisciplineStorage();
            userStorage = storageFactory.CreateUserStorage();
            commentStorage = storageFactory.CreateCommentStorage();
        }

        public PublicationService(
            UserStorage userStorage,
            ArticleStorage articleStorage,
            DisciplineStorage disciplineStorage)
        {
            this.userStorage = userStorage;
            this.articleStorage = articleStorage;
            this.disciplineStorage = disciplineStorage;
        }

        public void Publish(Article article)
        {
            article.Disciplines = disciplineStorage.Resolve(
                    article.Disciplines.Select(x => x.DisciplineId)).ToList();
            article.Authors = userStorage.Resolve(
                article.Authors.Select(x => x.Email)).ToList();
            articleStorage.Add(article);
        }

        public void Comment(Comment comment)
        {
            comment.PostedDate = DateTime.Now;
            comment.Article = articleStorage.Get(comment.ArticleId);
            commentStorage.Add(comment);
        }

        public Article GetArticle(int articleId)
        {
            return articleStorage.Get(articleId);
        }

        public IEnumerable<Article> GetArticles(User user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Comment> GetComments(User user)
        {
            throw new NotImplementedException();
        }

        // OLD CODE TO BE REMOVED!!!
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
                comment.PostedDate = DateTime.Now;
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
