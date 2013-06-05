using System;
using System.Text;
using Academy.Utils.Trees;

namespace Academy.Test
{
    public static class HtmlTree
    {
        private const int IndentSize = 4;

        public static string Tree<T>(
            Node<T> root)
        {
            StringBuilder tree = new StringBuilder();
            tree.AppendLine("<div class='tree'>");
            int indent = IndentSize;
            AppendHtml(tree, "<ul>", indent);
            foreach (var child in root.Childs)
            {
                AppendRootForTree(child, tree, ref indent);
            }
            AppendHtml(tree, "</ul>", indent);
            tree.AppendLine("</div>");
            return tree.ToString();
        }

        private static void AppendRootForTree<T>(
            Node<T> root,
            StringBuilder tree,
            ref int indent)
        {
            AddNode(root, tree, ref indent, "class='root'");
        }

        private static void AddNode<T>(
            Node<T> node,
            StringBuilder tree,
            ref int indent,
            params object[] args)
        {
            indent += IndentSize;
            AppendHtml(tree, args.Length > 0 ? "<li {0}>" : "<li>", indent, args);
            if (node.Childs.Count > 0)
            {
                AppendNode(node, tree, ref indent);
            }
            else
            {
                AppendLeaf(node, tree, ref indent);
            }
            AppendHtml(tree, "</li>", indent);
            indent -= IndentSize;
        }

        private static void AppendNode<T>(
            Node<T> node,
            StringBuilder tree,
            ref int indent)
        {
            indent += IndentSize;
            AppendHtml(tree, "<img src='tree-plus.png'>", indent);
            AppendHtml(tree, "<input type='checkbox' class='checkbox'/>", indent);
            AppendHtml(tree, "<span class='label'>{0}</span>", indent, node);
            AppendHtml(tree, "<ul>", indent);
            foreach (var child in node.Childs)
            {
                AddNode(child, tree, ref indent);
            }
            AppendHtml(tree, "</ul>", indent);
            indent -= IndentSize;
        }

        private static void AppendLeaf<T>(
            Node<T> node,
            StringBuilder tree,
            ref int indent)
        {
            indent += IndentSize;
            AppendHtml(tree, "<input type='checkbox' class='checkbox'/>", indent);
            AppendHtml(tree, "<span class='label'>{0}</span>", indent, node.Value);
            indent -= IndentSize;
        }

        private static void AppendHtml(
            StringBuilder html,
            string format,
            int indent,
            params object[] args)
        {
            html.Append(' ', indent);
            html.AppendFormat(format, args);
            html.AppendLine();
        }
    }
}
