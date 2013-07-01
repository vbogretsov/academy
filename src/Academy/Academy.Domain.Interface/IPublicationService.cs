using System;
using System.Collections.Generic;
using Academy.Domain.DataAccess;
using Academy.Domain.Objects;

namespace Academy.Domain.Interface
{
    public interface IPublicationService
    {
        void Publish(Article article);

        void Comment(Comment comment);

        Article GetArticle(int articleId);

        IPageData<Article> GetUserArticles(int userId, int page, int size);

        IPageData<Comment> GetUserComments(int userId, int page, int size);

        //IEnumerable<Comment> GetUserComments(int userId, int page, int size);

        //int GetUserCommentsCount(int userId);

        //IEnumerable<Comment> GetArticleComments(int articleId, int page, int size);

        //int GetArticleCommentsCount(int articleId);
    }
}
