using System;
using System.Collections.Generic;
using Academy.Utils.Trees;

namespace Academy.Utils
{
    public class TreeLoader<TItem, TKey>
    {
        private readonly Func<TItem, TKey> getId;
        private readonly Func<TItem, TKey> getParentId;

        public TreeLoader(Func<TItem, TKey> getId, Func<TItem, TKey> getParentId)
        {
            this.getId = getId;
            this.getParentId = getParentId;
        }

        public Node<TItem> Load(IEnumerable<TItem> linearCollection)
        {
            var parents = new Dictionary<TKey, ICollection<TItem>>();
            var items = new Dictionary<TKey, Node<TItem>>();
            foreach (var item in linearCollection)
            {
                //var key = getId(item);
                //items.Add(key, new Node<TItem>(item));
                var parentKey = getParentId(item);
                if (parents.ContainsKey(parentKey))
                {
                    parents[parentKey].Add(item);
                }
                else
                {
                    parents.Add(parentKey, new List<TItem> { item });
                }
            }
            Node<TItem> root = new Node<TItem>(default(TItem));
            FillNode(root, default(TKey), parents);
            return root;
        }

        private void FillNode(
            Node<TItem> node,
            TKey id,
            IDictionary<TKey, ICollection<TItem>> items)
        {
            if (items.ContainsKey(id))
            {
                var childs = items[id];
                foreach (TItem child in childs)
                {
                    var childId = getId(child);
                    var childNode = new Node<TItem>(child);
                    node.Childs.Add(childNode);
                    FillNode(childNode, childId, items);
                    items.Remove(childId);
                }
            }
        }
    }
}
