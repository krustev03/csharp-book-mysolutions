using System;
using System.Collections.Generic;

namespace _05.BTVerticesOnlyL
{
    /// <summary> Represents a binary tree node </summary>
    /// <typeparam name="T">the type of the values in the tree</typeparam>
    public class BinaryTree<T>
    {
        /// <summary> Constructs a binary tree </summary>
        /// <param name="value">the value of the tree</param>
        /// <param name="leftChild">the left child of the tree</param>
        /// <param name="rightChild">the right child of the tree</param>
        public BinaryTree(T value, BinaryTree<T> leftChild, BinaryTree<T> rightChild)
        {
            this.Value = value;
            this.LeftChild = leftChild;
            this.RightChild = rightChild;
        }

        /// <summary> Constructs a binary tree with no children </summary>
        /// <param name="value">the value of the tree</param>
        public BinaryTree(T value)
            : this(value, null, null)
        {
        }

        /// <summary> The value stored in the current node </summary>
        public T Value { get; set; }

        /// <summary> The left child of the current node </summary>
        public BinaryTree<T> LeftChild { get; set; }

        /// <summary> The right child of the current node </summary>
        public BinaryTree<T> RightChild { get; set; }

        public void PrintInOrder()
        {
            // 1. Visit the left child
            if (this.LeftChild != null)
            {
                this.LeftChild.PrintInOrder();
            }

            // 2. Visit the root of this subtree
            Console.Write(this.Value + " ");

            // 3. Visit the right child
            if (this.RightChild != null)
            {
                this.RightChild.PrintInOrder();
            }
        }

        public void PrintVerticesWhoOnlyHaveLeaves(List<string> values)
        {
            bool leftIsLeaf = false;
            bool rightIsLeaf = false;

            if (this.LeftChild != null)
            {
                if (this.LeftChild.LeftChild == null && this.LeftChild.RightChild == null)
                {
                    leftIsLeaf = true;
                }
            }
            else
            {
                leftIsLeaf = true;
            }

            if (this.RightChild != null)
            {
                if (this.RightChild.LeftChild == null && this.RightChild.RightChild == null)
                {
                    rightIsLeaf = true;
                }
            }
            else
            {
                rightIsLeaf = true;
            }

            if (this.LeftChild == null && this.RightChild == null)
            {
                leftIsLeaf = false;
                rightIsLeaf = false;
            }

            if (leftIsLeaf && rightIsLeaf)
            {
                values.Add(this.Value.ToString());
            }

            // 2. Visit the left child
            if (this.LeftChild != null)
            {
                this.LeftChild.PrintVerticesWhoOnlyHaveLeaves(values);
            }

            // 3. Visit the right child
            if (this.RightChild != null)
            {
                this.RightChild.PrintVerticesWhoOnlyHaveLeaves(values);
            }
        }

        public void PrintVerticesWhoOnlyHaveLeaves()
        {
            var values = new List<string>();
            PrintVerticesWhoOnlyHaveLeaves(values);

            foreach (var item in values)
            {
                Console.WriteLine(item);
            }
        }

        public void PrintPostOrder()
        {
            // 1. Visit the left child
            if (this.LeftChild != null)
            {
                this.LeftChild.PrintPostOrder();
            }

            // 2. Visit the right child
            if (this.RightChild != null)
            {
                this.RightChild.PrintPostOrder();
            }

            // 3. Visit the root of this subtree
            Console.Write(this.Value + " ");
        }
    }
}
