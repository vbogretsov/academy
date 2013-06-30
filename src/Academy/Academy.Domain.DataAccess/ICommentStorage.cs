using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Domain.Objects;

namespace Academy.Domain.DataAccess
{
    public interface ICommentStorage
    {
        void Add(Comment comment);

        void Remove(int commentId);

        //IEnumerable<Comment> GetUserComments(int userId, int page, int size);

        //int GetUserCommentsCount(int userId);

        //IEnumerable<Comment> GetArticleComments(int articleId, int page, int size);

        //int GetArticleCommentsCount(int articleId);
    }
}
