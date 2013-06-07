using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Academy.Presentation.Utils;

namespace Academy.Presentation.Helpers
{
    public static class BootstrapHtmlHelpers
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
                new SelectList(Date.Days),
                new {@class = "select-day"}).ToHtmlString());
            markup.AppendLine(html.DropDownListFor(
                month,
                new SelectList(Date.Months, "Number", "Name"),
                new { @class = "select-month" }).ToHtmlString());
            markup.AppendLine(html.DropDownListFor(
                year,
                new SelectList(Date.Years),
                new { @class = "select-year" }).ToHtmlString());
            return new MvcHtmlString(markup.ToString());
        }

        public static MvcHtmlString SpanFor<TModel, TProperty>(
            this HtmlHelper<TModel> html,
            Expression<Func<TModel, TProperty>> expression,
            IDictionary<string, object> htmlAtributes = null)
        {
            StringBuilder markup = new StringBuilder();
            markup.Append("<span");
            AppendHtmlAttributes(markup, htmlAtributes);
            markup.Append(">");
            markup.AppendLine(ExpressionHelper.GetExpressionText(expression));
            markup.AppendLine("</span>");
            return new MvcHtmlString(markup.ToString());
        }

        private static void AppendHtmlAttributes(
            StringBuilder markup,
            IDictionary<string, object> htmlAttributes)
        {
            if (htmlAttributes != null)
            {
                foreach (var attribute in htmlAttributes)
                {
                    markup.AppendFormat(" {0}=\"{1}\"", attribute.Key, attribute.Value);
                }
            }
        }
    }
}