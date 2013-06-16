using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Academy.Domain.DataAccess;
using Academy.Domain.Objects;
using Academy.Presentation.ViewModels;
using Academy.Presentation.ViewModels.Mappers;
using Academy.Presentation.Views.Unity;

namespace Academy.Presentation.Views.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private const string UserPhotosFolder = "~/Resources/Users";

        private const string ArticlesFolder = "~/Resources/Articles";

        private readonly User currentUser;

        private readonly ApplicationContainer container;

        public ProfileController()
        {
            container = ApplicationContainer.Instance;
            var membershipUser = Membership.GetUser();
            if (membershipUser != null)
            {
                currentUser = container.UserStorage.Get(membershipUser.UserName);
            }
        }

        public ActionResult Index()
        {
            return View(UserMapper.Map(currentUser));
        }

        public ActionResult Edit()
        {
            return View(UserMapper.Map(currentUser));
        }

        [HttpPost]
        public ActionResult Edit(UserViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                UpdateUser(viewModel);
            }
            return View("Index", viewModel);
        }

        // TODO: maby I should combine this action with Edit?
        [HttpPost]
        public ActionResult UpdateDisciplines(
            IEnumerable<DisciplineViewModel> disciplines)
        {
            container.Service.Notification.AssigneDisciplines(
                currentUser,
                disciplines.Select(x => x.Id));
            return View("Edit", UserMapper.Map(currentUser));
        }

        public ActionResult GetUserArticles()
        {
            return View(
                "RenderTemplates/UserArticlesView",
                UserMapper.Map(currentUser));
        }

        public ActionResult AddAuthor()
        {
            return View(
                "EditorTemplates/CreateAuthorEditor",
                new AuthorViewModel());
        }

        [HttpPost]
        public ActionResult PublishArticle(
            ArticleViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                container.Service.Publication.PublishArticle(
                    currentUser,
                    ArticleMapper.Map(viewModel));
            }
            return View(
                "RenderTemplates/UserArticlesView",
                UserMapper.Map(currentUser));
        }

        public string Upload(HttpPostedFileBase file)
        {
            string result = null;
            if (file != null)
            {
                result = container.Service.Files.Upload(
                    file.InputStream,
                    Server.MapPath(ArticlesFolder),
                    file.FileName);
            }
            return result;
        }

        private void UpdateUser(UserViewModel viewModel)
        {
            UploadUserPhoto(viewModel);
            UserMapper.Sync(currentUser, viewModel);
            container.UserStorage.Update();
        }

        private void UploadUserPhoto(UserViewModel viewModel)
        {
            if (viewModel.PhotoFile != null &&
                viewModel.PhotoFile.ContentLength > 0)
            {
                viewModel.PhotoFileName = container.Service.Files.Upload(
                    viewModel.PhotoFile.InputStream,
                    Server.MapPath(UserPhotosFolder),
                    viewModel.PhotoFile.FileName);
            }
        }
    }
}
