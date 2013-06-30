using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Academy.Domain.Objects;
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
            return GetDisciplinesEditor(CurrentUser);
        }

        [HttpGet]
        public ActionResult GetArticleNews()
        {
            return View(UserMapper.Map(CurrentUser));
        }

        [HttpGet]
        public ActionResult GetQuestionNews()
        {
            return View(UserMapper.Map(CurrentUser));
        }

        [HttpGet]
        public ActionResult GetCommentNews()
        {
            return View(UserMapper.Map(CurrentUser));
        }

        [HttpGet]
        public ActionResult GetAnswerNews()
        {
            return View(UserMapper.Map(CurrentUser));
        }

        [HttpGet]
        private ActionResult GetDisciplinesEditor(User user)
        {
            ViewBag.Disciplines = GetDisciplines();
            return View(
                "EditorTemplates/EditDisciplinesEditor",
                UserMapper.Map(user));
        }
    }
}
