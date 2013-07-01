using System;
using System.Collections.Generic;

namespace Academy.Presentation.ViewModels
{
    public class PageViewModel<T>
    {
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

        public int PageSize
        {
            get;
            set;
        }

        public int PagesCount
        {
            get;
            internal set;
        }
    }
}
