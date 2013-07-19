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
            CurrentUser.NotesPage = LoadUserNotes(CurrentUser.Id, 1, DefualtPageSize);
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

        // TODO: Refactor to avoid copy paste
        private PageDataViewModel<NoteViewModel> LoadUserNotes(
            int userId,
            int pageNumber,
            int pageSize)
        {
            var notes = Service.GetUserNotes(userId, pageNumber, pageSize);
            var page = PageDataMapper.Map(notes, NoteMapper.Map);
            page.UrlFormat = "#/GetUserNotes?";
            return page;
        }
    }
}
