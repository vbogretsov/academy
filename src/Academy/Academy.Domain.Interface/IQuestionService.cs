using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Domain.DataAccess;
using Academy.Domain.Objects;

namespace Academy.Domain.Interface
{
    public interface IQuestionService
    {
        void Ask(Question question);

        void Answer(Answer answer);

        Question GetQuestion(int questionId);

        IPageData<Question> GetUserQuestions(int userId, int page, int size);

        IPageData<Answer> GetUserAnswers(int userId, int page, int size);

        IPageData<Answer> GetQuestionAnswers(int questionId, int page, int size);
    }
}
