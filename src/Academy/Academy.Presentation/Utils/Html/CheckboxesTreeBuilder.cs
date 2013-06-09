using System;
using System.Collections.Generic;

namespace Academy.Presentation.Utils.Html
{
    public class CheckboxesTreeBuilder<T> : HtmlTreeBuilder<T>
    {
        private const string UncheckedCheckboxFormat =
            "<input type='checkbox' class='checkbox' name='{1}' value='{0}'/>";

        private const string CheckedCheckboxFormat =
            "<input type='checkbox' class='checkbox' name='{1}' checked='checked' value='{0}'/>";

        private const string SpanFormat =
            "<span class='label'>{0}</span>";

        private readonly Func<T, object> getId;

        private readonly Func<T, object> getName;

        private readonly Func<T, string> getCheckbox;

        private readonly string collectionName;

        public CheckboxesTreeBuilder(
            string collectionName, // TODO: add collection name using
            Func<T, object> getId,
            Func<T, string> getName,
            IEnumerable<T> checkedItesms = null)
        {
            this.collectionName = collectionName;
            this.getId = getId;
            this.getName = getName;
            if (checkedItesms != null)
            {
                ISet<T> selectedItems = new HashSet<T>(checkedItesms);
                getCheckbox = x => GetCheckbox(x, selectedItems);
            }
            else
            {
                getCheckbox = GetCheckbox;
            }
        }

        protected override void AppendNodeConent(T value)
        {
            AppendHtml("<img src='/Resources/Icons/tree-plus.png'>");
            AppendHtml(getCheckbox(value));
            AppendHtml(SpanFormat, getName(value));
        }

        protected override void AppendLeafContent(T value)
        {
            AppendHtml(getCheckbox(value));
            AppendHtml(SpanFormat, getName(value));
        }

        private string GetCheckbox(T value, ICollection<T> selectedItems)
        {
            return String.Format(
                selectedItems.Contains(value)
                ? CheckedCheckboxFormat
                : UncheckedCheckboxFormat,
                getId(value),
                collectionName);
        }

        private string GetCheckbox(T value)
        {
            return String.Format(
                UncheckedCheckboxFormat,
                getId(value),
                collectionName);
        }
    }
}