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

        public ActionResult GetUserArticles()
        {
            var user = AcademyContext.Account.GetCurrentUser();
            return GetUserArticles(user);
        }

        public ActionResult GetUserComments()
        {
            var user = AcademyContext.Account.GetCurrentUser();
            return View(UserMapper.Map(user));
        }

        public ActionResult GetArticle(int articleId)
        {
            var article = AcademyContext.PublicationService.GetArticle(articleId);
            return View("RenderTemplates/ArticleView", ArticleMapper.Map(article));
        }

        public ActionResult AddAuthor()
        {
            return View("EditorTemplates/CreateAuthorEditor", new AuthorViewModel());
        }

        [HttpPost]
        public ActionResult PublishArticle(ArticleViewModel viewModel)
        {
            var user = AcademyContext.Account.GetCurrentUser();
            if (ModelState.IsValid)
            {
                var article = ArticleMapper.Map(viewModel);
                article.Authors.Add(user);
                AcademyContext.PublicationService.Publish(article);
                AcademyContext.NotificationService.NotifyAboutNewArticle(article);
            }
            return GetUserArticles(user);
        }

        [HttpPost]
        public ActionResult CommentArticle(CommentViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var comment = CommentMapper.Map(viewModel);
                comment.UserId = AcademyContext.Account.GetCurrentUser().Id;
                AcademyContext.PublicationService.Comment(comment);
                AcademyContext.NotificationService.NotifyAboutNewComment(comment);
            }
            var article = AcademyContext.PublicationService.GetArticle(viewModel.ArticleId);
            return View("RenderTemplates/CommentsView", ArticleMapper.Map(article));
        }

        [HttpPost]
        public string Upload(HttpPostedFileBase file)
        {
            string result = null;
            if (file != null)
            {
                result = AcademyContext.FileService.Upload(
                    file.InputStream,
                    Server.MapPath(ArticlesFolder),
                    file.FileName);
            }
            return result;
        }

        private ActionResult GetUserArticles(User user)
        {
            var disciplines = AcademyContext.NotificationService.GetDisciplines();
            ViewBag.Disciplines = disciplines.Select(DisciplineMapper.Map);
            return View("GetUserArticles", UserMapper.Map(user));
        }
    }
}
