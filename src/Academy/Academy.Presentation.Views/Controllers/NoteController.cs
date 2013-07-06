using System;
using System.Web.Mvc;
using Academy.Presentation.ViewModels;
using Academy.Presentation.ViewModels.Mappers;

namespace Academy.Presentation.Views.Controllers
{
    [Authorize]
    public class NoteController : AcademyController
    {
        [HttpPost]
        public ActionResult AddNote(NoteViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Service.Add(NoteMapper.Map(viewModel));
            }
            return GetUserNotes();
        }

        [HttpPost]
        public ActionResult RemoveNote(int noteId)
        {
            Service.Remove(noteId);
            return GetUserNotes();
        }

        public ActionResult GetUserNotes(
            int pageNumber = 1,
            int pageSize = DefualtPageSize)
        {
            CurrentUser.NotesPage = LoadUserNotes(CurrentUser.Id, pageNumber, pageSize);
            return View("RenderTemplates/UserNotesView", CurrentUser);
        }

        public ActionResult GetUserNotesPage(int pageNumber, int pageSize)
        {
            var page = LoadUserNotes(CurrentUser.Id, pageNumber, pageSize);
            return View("RenderTemplates/Paging/NotesPageView", page);
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
