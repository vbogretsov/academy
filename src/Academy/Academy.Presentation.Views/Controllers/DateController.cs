using System;
using System.Web.Mvc;

using Academy.Presentation.ViewModels.Mappers;
using Academy.Presentation.ViewModels.Utils;

namespace Academy.Presentation.Views.Controllers
{
    public class DateController : Controller
    {
        [HttpPost]
        public JsonResult ValidateDate(DateViewModel viewModel)
        {
            try
            {
                DateMapper.Map(viewModel);
                return Json(true);
            }
            catch (Exception)
            {
                return Json(false);
            }
        }
    }
}
