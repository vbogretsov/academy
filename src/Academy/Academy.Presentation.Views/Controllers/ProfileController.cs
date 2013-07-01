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

        [HttpGet]
        public ActionResult Index()
        {
            return View(CurrentUser);
        }

        [HttpGet]
        public ActionResult Edit()
        {
            IncludeDisciplines();
            return View(CurrentUser);
        }

        [HttpPost]
        public ActionResult Edit(UserViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                UploadUserPhoto(viewModel);
                Service.Update(UserMapper.Map(viewModel));
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult ContactAdministration()
        {
            return View();
        }

        private void UploadUserPhoto(UserViewModel viewModel)
        {
            if (viewModel.PhotoFile != null &&
                viewModel.PhotoFile.ContentLength > 0)
            {
                viewModel.PhotoFileName = Service.Upload(
                    viewModel.PhotoFile.InputStream,
                    Server.MapPath(UserPhotosFolder),
                    viewModel.PhotoFile.FileName);
            }
        }
    }
}
