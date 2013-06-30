using System;
using System.Collections.Generic;
using Academy.Domain.Objects;

namespace Academy.Domain.DataAccess
{
    public interface IAnswerStorage
    {
        void Add(Answer answer);

        void Remove(int answerId);

        IEnumerable<Answer> GetUserAnswers(int userId);
    }
}
