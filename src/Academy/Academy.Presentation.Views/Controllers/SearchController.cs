using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Academy.Presentation.ViewModels;
using Academy.Presentation.ViewModels.Mappers;

namespace Academy.Presentation.Views.Controllers
{
    public class SearchController : AcademyController
    {
        [HttpGet]
        public ActionResult SearchArticles()
        {
            ViewBag.Disciplines = AcademyContext.NotificationService
                .GetDisciplines().Select(DisciplineMapper.Map);
            return View(new ArticleSearchViewModel());
        }

        [HttpPost]
        public ActionResult FindArticles(ArticleSearchViewModel viewModel)
        {
            var criteria = ArticleSearchMapper.Map(viewModel);
            var result = AcademyContext.SearchService.FindArticles(criteria);
            return View(
                "RenderTemplates/ArticleSearchResultView",
                ArticleSearchResultMapper.Map(result));
        }

        [HttpGet]
        public ActionResult SearchQuestions()
        {
            ViewBag.Disciplines = AcademyContext.NotificationService
                .GetDisciplines().Select(DisciplineMapper.Map);
            return View();
        }

        [HttpPost]
        public ActionResult FindQuestions(QuestionSearchViewModel viewModel)
        {
            var criteria = QuestionSearchMapper.Map(viewModel);
            var result = AcademyContext.SearchService.FindQuestions(criteria);
            return View(
                "RenderTemplates/QuestionSearchResultView",
                QuestionSearchResultMapper.Map(result));
        }
    }
}
