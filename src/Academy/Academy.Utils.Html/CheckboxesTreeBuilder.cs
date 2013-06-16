using System;
using System.Collections.Generic;
using Academy.Utils.Html;

namespace Academy.Utils.Html
{
    public class CheckboxesTreeBuilder<T> : HtmlTreeBuilder<T>
    {
        private const string HiddenFormat =
            "<input type='hidden' name='{1}.index' autocomplete='off' value='{0}'>";

        private const string UncheckedCheckboxFormat =
            "<input type='checkbox' class='checkbox' id='{1}[{0}].Id' name='{1}[{0}].Id' value='{0}'/>";

        private const string CheckedCheckboxFormat =
            "<input type='checkbox' class='checkbox' id='{1}[{0}].Id' name='{1}[{0}].Id' checked='checked' value='{0}'/>";

        private const string SpanFormat =
            "<span class='label' id='{1}[{0}].Name' name ='{1}[{0}].Name'>{2}</span>";

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
            AppendHtml(HiddenFormat, getId(value), collectionName);
            AppendHtml(getCheckbox(value));
            AppendHtml(SpanFormat, getId(value), collectionName, getName(value));
        }

        protected override void AppendLeafContent(T value)
        {
            AppendHtml(HiddenFormat, getId(value), collectionName);
            AppendHtml(getCheckbox(value));
            AppendHtml(SpanFormat, getId(value), collectionName, getName(value));
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