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
        public ActionResult SelectDisciplines(IEnumerable<int> disciplines)
        {
            container.Service.Notification.AssigneDisciplines(
                currentUser,
                disciplines);
            return View("Edit", UserMapper.Map(currentUser));
        }

        public ActionResult GetUserArticles()
        {
            return View("RenderTemplates/UserArticlesView", UserMapper.Map(currentUser));
        }

        // TODO: refactor the code below using mapper

        private void UpdateUser(UserViewModel viewModel)
        {
            //upload photo
            // update user
            // commit




            UpdateUserData(viewModel);
            container.UserStorage.Update();
            SynchronizeProfile(viewModel);
        }

        private void SynchronizeProfile(UserViewModel viewModel)
        {
            viewModel.PhotoFileName = currentUser.PhotoFileName;
        }

        private void UpdateUserData(UserViewModel viewModel)
        {
            UploadPhoto(viewModel);
            UserMapper.Sync(currentUser, viewModel);
        }

        private void UploadPhoto(UserViewModel viewModel)
        {
            if (viewModel.PhotoFile != null && viewModel.PhotoFile.ContentLength > 0)
            {
                string photoPath = GetFullPhotoPath(viewModel.PhotoFile.FileName);
                viewModel.PhotoFile.SaveAs(photoPath);
                viewModel.PhotoFileName = Path.GetFileName(photoPath);
            }
        }

        private string GetFullPhotoPath(string photoFileName)
        {
            string fileName = Path.GetFileName(photoFileName);
            return Path.Combine(Server.MapPath(UserPhotosFolder), fileName);
        }
    }
}
