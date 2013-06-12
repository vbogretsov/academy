using System;
using System.Text;
using System.Web.Mvc;
using Academy.Utils.Trees;

namespace Academy.Utils.Html
{
    public abstract class HtmlTreeBuilder<T>
    {
        private const int IndentSize = 4;

        private readonly StringBuilder tree;

        private int indent;

        protected HtmlTreeBuilder()
        {
            tree = new StringBuilder();
        }

        public MvcHtmlString BuildHtmlTree(Node<T> root)
        {
            BginTree();
            foreach (var child in root.Childs)
            {
                AppendRootForTree(child);
            }
            EndTree();
            return new MvcHtmlString(tree.ToString());
        }

        private void BginTree()
        {
            AppendHtml("<div class='tree'>");
            AppendHtml("<ul>");
        }

        private void EndTree()
        {
            AppendHtml("</ul>");
            AppendHtml("</div>");
        }

        private void AppendRootForTree(Node<T> root)
        {
            AddNode(root, "class='root'");
        }

        private void AppendNode(Node<T> node)
        {
            indent += IndentSize;
            //AppendHtml("<img src='/Resources/Icons/tree-plus.png'>");
            AppendNodeConent(node.Value);
            AppendHtml("<ul>");
            foreach (var child in node.Childs)
            {
                AddNode(child);
            }
            AppendHtml("</ul>");
            indent -= IndentSize;
        }

        private void AppendLeaf(Node<T> node)
        {
            indent += IndentSize;
            //AppendNodeConent(node.Value);
            AppendLeafContent(node.Value);
            indent -= IndentSize;
        }

        private void AddNode(Node<T> node, params object[] args)
        {
            indent += IndentSize;
            AppendHtml(args.Length > 0 ? "<li {0}>" : "<li>", args);
            if (node.Childs.Count > 0)
            {
                AppendNode(node);
            }
            else
            {
                AppendLeaf(node);
            }
            AppendHtml("</li>");
            indent -= IndentSize;
        }

        protected void AppendHtml(string format, params object[] args)
        {
            tree.Append(' ', indent);
            tree.AppendFormat(format, args);
            tree.AppendLine();
        }

        protected abstract void AppendNodeConent(T value);

        protected abstract void AppendLeafContent(T value);
    }
}