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

        private readonly Profile currentProfile;

        public ProfileController()
        {
            userStorage = ApplicationContainer.Instance
                .Resolve<IStorageFactory>().CreateUserStorage();
            MembershipUser membershipUser = Membership.GetUser();
            if (membershipUser != null)
            {
                currentUser = userStorage.Get(membershipUser.UserName);
                currentProfile = new Profile(currentUser);
            }
        }

        //
        // GET: /Profile/

        public ActionResult Index()
        {
            return View(currentProfile);
        }

        public ActionResult Edit()
        {
            return View(currentProfile);
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

        private void UpdateUser(Profile profile)
        {
            UpdateUserData(profile);
            userStorage.Update();
            profile.PhotoFileName = currentUser.PhotoFileName;
        }

        private void UpdateUserData(Profile profile)
        {
            UploadPhoto(profile);
            currentUser.PhotoFileName = profile.PhotoFileName ?? currentProfile.PhotoFileName;
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
