using System.Web;
using System.Web.Mvc;

namespace Academy.Presentation.Views
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}