using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Academy.Utils.Collections
{
    public static class EnumerableExtensions
    {
        public static void Each<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            if (enumerable != null)
            {
                foreach (var item in enumerable)
                {
                    action(item);
                }
            }
        }
    }
}
