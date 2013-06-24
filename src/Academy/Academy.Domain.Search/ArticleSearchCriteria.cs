using System;
using System.Collections.Generic;

namespace Academy.Domain.Search
{
    public class ArticleSearchCriteria
    {
        private IEnumerable<int> disciplines;

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
            get
            {
                return disciplines;
            }
            set
            {
                disciplines = value != null ? new HashSet<int>(value) : null;
            }
        }
    }
}
