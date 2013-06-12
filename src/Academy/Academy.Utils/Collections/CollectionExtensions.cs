using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Academy.Utils.Collections
{
    public static class CollectionExtensions
    {
        public static void Add<T>(
            this ICollection<T> collection,
            IEnumerable<T> items)
        {
            foreach (T item in items)
            {
                collection.Add(item);
            }
        }
    }
}
