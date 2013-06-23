using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Academy.Presentation.ViewModels
{
    public class ArticleSearchResultViewModel
    {
        public IEnumerable<ArticleViewModel> Articles
        {
            get;
            set;
        }
    }
}
