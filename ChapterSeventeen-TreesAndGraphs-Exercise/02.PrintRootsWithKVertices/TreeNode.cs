using System;
using System.Collections.Generic;

namespace _02.PrintRootsWithKVertices
{
    /// <summary> Represents a tree node </summary>
    /// <typeparam name="T">the type of the values in nodes</typeparam>
    public class TreeNode<T>
    {
        // Contains the value in the node
        private T value;

        // Shows whether the current node has parent
        private bool hasParent;

        // Contains the children of the node
        private List<TreeNode<T>> children;

        /// <summary> Constructs a tree node </summary>
        /// <param name="value">the value of the node</param>
        public TreeNode(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("Cannot insert null value!");
            }

            this.value = value;
            this.children = new List<TreeNode<T>>();
        }

        /// <summary> The value of the node </summary>
        public T Value
        {
            get => this.value;
            set => this.value = value;
        }

        /// <summary> The number of node's children </summary>
        public int ChildrenCount => this.children.Count;

        /// <summary> Adds child to the node </summary>
        /// <param name="child">the child to be added</param>
        public void AddChild(TreeNode<T> child)
        {
            if (child == null)
            {
                throw new ArgumentNullException("Cannot insert null value!");
            }

            if (child.hasParent)
            {
                throw new ArgumentNullException("The node already has a parent!");
            }

            child.hasParent = true;
            this.children.Add(child);
        }

        /// <summary> Gets the child of the node at given index </summary>
        /// <param name="index">the index of the desired child</param>
        /// <returns>the child of on the given position</returns>
        public TreeNode<T> GetChild(int index)
        {
            return this.children[index];
        }
    }
}
