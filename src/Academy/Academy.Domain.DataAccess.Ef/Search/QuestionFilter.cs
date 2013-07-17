using System;
using System.Linq;
using Academy.Domain.Objects;
using Academy.Domain.Search;

namespace Academy.Domain.DataAccess.Ef.Search
{
    internal class QuestionFilter : Filter<Question>
    {
        public QuestionFilter(QuestionSearchCriteria criteria)
        {
            if(!String.IsNullOrEmpty(criteria.Keyword))
            {
                AddFilter(x => x.Where(q => q.Title.Contains(criteria.Keyword) ||
                    q.Text.Contains(criteria.Keyword)));
            }
            if (criteria.Disciplines != null)
            {
                AddFilter(x => x.Where(a => a.Disciplines.Any(
                    d => criteria.Disciplines.Contains(d.Id))));
            }
        }
    }
}
