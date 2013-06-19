using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Academy.Presentation.ViewModels;
using Academy.Utils.Html;

namespace Academy.Presentation.Views.Helpers
{
    public class DisciplinesCheckboxesTreeBuilder : CheckboxesTreeBuilder<DisciplineViewModel>
    {
        private const string SpanFormat =
            "<span class='label' id='{1}[{0}].Name' name ='{1}[{0}].Name'>{2}</span>";

        private const string HiddedForNameFormat =
            "<input type='hidden' id='{1}[{0}].Name' name='{1}[{0}].Name' value='{2}'/>";

        private const string HiddenForParentIdFormat =
            "<input type='hidden' id='{1}[{0}].ParentId' name='{1}[{0}].ParentId' value='{2}'/>";

        public DisciplinesCheckboxesTreeBuilder(
            string collectionName,
            IEnumerable<DisciplineViewModel> selecttedItems = null)
            :base(collectionName, x => x.Id, selecttedItems)
        {
        }

        protected override void AppendNodeConent(DisciplineViewModel value)
        {
            AppendHtml("<img src='/Resources/Icons/tree-plus.png'>");
            base.AppendNodeConent(value);
            AppendHtml(SpanFormat, value.Id, CollectionName, value.Name);
            //AppendHtml(HiddedForNameFormat, value.Id, CollectionName, value.Name);
            //AppendHtml(HiddenForParentIdFormat, value.Id, CollectionName, value.ParentId);
        }

        protected override void AppendLeafContent(DisciplineViewModel value)
        {
            base.AppendLeafContent(value);
            AppendHtml(SpanFormat, value.Id, CollectionName, value.Name);
            //AppendHtml(HiddedForNameFormat, value.Id, CollectionName, value.Name);
            //AppendHtml(HiddenForParentIdFormat, value.Id, CollectionName, value.ParentId);
        }
    }
}