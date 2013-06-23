using System;
using System.Collections.Generic;

namespace Academy.Domain.Search
{
    public class QuestionSearchCriteria
    {
        public string Title
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
