using System;
using System.Collections.Generic;

namespace Academy.Presentation.ViewModels
{
    public class PageViewModel<T>
    {
        public string GetPageUrl(int pageNumber)
        {
            return String.Format(PageUrl, pageNumber);
        }

        public IEnumerable<T> Items
        {
            get;
            internal set;
        }

        public int PageNumber
        {
            get;
            internal set;
        }

        public int PagesCount
        {
            get;
            internal set;
        }

        public string PageUrl
        {
            get;
            set;
        }
    }
}
