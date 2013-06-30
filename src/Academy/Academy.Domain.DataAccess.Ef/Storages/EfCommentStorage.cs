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
            var query = from comment in Entities.Comments
                where
                    comment.UserId == userId
                select comment;
            return GetPage(query, page, size, GetUserCommentsCount(userId));
        }

        public int GetUserCommentsCount(int userId)
        {
            var query = from comment in Entities.Comments
                where
                    comment.UserId == userId
                select comment;
            return query.Count();
        }

        public IPageData<Comment> GetArticleComments(int articleId, int page, int size)
        {
            var query = from comment in Entities.Comments
                where
                    comment.ArticleId == articleId
                select comment;
            return GetPage(query, page, size, GetArticleCommentsCount(articleId));
        }

        public int GetArticleCommentsCount(int articleId)
        {
            var query = from comment in Entities.Comments
                where
                    comment.ArticleId == articleId
                select comment;
            return query.Count();
        }
    }
}
