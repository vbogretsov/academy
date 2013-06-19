using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Academy.Web.Services;

namespace Academy.Presentation.Views.Controllers
{
    public abstract class AcademyController : Controller
    {
        private readonly AcademyContext academyContext;

        protected AcademyController()
        {
            academyContext = new AcademyContext();
        }

        protected override void Dispose(bool disposing)
        {
            academyContext.Dispose();
            base.Dispose(disposing);
        }

        protected AcademyContext AcademyContext
        {
            get
            {
                return academyContext;
            }
        }
    }
}