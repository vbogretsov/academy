using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Academy.Presentation.ViewModels;


namespace Academy.Presentation.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View(CreateHomeViewModel());
        }

        public ActionResult Contacts()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        private static HomeViewModel CreateHomeViewModel()
        {
            return new HomeViewModel
            {
                Login = new Login(),
                Registration = new Registration()
            };
        }
    }
}
