using System;
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

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult RemoveQuestion(int questionId)
        {
            Service.RemoveQuestion(questionId);
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
            var page = LoadUserQuestions(CurrentUser.Id, pageNumber, pageSize);
            return View("QuestionsPageView", page);
        }

        private PageDataViewModel<QuestionViewModel> LoadUserQuestions(
            int userId,
            int pageNumber,
            int pageSize)
        {
            var questions = Service.GetUserQuestions(userId, pageNumber, pageSize);
            var page = PageDataMapper.Map(questions, QuestionMapper.Map);
            page.UrlFormat = "#/GetUserQuestionsPage?";
            return page;
        }
    }
}
