using System;
using System.Web.Mvc;

namespace Academy.Presentation.Views.Controllers
{
    public class LocalizationController : Controller
    {
        //
        // GET: /Localization/

        //[HttpPost]
        public ActionResult ChangeLanguage(string language, string returnUrl)
        {
            Session["Language"] = language;
            return Redirect(returnUrl);
        }
    }
}
