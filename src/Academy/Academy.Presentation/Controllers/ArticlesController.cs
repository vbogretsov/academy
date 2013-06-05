using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Academy.Presentation.Controllers
{
    public class ArticlesController : Controller
    {
        //
        // GET: /Articles/

        public ActionResult Index()
        {
            return Request.IsAuthenticated
                ? RedirectToAction("Index", "")
                : RedirectToAction("Index", "");
        }

    }
}
