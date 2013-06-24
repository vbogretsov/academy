using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Academy.Domain.Objects;
using Academy.Domain.Search;

namespace Academy.Domain.DataAccess.Ef.Search
{
    internal class QuestionPredicateBuilder
    {
        public IEnumerable<Predicate<Question>> Build(QuestionSearchCriteria criteria)
        {
            if (criteria.Title != null)
            {
                yield return question => question.Title.Contains(criteria.Title);
            }
            if (criteria.Disciplines != null)
            {
                yield return question => question.Disciplines.Any(
                    discipline => criteria.Disciplines.Contains(discipline.Id));
            }
            yield return question => true;
        }
    }
}
