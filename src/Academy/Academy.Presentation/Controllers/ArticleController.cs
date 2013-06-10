﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Academy.Domain.Objects;
using Academy.Presentation.Unity;
using Academy.Presentation.ViewModels;

namespace Academy.Presentation.Controllers
{
    public class ArticleController : Controller
    {
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult Publish(
            ArticleViewModel article,
            IEnumerable<int> disciplines)
        {
            if (ModelState.IsValid)
            {
                
            }
            //return View("../Profile/Articles");
            throw new NotImplementedException();
        }

        // Obsolete
        //public ActionResult Create()
        //{
        //    return View(new ArticleViewModel());
        //}

        public ActionResult AddAuthor()
        {
            return View("../Shared/EditorTemplates/CreateAuthorEditor", new AuthorViewModel());
        }
    }
}
