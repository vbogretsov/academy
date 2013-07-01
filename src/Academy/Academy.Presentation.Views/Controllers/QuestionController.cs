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
                Service.Ask(QuestionMapper.Map(viewModel));
            }
            return GetUserQuestions();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult RemoveQuestion(int id)
        {
            Service.RemoveQuestion(id);
            return null;
        }

        [HttpPost]
        public ActionResult Answer(AnswerViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Service.Answer(AnswerMapper.Map(viewModel));
                var question = Service.GetQuestion(viewModel.QuestionId);
                return View("RenderTemplates/AnswersView", QuestionMapper.Map(question));
            }
            return GetUserQuestions(); //TODO: add error handling
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult RemoveAnswer(int id)
        {
            Service.RemoveAnswer(id);
            return null;
        }

        [HttpGet]
        public ActionResult GetQuestion(int questionId)
        {
            var question = Service.GetQuestion(questionId);
            return View("RenderTemplates/QuestionView", QuestionMapper.Map(question));
        }

        [HttpGet]
        public ActionResult GetUserQuestions(int pageNumber = 1, int pageSize = DefualtPageSize)
        {
            IncludeDisciplines();
            CurrentUser.QuestionsPage = LoadUserQuestions(CurrentUser.Id, pageNumber, pageSize);
            return View("GetUserQuestions", CurrentUser);
        }

        [HttpGet]
        public ActionResult GetUserQuestionsPage(int pageNumber, int pageSize)
        {
            CurrentUser.QuestionsPage = LoadUserQuestions(CurrentUser.Id, pageNumber, pageSize);
            return View("RenderTemplates/Paging/QuestionsPageView", CurrentUser.QuestionsPage);
        }

        [HttpGet]
        public ActionResult GetUserAnswers()
        {
            return View(CurrentUser);
        }

        private PageDataViewModel<QuestionViewModel> LoadUserQuestions(
            int userId,
            int pageNumber,
            int pageSize)
        {
            var questions = Service.GetUserQuestions(userId, pageNumber, pageSize);
            return PageDataMapper.Map(questions, QuestionMapper.Map);
        }
    }
}
