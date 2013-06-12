using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Academy.Presentation.ViewModels.Utils;

namespace Academy.Presentation.Views.Helpers
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
                new SelectList(DateViewModel.Days),
                new {@class = "select-day"}).ToHtmlString());
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

        public static MvcHtmlString ControlGroupFor<TModel, TProperty>(
            this HtmlHelper<TModel> html,
            Expression<Func<TModel, TProperty>> expression,
            Func<Expression<Func<TModel, TProperty>>, MvcHtmlString> control)
        {
            StringBuilder markup = new StringBuilder();
            markup.AppendLine("<div class=\"control-group\">");
            markup.AppendLine(
                html.LabelFor(expression, new {@class = "control-label"}).ToString());
            markup.AppendLine("<div class=\"controls\">");
            markup.AppendLine(control(expression).ToString());
            markup.AppendLine(html.ValidationMessageFor(expression).ToString());
            markup.AppendLine("</div>");
            markup.AppendLine("</div>");
            return new MvcHtmlString(markup.ToString());
        }

        public static MvcHtmlString FileUploadFor<TModel>(
            this HtmlHelper<TModel> html,
            Expression<Func<TModel, HttpPostedFileBase>> expression,
            string selectFile,
            string changeFile,
            string removeFile)
        {
            StringBuilder markup = new StringBuilder();
            markup.AppendLine("<div class=\"fileupload fileupload-new\" data-provides=\"fileupload\">");
            markup.AppendLine("<div class=\"input-append\">");
            markup.AppendLine("<div class=\"uneditable-input span3\">");
            markup.AppendLine("<i class=\"icon-file fileupload-exists\"></i>");
            markup.AppendLine("<span class=\"fileupload-preview\"></span>");
            markup.AppendLine("</div>");
            markup.AppendLine("<span class=\"btn btn-file\">");
            markup.AppendFormat("<span class=\"fileupload-new\">{0}</span>", selectFile);
            markup.AppendFormat("<span class=\"fileupload-exists\">{0}</span>", changeFile);
            markup.AppendLine(html.TextBoxFor(expression, new {type = "file"}).ToString());
            markup.AppendLine("</span>");
            markup.AppendFormat(
                "<a href=\"#\" class=\"btn fileupload-exists\" data-dismiss=\"fileupload\">{0}</a>",
                removeFile);
            markup.AppendLine("</div>");
            markup.AppendLine("</div>");
            return new MvcHtmlString(markup.ToString());
        }

        public static MvcHtmlString ImageUploadFor<TModel>(
            this HtmlHelper<TModel> html,
            Expression<Func<TModel, HttpPostedFileBase>> expression,
            string defaultImage,
            string existingImage,
            string additionalStyle,
            string selectImage,
            string changeImage,
            string removeImage)
        {
            StringBuilder markup = new StringBuilder();
            markup.AppendLine("<div class=\"fileupload fileupload-exists\" data-provides=\"fileupload\">");
            markup.AppendFormat("<div class=\"fileupload-new thumbnail {0}\">", additionalStyle);
            markup.AppendFormat("<img src=\"{0}\" />", defaultImage);
            markup.AppendLine("</div>");
            markup.AppendFormat(
                "<div class=\"fileupload-preview fileupload-]exists thumbnail {0}\">",
                additionalStyle);
            markup.AppendFormat("<img src=\"{0}\">", existingImage);
            markup.AppendLine("</div>");
            markup.AppendLine("<div>");
            markup.AppendLine("<span class=\"btn btn-file\">");
            markup.AppendFormat("<span class=\"fileupload-new\">{0}</span>", selectImage);
            markup.AppendFormat("<span class=\"fileupload-exists\">{0}</span>", changeImage);
            markup.AppendLine(html.TextBoxFor(expression, new {type = "file"}).ToString());
            markup.AppendLine("</span>");
            markup.AppendFormat(
                "<a href=\"#\" class=\"btn fileupload-exists\" data-dismiss=\"fileupload\">{0}</a>",
                removeImage);
            markup.AppendLine("</div>");
            markup.AppendLine("</div>");
            return new MvcHtmlString(markup.ToString());
        }

        public static MvcHtmlString ControlGroupSubmit<TModel>(
            this HtmlHelper<TModel> html,
            string submitText)
        {
            StringBuilder markup = new StringBuilder();
            markup.AppendLine("<div class=\"control-group\">");
            markup.AppendLine("<div class=\"controls\">");
            markup.AppendFormat("<input type=\"submit\" value=\"{0}\" class=\"btn\" />", submitText);
            markup.AppendLine("</div>");
            markup.AppendLine("</div>");
            return new MvcHtmlString(markup.ToString());
        }

        public static MvcHtmlString ModalVindowFor<TModel>(
            this HtmlHelper<TModel> html,
            MvcHtmlString body,
            string modalId,
            string header,
            string close,
            string save)
        {
            StringBuilder markup = new StringBuilder();
            markup.AppendFormat(
                "<div id=\"{0}\" class=\"modal hide fade\" tabindex=\"-1\" role=\"dialog\" aria-labelledby=\"myModalLabel\" aria-hidden=\"true\">",
                modalId);
            markup.AppendLine("<div class=\"modal-header\">");
            markup.AppendLine(
                "<button type=\"button\" class=\"close\" data-dismiss=\"modal\" aria-hidden=\"true\">×</button>");
            markup.AppendFormat("<h3 id=\"myModalLabel\">{0}</h3>", header);
            markup.AppendLine("</div>");
            markup.AppendLine("<div class=\"modal-body\">");
            markup.AppendLine(body.ToString());
            markup.AppendLine("</div>");
            markup.AppendLine("<div class=\"modal-footer\">");
            markup.AppendFormat(
                "<button class=\"btn\" data-dismiss=\"modal\" aria-hidden=\"true\">{0}</button>",
                close);
            markup.AppendFormat(
                "<input type=\"submit\" value=\"{0}\" class=\"btn btn-primary\" />",
                save);
            markup.AppendLine("</div>");
            markup.AppendLine("</div>");
            return new MvcHtmlString(markup.ToString());
        }

        public static MvcHtmlString List<TModel, TIem>(
            this HtmlHelper<TModel> html,
            IEnumerable<TIem> list,
            string header,
            string listClass,
            string ittemClass)
        {
            StringBuilder markup = new StringBuilder();
            markup.AppendLine("<div>");
            if (!String.IsNullOrEmpty(header))
            {
                markup.AppendLine("<p>");
                markup.AppendFormat("<span class=\"label btn-block\">{0}</span>", header);
                markup.AppendLine("</p>");
            }
            markup.AppendFormat("<ul class=\"{0}\">", listClass);
            foreach (var item in list)
            {
                markup.AppendLine("<li>");
                markup.AppendFormat(
                    "<span class=\"badge {0} btn-block\">{1}</span>",
                    ittemClass,
                    item);
                markup.AppendLine("</li>");
            }
            markup.AppendLine("</ul>");
            markup.AppendLine("</div>");
            return new MvcHtmlString(markup.ToString());
        }

        public static MvcHtmlString ModalButton<TModel>(
            this HtmlHelper<TModel> html,
            string modalId,
            string title,
            string additionalStyle)
        {
            string button = String.Format(
                "<a href=\"#{0}\" role=\"button\" class=\"btn {1}\" data-toggle=\"modal\">{2}</a>",
                modalId,
                additionalStyle,
                title);
            return new MvcHtmlString(button);
        }

        private static void AppendHtmlAttributes(
            StringBuilder markup,
            IEnumerable<KeyValuePair<string, object>> htmlAttributes)
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