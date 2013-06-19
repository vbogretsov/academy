using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Academy.Presentation.ViewModels;
using Academy.Utils.Html;

namespace Academy.Presentation.Views.Helpers
{
    public class DisciplinesTreeBuilder : HtmlTreeBuilder<DisciplineViewModel>
    {
        protected override void AppendNodeConent(DisciplineViewModel value)
        {
            throw new NotImplementedException();
        }

        protected override void AppendLeafContent(DisciplineViewModel value)
        {
            throw new NotImplementedException();
        }
    }
}