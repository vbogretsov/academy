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
        private readonly IDisciplineStorage disciplineStorage;

        private readonly IQuestionStorage questionStorage;

        private readonly IAnswerStorage answerStorage;

        public QuestionService(IDataContext context)
        {
            disciplineStorage = context.DisciplineStorage;
            questionStorage = context.QuestionStorage;
            answerStorage = context.AnswerStorage;
        }

        public void Ask(Question question)
        {
            question.Disciplines = disciplineStorage.Get(
                question.Disciplines.Select(x => x.Id)).ToList();
            question.PostedDate = DateTime.Now;
            questionStorage.Add(question);
        }

        public void Answer(Answer answer)
        {
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
