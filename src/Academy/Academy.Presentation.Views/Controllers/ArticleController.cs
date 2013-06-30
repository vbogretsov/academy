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
        public ActionResult GetUserArticles()
        {
            ViewBag.Disciplines = GetDisciplines();
            var viewModel = UserMapper.Map(CurrentUser);
            try
            {
                var articles = Service.GetUserArticles(viewModel.Id, 1, PageSize);
                viewModel.ArticlesPage = PageDataMapper.Map(articles, ArticleMapper.Map);
            }
            catch (Exception exception)
            {
                
            }
            return View("GetUserArticles", viewModel);
        }

        [HttpGet]
        public ActionResult GetUserComments()
        {
            return View(UserMapper.Map(Service.GetCurrentUser()));
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
        public ActionResult CommentArticle(CommentViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Service.Comment(CommentMapper.Map(viewModel));
            }
            return GetUserArticles();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult RemoveComment(int id)
        {
            Service.RemoveComment(id);
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
    }
}
