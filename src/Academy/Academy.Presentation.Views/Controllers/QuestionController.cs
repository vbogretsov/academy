using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Academy.Presentation.ViewModels;
using Academy.Presentation.ViewModels.Mappers;

namespace Academy.Presentation.Views.Controllers
{
    public class QuestionController : AcademyController
    {
        [HttpPost]
        public ActionResult Ask(QuestionViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var question = QuestionMapper.Map(viewModel);
                AcademyContext.QuestionService.Ask(question);
                AcademyContext.NotificationService.NotifyAboutNewQuestion(question);
            }
            return GetUserQuestionsResult();
        }

        [HttpPost]
        public ActionResult Answer(AnswerViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var answer = AnswerMapper.Map(viewModel);
                answer.UserId = AcademyContext.Account.GetCurrentUser().Id;
                AcademyContext.QuestionService.Answer(answer);
                AcademyContext.NotificationService.NotifyAboutNewAnswer(answer);
                var question = AcademyContext.QuestionService.GetQuestion(viewModel.QuestionId);
                return View("RenderTemplates/AnswersView", QuestionMapper.Map(question));
            }
            return GetUserQuestionsResult(); //TODO: add error handling
        }

        [HttpGet]
        public ActionResult GetQuestion(int questionId)
        {
            var question = AcademyContext.QuestionService.GetQuestion(questionId);
            return View("RenderTemplates/QuestionView", QuestionMapper.Map(question));
        }

        [HttpGet]
        public ActionResult GetUserQuestions()
        {
            return GetUserQuestionsResult();
        }

        [HttpGet]
        public ActionResult GetUserAnswers()
        {
            var user = AcademyContext.Account.GetCurrentUser();
            return View(UserMapper.Map(user));
        }

        [HttpGet]
        private ActionResult GetUserQuestionsResult()
        {
            var user = AcademyContext.Account.GetCurrentUser();
            var disciplines = AcademyContext.NotificationService.GetDisciplines();
            ViewBag.Disciplines = disciplines.Select(DisciplineMapper.Map);
            return View("GetUserQuestions", UserMapper.Map(user));
        }
    }
}
