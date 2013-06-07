using System;
using System.Collections.Generic;
using Academy.Utils.Trees;

namespace Academy.Utils
{
    public class TreeLoader<TId, TItem>
    {
        private readonly Func<TItem, TId> getId;
        private readonly Func<TItem, TId> getParentId;

        public TreeLoader(Func<TItem, TId> getId, Func<TItem, TId> getParentId)
        {
            this.getId = getId;
            this.getParentId = getParentId;
        }

        public Node<TItem> Load(IEnumerable<TItem> linearCollection)
        {
            var parents = new Dictionary<TId, ICollection<TItem>>();
            foreach (var item in linearCollection)
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
            }
            var root = new Node<TItem>(default(TItem));
            FillNode(default(TId), root, parents);
            return root;
        }

        private void FillNode(
            TId id,
            Node<TItem> node,
            IDictionary<TId, ICollection<TItem>> items)
        {
            if (items.ContainsKey(id))
            {
                var childs = items[id];
                foreach (TItem child in childs)
                {
                    var childId = getId(child);
                    var childNode = new Node<TItem>(child);
                    node.Childs.Add(childNode);
                    FillNode(childId, childNode, items);
                    items.Remove(childId);
                }
            }
        }
    }
}
