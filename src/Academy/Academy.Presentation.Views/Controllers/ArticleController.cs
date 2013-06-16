using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Academy.Domain.Objects;
using Academy.Presentation.ViewModels;
using Academy.Presentation.Views.Unity;

namespace Academy.Presentation.Views.Controllers
{
    public class ArticleController : Controller
    {
        //public ActionResult Index()
        //{
        //    return View();
        //}

        private readonly ApplicationContainer container;

        public ArticleController()
        {
            container = ApplicationContainer.Instance;
        }

        //public ActionResult Publish(
        //    ArticleViewModel article,
        //    IEnumerable<int> disciplines,
        //    string returnUrl)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        container.Service.Publication.PublishArticle(null, disciplines);
        //    }
        //    return View(returnUrl, article);
        //}

        // Obsolete
        //public ActionResult Create()
        //{
        //    return View(new ArticleViewModel());
        //}

        //public ActionResult AddAuthor()
        //{
        //    return View("../Shared/EditorTemplates/CreateAuthorEditor", new AuthorViewModel());
        //}
    }
}
