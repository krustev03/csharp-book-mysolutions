using System;

namespace _02.PrintRootsWithKVertices
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

        private void TraverseDFSAndFindRootsWithKVertices(TreeNode<T> root, string spaces, int k)
        {
            if (this.root == null)
            {
                return;
            }

            if (root.ChildrenCount == k)
            {
                for (int i = 0; i < root.ChildrenCount; i++)
                {
                    Console.Write(root.GetChild(i).Value + " ");
                }
                Console.WriteLine();
            }

            TreeNode<T> child = null;
            for (int i = 0; i < root.ChildrenCount; i++)
            {
                child = root.GetChild(i);
                TraverseDFSAndFindRootsWithKVertices(child, spaces + "   ", k);
            }
        }

        public void PrintRootsWithKVertices(int k) => this.TraverseDFSAndFindRootsWithKVertices(this.root, string.Empty, k);
    }
}
