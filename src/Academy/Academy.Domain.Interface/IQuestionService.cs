using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Domain.Objects;

namespace Academy.Domain.Interface
{
    public interface IQuestionService
    {
        void Ask(Question question);

        void Answer(Answer answer);

        //TODO: add paging
        IEnumerable<Question> GetQuestions(User user);

        IEnumerable<Answer> GetAnswers(User user);
    }
}
