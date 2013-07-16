using System;
using System.Collections.Generic;

namespace Academy.Domain.Search
{
    public class SearchResult<T>
    {
        public SearchResult(ICollection<T> results)
        {
            Results = results;
            ResultsCount = results.Count;
        }

        public IEnumerable<T> Results
        {
            get;
            private set;
        }

        public int ResultsCount
        {
            get;
            private set;
        }
    }
}
