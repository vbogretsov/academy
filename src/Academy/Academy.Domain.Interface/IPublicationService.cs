using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Domain.Objects;

namespace Academy.Domain.Interface
{
    public interface IPublicationService
    {
        void Publish(Article article);

        void Comment(Comment comment);

        Article GetArticle(int articleId);

        //TODO: add paging
        IEnumerable<Article> GetArticles(User user);

        //TODO: add paging
        IEnumerable<Comment> GetComments(User user);
    }
}
