using System;
using System.Collections.Generic;

namespace Academy.Presentation.ViewModels
{
    public class PageDataViewModel<T> : PageViewModel
    {
        public IEnumerable<T> Items
        {
            get;
            internal set;
        }
    }
}
