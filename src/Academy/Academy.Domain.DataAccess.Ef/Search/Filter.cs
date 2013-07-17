using System;
using System.Collections.Generic;

namespace Academy.Domain.DataAccess.Ef.Search
{
    internal abstract class Filter<T>
    {
        protected delegate IEnumerable<T> ItemFilter(IEnumerable<T> articles);

        private readonly ICollection<ItemFilter> filters;

        protected Filter()
        {
            filters = new List<ItemFilter>();
        }

        public IEnumerable<T> Select(IEnumerable<T> items)
        {
            var result = items;
            foreach (var filter in filters)
            {
                result = filter(result);
            }
            return result;
        }

        protected void AddFilter(ItemFilter filter)
        {
            filters.Add(filter);
        }
    }
}
