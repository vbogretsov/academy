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
                AcademyContext.NoteService.Add(NoteMapper.Map(viewModel));
            }
            return GetUserNotes();
        }

        [HttpPost]
        public ActionResult RemoveNote(int noteId)
        {
            AcademyContext.NoteService.Remove(noteId);
            return GetUserNotes();
        }

        private ActionResult GetUserNotes()
        {
            var user = AcademyContext.Account.GetCurrentUser();
            return View("RenderTemplates/UserNotesView", UserMapper.Map(user));
        }
    }
}
