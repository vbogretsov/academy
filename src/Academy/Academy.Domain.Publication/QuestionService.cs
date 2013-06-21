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
        private readonly IUserStorage userStorage;

        private readonly IDisciplineStorage disciplineStorage;

        private readonly IQuestionStorage questionStorage;

        private readonly IAnswerStorage answerStorage;

        public QuestionService(IStorageFactory storageFactory)
        {
            userStorage = storageFactory.CreateUserStorage();
            disciplineStorage = storageFactory.CreateDisciplineStorage();
            questionStorage = storageFactory.CreateQuestionStorage();
            answerStorage = storageFactory.CreateAnswerStorage();
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
            answer.User = userStorage.Get(answer.UserId);
            answer.Question = questionStorage.Get(answer.QuestionId);
            answer.PostedDate = DateTime.Now;
            answerStorage.Add(answer);
        }

        public Question GetQuestion(int questionId)
        {
            return questionStorage.Get(questionId);
        }

        //TODO: add paging
        public IEnumerable<Question> GetQuestions(User user)
        {
            throw new NotImplementedException();
        }

        //TODO: add paging
        public IEnumerable<Answer> GetAnswers(User user)
        {
            throw new NotImplementedException();
        }
    }
}
