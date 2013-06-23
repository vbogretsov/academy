using System;
using System.Collections.Generic;

namespace Academy.Domain.Search
{
    public class SearchResult<T>
    {
        public SearchResult(IEnumerable<T> results)
        {
            Results = results;
        }

        public IEnumerable<T> Results
        {
            get; private set;
        }
    }
}
