using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Academy.Domain.Objects;

namespace Academy.Domain.DataAccess
{
    public interface IAnswerStorage
    {
        void Add(Answer answer);

        IEnumerable<Answer> GetUserAnswers(int userId);
    }
}
