using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Academy.Domain.Objects;
using Academy.Presentation.ViewModels;
using Academy.Presentation.ViewModels.Mappers;

namespace Academy.Presentation.Views.Controllers
{
    [Authorize]
    public class ArticleController : AcademyController
    {
        private const string ArticlesFolder = "~/Resources/Articles";

        [HttpGet]
        public ActionResult GetUserArticles(int pageNumber = 1, int pageSize = DefualtPageSize)
        {
            IncludeDisciplines();
            CurrentUser.ArticlesPage = LoadUserArticles(CurrentUser.Id, pageNumber, PageSize);
            return View("GetUserArticles", CurrentUser);
        }

        [HttpGet]
        public ActionResult GetUserArticlesPage(int pageNumber, int pageSize)
        {
            CurrentUser.ArticlesPage = LoadUserArticles(CurrentUser.Id, pageNumber, pageSize);
            return View("RenderTemplates/Paging/ArticlesPageView", CurrentUser.ArticlesPage);
        }

        [HttpGet]
        public ActionResult GetArticle(int articleId)
        {
            var article = Service.GetArticle(articleId);
            return View("RenderTemplates/ArticleView", ArticleMapper.Map(article));
        }

        [HttpGet]
        public ActionResult AddAuthor()
        {
            return View("EditorTemplates/CreateAuthorEditor", new AuthorViewModel());
        }

        [HttpPost]
        public ActionResult PublishArticle(ArticleViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Service.Publish(ArticleMapper.Map(viewModel));
            }
            return GetUserArticles();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult RemoveArticle(int id)
        {
            Service.RemoveArticle(id);
            return null;
        }

        [HttpPost]
        public string Upload(HttpPostedFileBase file)
        {
            string result = null;
            if (file != null)
            {
                result = Service.Upload(
                    file.InputStream,
                    Server.MapPath(ArticlesFolder),
                    file.FileName);
            }
            return result;
        }

        private PageDataViewModel<ArticleViewModel> LoadUserArticles(
            int userId,
            int pageNumber,
            int pageSize)
        {
            var articles = Service.GetUserArticles(userId, pageNumber, pageSize);
            var page = PageDataMapper.Map(articles, ArticleMapper.Map);
            page.UrlFormat = "#/GetUserArticlesPage?";
            return page;
        }
    }
}
