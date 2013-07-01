using System;
using System.Collections.Generic;
using System.Linq;
using Academy.Domain.Objects;

namespace Academy.Domain.DataAccess.Ef.Storages
{
    internal class EfCommentStorage : EfEntityStorage, ICommentStorage
    {
        public EfCommentStorage(AcademyEntities academyEntities)
            :base(academyEntities)
        {
        }

        public void Add(Comment comment)
        {
            Add(comment, Entities.Comments);
        }

        public void Remove(int commentId)
        {
            Remove(commentId, Entities.Comments);
        }

        public IPageData<Comment> GetUserComments(int userId, int page, int size)
        {
            var query = GetUserCommentsQuery(userId);
            return GetPage(query, page, size, GetUserCommentsCount(userId));
        }

        public int GetUserCommentsCount(int userId)
        {
            return GetUserCommentsQuery(userId).Count();
        }

        public IPageData<Comment> GetArticleComments(int articleId, int page, int size)
        {
            var query = GetArticleCommentsQuery(articleId);
            return GetPage(query, page, size, GetArticleCommentsCount(articleId));
        }

        private int GetArticleCommentsCount(int articleId)
        {
            return GetArticleCommentsQuery(articleId).Count();
        }

        private IEnumerable<Comment> GetUserCommentsQuery(int userId)
        {
            return from comment in Entities.Comments
                where
                    comment.UserId == userId
                select comment;
        }

        private IEnumerable<Comment> GetArticleCommentsQuery(int articleId)
        {
            return from comment in Entities.Comments
                where
                    comment.ArticleId == articleId
                select comment;
        }
    }
}
