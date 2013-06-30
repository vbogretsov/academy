using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Academy.Domain.DataAccess.Ef
{
    internal class PageData<T> : IPageData<T>
    {
        public PageData(IEnumerable<T> data, int pageNumber, int pagesCount)
        {
            Data = data;
            PageNumber = pageNumber;
            PagesCount = pagesCount;
        }

        public IEnumerable<T> Data
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
