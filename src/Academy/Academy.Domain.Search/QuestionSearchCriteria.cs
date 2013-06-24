using System;
using System.Collections.Generic;

namespace Academy.Domain.Search
{
    public class QuestionSearchCriteria
    {
        private IEnumerable<int> disciplines;

        public string Keyword
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
