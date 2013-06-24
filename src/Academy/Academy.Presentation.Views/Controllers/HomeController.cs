using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Academy.Presentation.ViewModels;


namespace Academy.Presentation.Views.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(CreateHomeViewModel());
        }

        [HttpGet]
        public ActionResult Contacts()
        {
            return View();
        }

        [HttpGet]
        public ActionResult About()
        {
            return View();
        }

        private static HomeViewModel CreateHomeViewModel()
        {
            return new HomeViewModel
            {
                Login = new LoginViewModel(),
                Registration = new RegistrationViewModel()
            };
        }
    }
}
