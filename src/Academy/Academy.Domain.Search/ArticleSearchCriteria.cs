using System;
using System.Collections.Generic;

namespace Academy.Domain.Search
{
    public class ArticleSearchCriteria
    {
        public string Title
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public string Author
        {
            get;
            set;
        }

        public IEnumerable<int> Disciplines
        {
            get;
            set;
        }
    }
}
