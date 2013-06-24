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

        private readonly User currentUser;

        public ProfileController()
        {
            currentUser = AcademyContext.Account.GetCurrentUser();
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(UserMapper.Map(currentUser));
        }

        [HttpGet]
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
            return RedirectToAction("Index");
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
    }
}
