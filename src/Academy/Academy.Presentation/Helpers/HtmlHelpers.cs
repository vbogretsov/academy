using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Academy.Presentation.Utils.Html;
using Academy.Utils.Trees;

namespace Academy.Presentation.Helpers
{
    public static class HtmlHelpers
    {
        public static MvcHtmlString CheckboxesTree<TModel, T>(
            this HtmlHelper<TModel> html,
            string collectionName,
            Node<T> root,
            Func<T, object> getId,
            Func<T, string> getName,
            IEnumerable<T> checkedItems)
        {
            var builder = new CheckboxesTreeBuilder<T>(collectionName, getId, getName, checkedItems);
            return builder.BuildHtmlTree(root);
        }
    }
}