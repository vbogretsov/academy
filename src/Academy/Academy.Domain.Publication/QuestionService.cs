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

        public IPageData<Question> GetUserQuestions(int userId, int page, int size)
        {
            return questionStorage.GetUserQuestions(userId, page, size);
        }

        public IPageData<Answer> GetUserAnswers(int userId, int page, int size)
        {
            return answerStorage.GetUserAnswers(userId, page, size);
        }

        public IPageData<Answer> GetQuestionAnswers(int questionId, int page, int size)
        {
            return answerStorage.GetQuestionAnswers(questionId, page, size);
        }
    }
}
