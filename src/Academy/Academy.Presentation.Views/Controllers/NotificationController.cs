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
            var user = AcademyContext.Account.GetCurrentUser();
            user.Disciplines.Clear();
            AcademyContext.NotificationService.Subscribe(
                user.Id,
                disciplines.Select(x => x.Id));
            return GetDisciplinesEditor(user);
        }

        public ActionResult GetArticleNews()
        {
            var user = AcademyContext.Account.GetCurrentUser();
            return View(UserMapper.Map(user));
        }

        public ActionResult GetQuestionNews()
        {
            var user = AcademyContext.Account.GetCurrentUser();
            return View(UserMapper.Map(user));
        }

        public ActionResult GetCommentNews()
        {
            var user = AcademyContext.Account.GetCurrentUser();
            return View(UserMapper.Map(user));
        }

        public ActionResult GetAnswerNews()
        {
            var user = AcademyContext.Account.GetCurrentUser();
            return View(UserMapper.Map(user));
        }

        private ActionResult GetDisciplinesEditor(User user)
        {
            var all = AcademyContext.NotificationService.GetDisciplines();
            ViewBag.Disciplines = all.Select(DisciplineMapper.Map);
            return View(
                "EditorTemplates/EditDisciplinesEditor",
                UserMapper.Map(user));
        }
    }
}
