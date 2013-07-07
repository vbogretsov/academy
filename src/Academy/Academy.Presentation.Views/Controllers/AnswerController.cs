using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Academy.Presentation.ViewModels;
using Academy.Presentation.ViewModels.Mappers;

namespace Academy.Presentation.Views.Controllers
{
    public class AnswerController : AcademyController
    {
        [HttpGet]
        public ActionResult GetUserAnswers(
            int pageNumber = 1,
            int pageSize = DefualtPageSize)
        {
            var page = LoadUserAnswers(CurrentUser.Id, pageNumber, pageSize);
            return View("SingleAnswersPageView", page);
        }

        [HttpGet]
        public ActionResult GetQuestionAnswers(
            int questionId,
            int pageNumber = 1,
            int pageSize = DefualtPageSize)
        {
            var page = LoadQuestionAnswers(questionId, pageNumber, pageSize);
            return View("AnswersPageView", page);
        }

        [HttpPost]
        public ActionResult Answer(AnswerViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Service.Answer(AnswerMapper.Map(viewModel));
            }
            return GetQuestionAnswers(viewModel.QuestionId);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult RemoveAnswer(int id)
        {
            Service.RemoveAnswer(id);
            return null;
        }

        private PageDataViewModel<AnswerViewModel> LoadUserAnswers(
            int userId,
            int pageNumber,
            int pageSize)
        {
            var answers = Service.GetUserAnswers(userId, pageNumber, pageSize);
            var page = PageDataMapper.Map(answers, SingleAnswerMapper.Map);
            page.UrlFormat = "#/GetUserAnswers?";
            return page;
        }

        private PageDataViewModel<AnswerViewModel> LoadQuestionAnswers(
            int questionId,
            int pageNumber,
            int pageSize)
        {
            var answers = Service.GetQuestionAnswers(questionId, pageNumber, pageSize);
            var page = PageDataMapper.Map(answers, AnswerMapper.Map);
            page.UrlFormat = String.Format("#/GetQuestionAnswers?questionId={0}&", questionId);
            return page;
        }
    }
}