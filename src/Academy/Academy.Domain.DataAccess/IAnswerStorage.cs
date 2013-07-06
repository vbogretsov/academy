using System;
using System.Collections.Generic;
using Academy.Domain.Objects;

namespace Academy.Domain.DataAccess
{
    public interface IAnswerStorage
    {
        void Add(Answer answer);

        void Remove(int answerId);

        IPageData<Answer> GetUserAnswers(int userId, int page, int size);

        IPageData<Answer> GetQuestionAnswers(int questionId, int page, int size);
    }
}
