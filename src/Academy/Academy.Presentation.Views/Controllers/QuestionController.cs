using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Academy.Presentation.ViewModels;
using Academy.Presentation.ViewModels.Mappers;

namespace Academy.Presentation.Views.Controllers
{
    public class QuestionController : AcademyController
    {
        [HttpPost]
        public ActionResult Ask(QuestionViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                AcademyContext.QuestionService.Ask(QuestionMapper.Map(viewModel));
            }
            var disciplines = AcademyContext.NotificationService.GetDisciplines();
            ViewBag.Disciplines = disciplines.Select(DisciplineMapper.Map);
            var user = AcademyContext.Account.GetCurrentUser();
            return View("GetUserQuestions", UserMapper.Map(user));
        }

        [HttpPost]
        public ActionResult Answer(AnswerViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                AcademyContext.QuestionService.Answer(AnswerMapper.Map(viewModel));
                // return
            }
            // return
            throw new NotImplementedException();
        }

        public ActionResult GetUserQuestions()
        {
            var user = AcademyContext.Account.GetCurrentUser();
            var disciplines = AcademyContext.NotificationService.GetDisciplines();
            ViewBag.Disciplines = disciplines.Select(DisciplineMapper.Map);
            return View(UserMapper.Map(user));
        }

        public ActionResult GetUserAnswers()
        {
            var user = AcademyContext.Account.GetCurrentUser();
            return View(UserMapper.Map(user));
        }
    }
}
