using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Utils.Trees
{
    public class Node<T>
    {
        public Node(T value)
        {
            Value = value;
            Childs = new List<Node<T>>();
        }

        public override string ToString()
        {
            return !Value.Equals(default(T)) ? Value.ToString() : String.Empty;
        }

        public T Value
        {
            get;
            set;
        }

        public ICollection<Node<T>> Childs
        {
            get;
            private set;
        }
    }
}
