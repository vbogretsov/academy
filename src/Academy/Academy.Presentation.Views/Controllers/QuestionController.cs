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
                //var question = QuestionMapper.Map(viewModel);
                //AcademyContext.QuestionService.Ask(question);
                //AcademyContext.NotificationService.NotifyAboutNewQuestion(question);
                Service.Ask(QuestionMapper.Map(viewModel));
            }
            return GetUserQuestionsResult();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult RemoveQuestion(int id)
        {
            //AcademyContext.AdministrationService.RemoveQuestion(id);
            Service.RemoveQuestion(id);
            return null;
        }

        [HttpPost]
        public ActionResult Answer(AnswerViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                //var answer = AnswerMapper.Map(viewModel);
                //answer.UserId = AcademyContext.Account.GetCurrentUser().Id;
                //AcademyContext.QuestionService.Answer(answer);
                //AcademyContext.NotificationService.NotifyAboutNewAnswer(answer);
                Service.Answer(AnswerMapper.Map(viewModel));
                var question = Service.GetQuestion(viewModel.QuestionId);
                //var question = AcademyContext.QuestionService.GetQuestion(viewModel.QuestionId);
                return View("RenderTemplates/AnswersView", QuestionMapper.Map(question));
            }
            return GetUserQuestionsResult(); //TODO: add error handling
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult RemoveAnswer(int id)
        {
            //AcademyContext.AdministrationService.RemoveAnswer(id);
            Service.RemoveAnswer(id);
            return null;
        }

        [HttpGet]
        public ActionResult GetQuestion(int questionId)
        {
            //var question = AcademyContext.QuestionService.GetQuestion(questionId);
            var question = Service.GetQuestion(questionId);
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
            //var user = AcademyContext.Account.GetCurrentUser();
            return View(UserMapper.Map(CurrentUser));
        }

        [HttpGet]
        private ActionResult GetUserQuestionsResult()
        {
            //var user = AcademyContext.Account.GetCurrentUser();
            //var disciplines = AcademyContext.NotificationService.GetDisciplines();
            //ViewBag.Disciplines = disciplines.Select(DisciplineMapper.Map);
            ViewBag.Disciplines = GetDisciplines();
            return View("GetUserQuestions", UserMapper.Map(CurrentUser));
        }
    }
}
