using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Academy.Presentation.ViewModels;

namespace Academy.Presentation.Controllers
{
    public class ArticleController : Controller
    {
        //
        // GET: /Article/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Publish(
            ArticleViewModel article,
            IEnumerable<int> disciplines)
        {
            return View("../Profile/Articles");
        }
    }
}
