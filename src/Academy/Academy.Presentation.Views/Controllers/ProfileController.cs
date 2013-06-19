using System;
using System.Linq;
using System.Web.Mvc;
using Academy.Domain.Objects;
using Academy.Presentation.ViewModels;
using Academy.Presentation.ViewModels.Mappers;

namespace Academy.Presentation.Views.Controllers
{
    [Authorize]
    public class ProfileController : AcademyController
    {
        private const string UserPhotosFolder = "~/Resources/Users";

        //private const string ArticlesFolder = "~/Resources/Articles";

        private readonly User currentUser;

        public ProfileController()
        {
            currentUser = AcademyContext.Account.GetCurrentUser();
        }

        public ActionResult Index()
        {
            return View(UserMapper.Map(currentUser));
        }

        public ActionResult Edit()
        {
            var disciplines = AcademyContext.NotificationService.GetDisciplines();
            ViewBag.Disciplines = disciplines.Select(DisciplineMapper.Map);
            return View(UserMapper.Map(currentUser));
        }

        [HttpPost]
        public ActionResult Edit(UserViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                UploadUserPhoto(viewModel);
                AcademyContext.Account.Update(UserMapper.Map(viewModel));
            }
            return View("Index", viewModel);
        }

        private void UploadUserPhoto(UserViewModel viewModel)
        {
            if (viewModel.PhotoFile != null &&
                viewModel.PhotoFile.ContentLength > 0)
            {
                viewModel.PhotoFileName = AcademyContext.FileService.Upload(
                    viewModel.PhotoFile.InputStream,
                    Server.MapPath(UserPhotosFolder),
                    viewModel.PhotoFile.FileName);
            }
        }

        // TODO: maby I should combine this action with Edit?
        //[HttpPost]
        //public ActionResult UpdateDisciplines(
        //    IEnumerable<DisciplineViewModel> disciplines)
        //{
        //    container.Service.Notification.AssigneDisciplines(
        //        currentUser,
        //        disciplines.Select(x => x.Id));
        //    return View("Edit", UserMapper.Map(currentUser));
        //}

        //public ActionResult GetUserArticles()
        //{
        //    return View(
        //        "RenderTemplates/UserArticlesView",
        //        UserMapper.Map(currentUser));
        //}

        //public ActionResult AddAuthor()
        //{
        //    return View(
        //        "EditorTemplates/CreateAuthorEditor",
        //        new AuthorViewModel());
        //}

        //[HttpPost]
        //public ActionResult PublishArticle(
        //    ArticleViewModel viewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        container.Service.Publications.PublishArticle(
        //            currentUser,
        //            ArticleMapper.Map(viewModel));
        //    }
        //    return View(
        //        "RenderTemplates/UserArticlesView",
        //        UserMapper.Map(currentUser));
        //}

        //[HttpPost]
        //public ActionResult CommentArticle(CommentViewModel viewModel)
        //{
        //    var article = container.ArticleStorage.Get(viewModel.Article.Id);
        //    //if (ModelState.IsValid)
        //    //{
        //        container.Service.Publications.CommentArticle(
        //            currentUser,
        //            article,
        //            CommentMapper.Map(viewModel));
        //        return View("RenderTemplates/CommentsView", ArticleMapper.Map(article));
        //    //}
        //    //else
        //    //{
        //    //    var errors = ModelState.Where(x => x.Value.Errors.Count > 0).ToList();
        //    //}
        //    //return View("RenderTemplates/CommentsView", ArticleMapper.Map(article));
        //}

        //public string Upload(HttpPostedFileBase file)
        //{
        //    string result = null;
        //    if (file != null)
        //    {
        //        result = AcademyContext.FileService.Upload(
        //            file.InputStream,
        //            Server.MapPath(ArticlesFolder),
        //            file.FileName);
        //    }
        //    return result;
        //}
    }
}
