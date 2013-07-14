using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Academy.Presentation.ViewModels;
using Academy.Presentation.ViewModels.Mappers;
using Academy.Web.Services;

namespace Academy.Presentation.Views.Controllers
{
    public abstract class AcademyController : Controller
    {
        protected const int DefualtPageSize = 5;

        private readonly AcademyService service;

        private UserViewModel currentUser;

        protected AcademyController()
        {
            service = new AcademyService();
        }

        protected void IncludeDisciplines()
        {
            ViewBag.Disciplines = Service.GetDisciplines().Select(DisciplineMapper.Map);
        }

        protected override void Dispose(bool disposing)
        {
            service.Dispose();
            base.Dispose(disposing);
        }

        protected UserViewModel CurrentUser
        {
            get
            {
                if (currentUser == null)
                {
                    currentUser = UserMapper.Map(Service.GetCurrentUser());
                }
                return currentUser;
            }
        }

        protected AcademyService Service
        {
            get
            {
                return service;
            }
        }

        protected int PageSize
        {
            get
            {
                return DefualtPageSize;
            }
        }
    }
}