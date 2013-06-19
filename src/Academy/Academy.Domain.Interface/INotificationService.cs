using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Domain.Objects;

namespace Academy.Domain.Interface
{
    public interface INotificationService
    {
        void Subscribe(User user);

        IEnumerable<Discipline> GetDisciplines();

        //TODO: add paging
        IEnumerable<ArticleNews> GetArticleNews(User user);

        //TODO: add paging
        IEnumerable<CommentNews> GetCommentNews(User user);

        //TODO: add paging
        IEnumerable<QuestionNews> GetQuestionNews(User user);

        //TODO: add paging
        IEnumerable<QuestionNews> GetAnswerNews(User user);
    }
}
