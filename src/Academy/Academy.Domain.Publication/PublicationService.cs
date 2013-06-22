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
        private readonly IArticleStorage articleStorage;

        private readonly IDisciplineStorage disciplineStorage;

        private readonly ICommentStorage commentStorage;

        public PublicationService(IDataContext dataContext)
        {
            articleStorage = dataContext.ArticleStorage;
            disciplineStorage = dataContext.DisciplineStorage;
            commentStorage = dataContext.CommentStorage;
        }

        public PublicationService(
            IUserStorage userStorage,
            IArticleStorage articleStorage,
            IDisciplineStorage disciplineStorage)
        {
            this.articleStorage = articleStorage;
            this.disciplineStorage = disciplineStorage;
        }

        public void Publish(Article article)
        {
            article.Disciplines = disciplineStorage.Get(
                article.Disciplines.Select(x => x.Id)).ToList();
            articleStorage.Add(article);
        }

        public void Comment(Comment comment)
        {
            comment.PostedDate = DateTime.Now;
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
    }
}
