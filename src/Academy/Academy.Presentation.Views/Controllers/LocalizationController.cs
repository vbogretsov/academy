using System;
using System.Web.Mvc;

namespace Academy.Presentation.Views.Controllers
{
    public class LocalizationController : Controller
    {
        //[HttpPost]
        public ActionResult ChangeLanguage(string language, string returnUrl)
        {
            Session["Language"] = language;
            return Redirect(returnUrl);
        }
    }
}
