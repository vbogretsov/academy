using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Academy.Domain.DataAccess
{
    public interface IPageData<out T>
    {
        IEnumerable<T> Data
        {
            get;
        }

        //int PageSize
        //{
        //    get;
        //}

        int PageNumber
        {
            get;
        }

        //int TotalCount
        //{
        //    get;
        //}

        int PagesCount
        {
            get;
        }
    }
}
