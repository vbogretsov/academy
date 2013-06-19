using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Academy.Domain.DataAccess;
using Academy.Domain.Interface;
using Academy.Domain.Objects;

namespace Academy.Domain.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly UserStorage userStorage;

        private readonly DisciplineStorage disciplineStorage;

        private readonly QuestionStorage questionStorage;

        public QuestionService(IStorageFactory storageFactory)
        {
            userStorage = storageFactory.CreateUserStorage();
            disciplineStorage = storageFactory.CreateDisciplineStorage();
            questionStorage = storageFactory.CreateQuestionStorage();
        }

        public void Ask(Question question)
        {
            question.Disciplines = disciplineStorage.Resolve(
                question.Disciplines.Select(x => x.DisciplineId)).ToList();
            question.User = userStorage.Get(question.UserId);
            question.PostedDate = DateTime.Now;
            questionStorage.Add(question);
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
