using System;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Academy.Presentation.ViewModels.Utils;

namespace Academy.Presentation.Views.Helpers
{
    public static class HtmlHelpers
    {
        public static MvcHtmlString DateTimePickerFor<TModel, TProperty>(
            this HtmlHelper<TModel> html,
            Expression<Func<TModel, TProperty>> day,
            Expression<Func<TModel, TProperty>> month,
            Expression<Func<TModel, TProperty>> year)
        {
            StringBuilder markup = new StringBuilder();
            markup.AppendLine(html.DropDownListFor(
                day,
                new SelectList(DateViewModel.Days),
                new { @class = "select-day" }).ToHtmlString());
            markup.AppendLine(html.DropDownListFor(
                month,
                new SelectList(DateViewModel.Months, "Number", "Name"),
                new { @class = "select-month" }).ToHtmlString());
            markup.AppendLine(html.DropDownListFor(
                year,
                new SelectList(DateViewModel.Years),
                new { @class = "select-year" }).ToHtmlString());
            return new MvcHtmlString(markup.ToString());
        }
    }
}