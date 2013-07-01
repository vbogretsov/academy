using System;
using System.Collections.Generic;

namespace Academy.Domain.DataAccess.Ef
{
    internal class PageData<T> : IPageData<T>
    {
        public PageData(IEnumerable<T> data, int page, int size, int pagesCount)
        {
            Data = data;
            PageNumber = page;
            PageSize = size;
            PagesCount = pagesCount;
        }

        public IEnumerable<T> Data
        {
            get;
            private set;
        }

        public int PageSize
        {
            get;
            private set;
        }

        public int PageNumber
        {
            get;
            private set;
        }

        public int PagesCount
        {
            get;
            private set;
        }
    }
}
