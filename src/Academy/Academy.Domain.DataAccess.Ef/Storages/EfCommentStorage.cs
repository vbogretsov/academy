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
            //Entities.Comments.Add(comment);
            //Entities.SaveChanges();

            //comment.Article = articleStorage.Get(comment.ArticleId);

            Add(comment, Entities.Comments);
        }

        public void Remove(int commentId)
        {
            Remove(commentId, Entities.Comments);
        }

        public IEnumerable<Comment> GetUserComments(int userId)
        {
            return Entities.Comments.Where(x => x.UserId == userId);
        }

        //public void Remove(Comment comment)
        //{
        //    Entities.Comments.Remove(comment);
        //}
    }
}
