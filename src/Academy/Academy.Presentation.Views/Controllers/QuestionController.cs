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
                AcademyContext.QuestionService.Ask(QuestionMapper.Map(viewModel));
            }
            return GetUserQuestionsResult();
        }

        [HttpPost]
        public ActionResult Answer(AnswerViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                viewModel.AuthorId = AcademyContext.Account.GetCurrentUser().UserId;
                AcademyContext.QuestionService.Answer(AnswerMapper.Map(viewModel));
                var question = AcademyContext.QuestionService.GetQuestion(viewModel.QuestionId);
                return View("RenderTemplates/AnswersView", QuestionMapper.Map(question));
            }
            return GetUserQuestionsResult(); //TODO: add error handling
        }

        public ActionResult GetUserQuestions()
        {
            return GetUserQuestionsResult();
        }

        public ActionResult GetUserAnswers()
        {
            var user = AcademyContext.Account.GetCurrentUser();
            return View(UserMapper.Map(user));
        }

        private ActionResult GetUserQuestionsResult()
        {
            var user = AcademyContext.Account.GetCurrentUser();
            var disciplines = AcademyContext.NotificationService.GetDisciplines();
            ViewBag.Disciplines = disciplines.Select(DisciplineMapper.Map);
            return View("GetUserQuestions", UserMapper.Map(user));
        }
    }
}
