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
        private readonly User subscriber;

        public NotificationController()
        {
            subscriber = AcademyContext.Account.GetCurrentUser();
        }

        [HttpPost]
        public ActionResult Subscribe(IEnumerable<DisciplineViewModel> disciplines)
        {
            subscriber.Disciplines.Clear(); // TODO: try to avoid clear (minor)
            subscriber.Disciplines = disciplines.Select(DisciplineMapper.Map).ToList();
            AcademyContext.NotificationService.Subscribe(subscriber);
            var all = AcademyContext.NotificationService.GetDisciplines();
            ViewBag.Disciplines = all.Select(DisciplineMapper.Map);
            return View("EditorTemplates/EditDisciplinesEditor", UserMapper.Map(subscriber));
        }
    }
}
