using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Academy.Presentation.ViewModels;
using Academy.Presentation.ViewModels.Mappers;

namespace Academy.Presentation.Views.Controllers
{
    [Authorize]
    public class NotificationController : AcademyController
    {
        [HttpPost]
        public ActionResult Subscribe(IEnumerable<DisciplineViewModel> disciplines)
        {
            Service.Subscribe(CurrentUser.Id, disciplines.Select(x => x.Id));
            return GetDisciplinesEditor();
        }

        [HttpGet]
        public ActionResult GetArticleNews(
            int pageNumber = 1,
            int pageSize = DefualtPageSize)
        {
            var news = Service.GetArticleNews(CurrentUser.Id, pageNumber, pageSize);
            var page = PageDataMapper.Map(news, ArticleNewsMapper.Map);
            page.UrlFormat = "#/NewArticles?";
            return View("RenderTemplates/Paging/ArticleNewsPageView", page);
        }

        [HttpGet]
        public ActionResult GetQuestionNews(
            int pageNumber = 1,
            int pageSize = DefualtPageSize)
        {
            var news = Service.GetQuestionNews(CurrentUser.Id, pageNumber, pageSize);
            var page = PageDataMapper.Map(news, QuestionNewsMapper.Map);
            page.UrlFormat = "#/NewQuestions?";
            return View("RenderTemplates/Paging/QuestionNewsPageView", page);
        }

        [HttpGet]
        public ActionResult GetCommentNews(
            int pageNumber = 1,
            int pageSize = DefualtPageSize)
        {
            var news = Service.GetCommentNews(CurrentUser.Id, pageNumber, pageSize);
            var page = PageDataMapper.Map(news, CommentNewsMapper.Map);
            page.UrlFormat = "#/NewComments?";
            return View("RenderTemplates/Paging/CommentNewsPageView", page);
        }

        [HttpGet]
        public ActionResult GetAnswerNews(
            int pageNumber = 1,
            int pageSize = DefualtPageSize)
        {
            var news = Service.GetAnswerNews(CurrentUser.Id, pageNumber, pageSize);
            var page = PageDataMapper.Map(news, AnswerNewsMapper.Map);
            page.UrlFormat = "#/NewAnswers?";
            return View("RenderTemplates/Paging/AnswerNewsPageView", page);
        }

        [HttpGet]
        private ActionResult GetDisciplinesEditor()
        {
            IncludeDisciplines();
            return View(
                "EditorTemplates/EditDisciplinesEditor",
                UserMapper.Map(Service.GetCurrentUser()));
        }
    }
}
