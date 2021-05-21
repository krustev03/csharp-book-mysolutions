using System;

namespace DynamicTree
{
    /// <summary> Represents a tree data structure </summary>
    /// <typeparam name="T">the type of the values in the tree</typeparam>
    public class Tree<T>
    {
        // The root of the tree
        private TreeNode<T> root;

        /// <summary> Constructs the tree </summary>
        /// <param name="value">the value of the node</param>
        public Tree(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("Cannot insert null value!");
            }

            this.root = new TreeNode<T>(value);
        }

        /// <summary> Constructs the tree </summary>
        /// <param name="value">the value of the node</param>
        /// <param name="children">the children of the root node</param>
        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {
            foreach (Tree<T> child in children)
            {
                this.root.AddChild(child.root);
            }
        }

        /// <summary> The root node or null if the tree is empty </summary>
        public TreeNode<T> Root => this.root;

        /// <summary> Traverses and prints tree in Depth First Search (DFS) order </summary>
        /// <param name="root">the root of the tree to be traversed</param>
        /// <param name="spaces">the spaces used for representation of the parent-child relation</param>
        private void TraverseDFS(TreeNode<T> root, string spaces)
        {
            if (this.root == null)
            {
                return;
            }

            Console.WriteLine(spaces + root.Value);

            TreeNode<T> child = null;
            for (int i = 0; i < root.ChildrenCount; i++)
            {
                child = root.GetChild(i);
                TraverseDFS(child, spaces + "   ");
            }
        }

        /// <summary> Traverses & prints tree in Depth First Search (DFS) order </summary>
        public void PrintDFS() => this.TraverseDFS(this.root, string.Empty);
    }
}
