using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Academy.Utils.Trees
{
    public class TreeHelper<TId, TItem>
    {
        private readonly Func<TItem, TId> getId;
        private readonly Func<TItem, TId> getParentId;

        public TreeHelper(Func<TItem, TId> getId, Func<TItem, TId> getParentId)
        {
            this.getId = getId;
            this.getParentId = getParentId;
        }

        public IEnumerable<TItem> GetRoots(IEnumerable<TItem> collection)
        {
            var items = new HashSet<TId>();
            var parents = new Dictionary<TId, ICollection<TItem>>();
            foreach (var item in collection)
            {
                var parentId = getParentId(item);
                if (parents.ContainsKey(parentId))
                {
                    parents[parentId].Add(item);
                }
                else
                {
                    parents.Add(parentId, new List<TItem> { item });
                }
                items.Add(getId(item));
            }
            return parents.Keys.Where(id => !items.Contains(id)).SelectMany(id => parents[id]);
        }
    }
}
