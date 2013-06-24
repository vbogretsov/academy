using System;
using System.Collections.Generic;

namespace Academy.Domain.DataAccess.Ef.Search
{
    public static class PredicatesComputer
    {
        public static bool Compute<T>(IEnumerable<Predicate<T>> predicates, T argument)
        {
            bool result = true;
            foreach (var predicate in predicates)
            {
                result = predicate(argument);
                if (!result)
                {
                    break;
                }
            }
            return result;
        }
    }
}
