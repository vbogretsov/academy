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
using Academy.Presentation.Unity;
using Academy.Presentation.Utils;
using Academy.Presentation.ViewModels;

namespace Academy.Presentation.Controllers
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
            return View(new Profile(currentUser));
        }

        public ActionResult Edit()
        {
            return View(new Profile(currentUser));
        }

        [HttpPost]
        public ActionResult Edit(Profile profile)
        {
            if (ModelState.IsValid)
            {
                UpdateUser(profile);
            }
            return View("Index", profile);
        }

        [HttpPost]
        public ActionResult SelectDisciplines(IEnumerable<int> disciplines)
        {
            container.Service.Notification.AssigneDisciplines(
                currentUser,
                disciplines);
            return View("Edit", new Profile(currentUser));
        }

        public ActionResult GetArticles()
        {
            return View("Articles", new Profile(currentUser));
        }

        [HttpPost]
        public ActionResult PublishArticle(
            ArticleViewModel article,
            IEnumerable<int> disciplines)
        {
            return View("Articles", new Profile(currentUser));
        }

        public ActionResult AddAuthor(ArticleViewModel article)
        {
            return View("EditorTemplates/AddAuthorEditor", new AuthorViewModel());
        }

        // TODO: refactor the code below

        private void UpdateUser(Profile profile)
        {
            UpdateUserData(profile);
            container.UserStorage.Update();
            SynchronizeProfile(profile);
        }

        private void SynchronizeProfile(Profile profile)
        {
            profile.PhotoFileName = currentUser.PhotoFileName;
        }

        private void UpdateUserData(Profile profile)
        {
            UploadPhoto(profile);
            currentUser.PhotoFileName =
                profile.PhotoFileName ?? currentUser.PhotoFileName;
            currentUser.Email = profile.Email;
            currentUser.FirstName = profile.FirstName;
            currentUser.LastName = profile.LastName;
            currentUser.University = profile.University;
            currentUser.BirthDate = profile.BirthDate.ToDateTime();
            currentUser.LastAccessDate = DateTime.Now;
        }

        private void UploadPhoto(Profile profile)
        {
            if (profile.PostedPhoto != null && profile.PostedPhoto.ContentLength > 0)
            {
                string photoPath = GetFullPhotoPath(profile.PostedPhoto.FileName);
                profile.PostedPhoto.SaveAs(photoPath);
                profile.PhotoFileName = Path.GetFileName(photoPath);
            }
        }

        private string GetFullPhotoPath(string photoFileName)
        {
            string fileName = Path.GetFileName(photoFileName);
            return Path.Combine(Server.MapPath(UserPhotosFolder), fileName);
        }
    }
}
