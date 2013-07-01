using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Academy.Presentation.ViewModels;
using Academy.Presentation.ViewModels.Mappers;

namespace Academy.Presentation.Views.Controllers
{
    [Authorize]
    public class NotificationController : AcademyController
    {
        [HttpPost]
        public ActionResult Subscribe(IEnumerable<DisciplineViewModel> disciplines)
        {
            Service.Subscribe(CurrentUser.Id, disciplines.Select(x => x.Id));
            return GetDisciplinesEditor();
        }

        [HttpGet]
        public ActionResult GetArticleNews()
        {
            return View(CurrentUser);
        }

        [HttpGet]
        public ActionResult GetQuestionNews()
        {
            return View(CurrentUser);
        }

        [HttpGet]
        public ActionResult GetCommentNews()
        {
            return View(CurrentUser);
        }

        [HttpGet]
        public ActionResult GetAnswerNews()
        {
            return View(CurrentUser);
        }

        [HttpGet]
        private ActionResult GetDisciplinesEditor()
        {
            IncludeDisciplines();
            return View(
                "EditorTemplates/EditDisciplinesEditor",
                UserMapper.Map(Service.GetCurrentUser()));
        }
    }
}
