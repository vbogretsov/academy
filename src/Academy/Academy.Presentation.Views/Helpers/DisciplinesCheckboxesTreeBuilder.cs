using System;
using System.Collections.Generic;
using Academy.Presentation.ViewModels;
using Academy.Utils.Html;

namespace Academy.Presentation.Views.Helpers
{
    public class DisciplinesCheckboxesTreeBuilder : CheckboxesTreeBuilder<DisciplineViewModel>
    {
        private const string SpanFormat =
            "<span class='label' id='{1}[{0}].Name' name ='{1}[{0}].Name'>{2}</span>";

        public DisciplinesCheckboxesTreeBuilder(
            string collectionName,
            IEnumerable<DisciplineViewModel> selecttedItems = null)
            :base(collectionName, x => x.Id, selecttedItems)
        {
        }

        protected override void AppendNodeConent(DisciplineViewModel value)
        {
            AppendHtml("<img src='/Content/Images/tree-plus.png'>");
            base.AppendNodeConent(value);
            AppendHtml(SpanFormat, value.Id, CollectionName, value.Name);
        }

        protected override void AppendLeafContent(DisciplineViewModel value)
        {
            base.AppendLeafContent(value);
            AppendHtml(SpanFormat, value.Id, CollectionName, value.Name);
        }
    }
}