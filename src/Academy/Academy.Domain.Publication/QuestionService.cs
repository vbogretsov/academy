using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Academy.Domain.Interface;
using Academy.Domain.Objects;

namespace Academy.Domain.Services
{
    public class QuestionService : IQuestionService
    {
        public void Ask(Question question)
        {
            
        }

        public void Answer(Answer answer)
        {
            
        }

        public IEnumerable<Question> GetQuestions(User user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Answer> GetAnswers(User user)
        {
            throw new NotImplementedException();
        }
    }
}
