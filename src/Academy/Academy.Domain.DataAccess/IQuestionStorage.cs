using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Academy.Domain.Objects;

namespace Academy.Domain.DataAccess
{
    public interface IQuestionStorage
    {
        Question Get(int questionId);

        void Add(Question question);

        IEnumerable<Question> GetUserQuestions(int userId);
    }
}
