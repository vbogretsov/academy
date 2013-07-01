using System;
using System.Collections.Generic;
using Academy.Domain.Objects;
using Academy.Domain.Search;

namespace Academy.Domain.DataAccess
{
    public interface IQuestionStorage
    {
        Question Get(int questionId);

        void Add(Question question);

        void Remove(int questionId);

        IEnumerable<Question> GetUserQuestions(int userId);

        IPageData<Question> GetUserQuestions(int userId, int page, int size);

        IEnumerable<Question> FindQuestions(QuestionSearchCriteria criteria);
    }
}
