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

        public IPageData<Article> GetUserArticles(int userId, int page, int size)
        {
            return articleStorage.GetUserArticles(userId, page, size);
        }

        public IPageData<Comment> GetUserComments(int userId, int page, int size)
        {
            return commentStorage.GetUserComments(userId, page, size);
        }

        public IPageData<Comment> GetArticleComments(int articleId, int page, int size)
        {
            return commentStorage.GetArticleComments(articleId, page, size);
        }

        //public IEnumerable<Comment> GetUserComments(int userId, int page, int size)
        //{
        //    return commentStorage.GetUserComments(userId, page, size);
        //}

        //public int GetUserCommentsCount(int userId)
        //{
        //    return commentStorage.GetUserCommentsCount(userId);
        //}

        //public IEnumerable<Comment> GetArticleComments(int articleId, int page, int size)
        //{
        //    return commentStorage.GetArticleComments(articleId, page, size);
        //}

        //public int GetArticleCommentsCount(int articleId)
        //{
        //    return commentStorage.GetArticleCommentsCount(articleId);
        //}
    }
}
