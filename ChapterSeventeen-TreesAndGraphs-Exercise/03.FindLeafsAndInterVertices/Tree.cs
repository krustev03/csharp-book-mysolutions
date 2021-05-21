using System;

namespace _03.FindLeafsAndInterVertices
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

        private int leavesCount = 0;
        private int internalVerticesCount = 0;
        private void TraverseDFSAndCountLeavesAndInternalVertices(TreeNode<T> root, string spaces)
        {
            if (this.root == null)
            {
                return;
            }

            TreeNode<T> child = null;

            if (root.ChildrenCount == 0)
            {
                leavesCount++;
            }
            else
            {
                internalVerticesCount++;
            }

            for (int i = 0; i < root.ChildrenCount; i++)
            {
                child = root.GetChild(i);
                TraverseDFSAndCountLeavesAndInternalVertices(child, spaces + "   ");
            }
        }

        public void PrintLeavesAndInternalVerticesCount()
        {
            this.TraverseDFSAndCountLeavesAndInternalVertices(this.root, string.Empty);
            Console.WriteLine("Leaves count: " + leavesCount);
            // We subtract the initial root
            Console.WriteLine("Internal vertices count: " + (internalVerticesCount - 1));
            leavesCount = 0;
            internalVerticesCount = 0;
        }
    }
}
