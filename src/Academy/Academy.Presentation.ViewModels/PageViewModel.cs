using System;

namespace Academy.Presentation.ViewModels
{
    public class PageViewModel
    {
        public string AreaId
        {
            get;
            set;
        }

        public string UrlFormat
        {
            get;
            set;
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
