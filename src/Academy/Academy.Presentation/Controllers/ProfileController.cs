using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Academy.Domain.DataAccess;
using Academy.Domain.Objects;
using Academy.Presentation.Unity;
using Academy.Presentation.ViewModels;

namespace Academy.Presentation.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private const string UserPhotosFolder = "~/Resources/Users";

        private readonly UserStorage userStorage;

        private readonly User currentUser;

        public ProfileController()
        {
            userStorage = ApplicationContainer.Instance
                .Resolve<IStorageFactory>().CreateUserStorage();
            MembershipUser membershipUser = Membership.GetUser();
            if (membershipUser != null)
            {
                currentUser = userStorage.Get(membershipUser.UserName);
            }
        }

        //
        // GET: /Profile/

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
        public ActionResult SelectDisciplines(FormCollection collection)
        {
            foreach (var item in collection)
            {
                var x = item;
            }
            return View("Index", new Profile(currentUser));
        }

        private void UpdateUser(Profile profile)
        {
            UpdateUserData(profile);
            userStorage.Update();
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
