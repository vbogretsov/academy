using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace Academy.Presentation.Helpers
{
    public static class HtmlHelpers
    {
        public static MvcHtmlString BrowseFileFor<TModel, TProp>(
            this HtmlHelper<TModel> html,
            Expression<Func<TModel, string>> exception)
        {
            string intpu = "<input>";
            throw new NotImplementedException();
        }
    }
}