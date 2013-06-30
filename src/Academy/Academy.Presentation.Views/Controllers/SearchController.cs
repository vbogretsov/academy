using System;
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
            ViewBag.Disciplines = GetDisciplines();
            return View(new ArticleSearchViewModel());
        }

        [HttpPost]
        public ActionResult FindArticles(ArticleSearchViewModel viewModel)
        {
            var result = Service.FindArticles(ArticleSearchMapper.Map(viewModel));
            return View(
                "RenderTemplates/ArticleSearchResultView",
                ArticleSearchResultMapper.Map(result));
        }

        [HttpGet]
        public ActionResult SearchQuestions()
        {
            ViewBag.Disciplines = GetDisciplines();
            return View();
        }

        [HttpPost]
        public ActionResult FindQuestions(QuestionSearchViewModel viewModel)
        {
            var result = Service.FindQuestions(QuestionSearchMapper.Map(viewModel));
            return View(
                "RenderTemplates/QuestionSearchResultView",
                QuestionSearchResultMapper.Map(result));
        }
    }
}
