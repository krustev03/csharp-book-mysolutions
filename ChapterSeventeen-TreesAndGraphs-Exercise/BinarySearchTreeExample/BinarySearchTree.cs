using System;

namespace BinarySearchTreeExample
{
    public class BinarySearchTree<T>
        where T : IComparable<T>
    {
        /// <summary> Represents a binary tree node </summary>
        /// <typeparam name="T">Specifies the type for the values in the nodes</typeparam>
        internal class BinaryTreeNode<T> : IComparable<BinaryTreeNode<T>>
            where T : IComparable<T>
        {
            // Contains the value of the node
            internal T Value { get; set; }

            // Contains the parent of the node
            internal BinaryTreeNode<T> Parent { get; set; }

            // Contains the left child of the node
            internal BinaryTreeNode<T> LeftChild;

            // Contains the right child of the node
            internal BinaryTreeNode<T> RightChild;

            /// <summary> Constructs the tree node </summary>
            /// <param name="value">the value of the tree node</param>
            public BinaryTreeNode(T value)
            {
                this.Value = value;
                this.Parent = null;
                this.LeftChild = null;
                this.RightChild = null;
            }

            public override string ToString() => this.Value.ToString();

            public override int GetHashCode() => this.Value.GetHashCode();

            public override bool Equals(object obj)
            {
                BinaryTreeNode<T> other = (BinaryTreeNode<T>)obj;
                return this.CompareTo(other) == 0;
            }

            public int CompareTo(BinaryTreeNode<T> other) =>
                this.Value.CompareTo(other.Value);
        }

        /// <summary> The root of the tree </summary>
        private BinaryTreeNode<T> root;

        /// <summary> Constructs the tree </summary>
        public BinarySearchTree()
        {
            this.root = null;
        }

        /// <summary> Inserts new value in the binary search tree </summary>
        /// <param name="value">the value to be inserted</param>
        public void Insert(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("Cannot insert null value!");
            }

            this.root = Insert(value, null, root);
        }

        /// <summary> Inserts node in the binary search tree by given value </summary>
        /// <param name="value">the new value</param>
        /// <param name="parentNode">the parent of the new node</param>
        /// <param name="node">current node</param>
        /// <returns>the inserted node</returns>
        private BinaryTreeNode<T> Insert(T value, BinaryTreeNode<T> parentNode, BinaryTreeNode<T> node)
        {
            if (node == null)
            {
                node = new BinaryTreeNode<T>(value);
                node.Parent = parentNode;
            }
            else
            {
                int compareTo = value.CompareTo(node.Value);

                if (compareTo < 0)
                {
                    node.LeftChild = Insert(value, node, node.LeftChild);
                }

                else if (compareTo > 0)
                {
                    node.RightChild = Insert(value, node, node.RightChild);
                }
            }

            return node;
        }

        /// <summary> Finds a given value in the tree and returns the node which contains it (when exists) </summary>
        /// <param name="value">the value to be found</param>
        /// <returns>the found node or null if not found</returns>
        private BinaryTreeNode<T> Find(T value)
        {
            BinaryTreeNode<T> node = this.root;

            while (node != null)
            {
                int compareTo = value.CompareTo(node.Value);

                if (compareTo < 0)
                {
                    node = node.LeftChild;
                }

                else if (compareTo > 0)
                {
                    node = node.RightChild;
                }
                else
                {
                    break;
                }
            }

            return node;
        }

        /// <summary> Returns whether given value exists in the tree </summary>
        /// <param name="value">the value to be checked</param>
        /// <returns>true if the value is found in the tree</returns>
        public bool Contains(T value) => this.Find(value) != null;

        /// <summary> Removes an element from the tree if exists </summary>
        /// <param name="value">the value to be removed</param>
        public void Remove(T value)
        {
            BinaryTreeNode<T> nodeToDelete = Find(value);

            if (nodeToDelete == null)
            {
                return;
            }

            Remove(nodeToDelete);
        }

        private void Remove(BinaryTreeNode<T> node)
        {
            // Case 3: If the node has two children.
            // Note that if we get here at the end the node will be with at most one child
            if (node.LeftChild != null && node.RightChild != null)
            {
                BinaryTreeNode<T> replacement = node.RightChild;
                
                while (replacement.LeftChild != null)
                {
                    replacement = replacement.LeftChild;
                }

                node.Value = replacement.Value;
                node = replacement;
            }

            // Case 1 and 2: If the node has at most one child
            BinaryTreeNode<T> theChild = node.LeftChild != null ? node.LeftChild : node.RightChild;

            // If the element to be deleted has one child
            if (theChild != null)
            {
                theChild.Parent = node.Parent;

                // Handle the case when the element is the root
                if (node.Parent == null)
                {
                    root = theChild;
                }
                else
                {
                    // Replace the element with its child subtree
                    if (node.Parent.LeftChild == node)
                    {
                        node.Parent.LeftChild = theChild;
                    }
                    else
                    {
                        node.Parent.RightChild = theChild;
                    }
                }
            }
            else
            {
                // Hadle the case when the element is the root
                if (node.Parent == null)
                {
                    root = null;
                }
                else
                {
                    // Remove the element - its a leaf
                    if (node.Parent.LeftChild == node)
                    {
                        node.Parent.LeftChild = null;
                    }
                    else
                    {
                        node.Parent.RightChild = null;
                    }
                }
            }
        }

        /// <summary> Traverses and prints the tree </summary>
        public void PrintTreeDFS()
        {
            this.PrintTreeDFS(this.root);
            Console.WriteLine();
        }

        /// <summary> Traverses and prints the ordered binary search tree starting from the given root node </summary>
        /// <param name="node">the starting node</param>
        private void PrintTreeDFS(BinaryTreeNode<T> node)
        {
            if (node != null)
            {
                PrintTreeDFS(node.LeftChild);
                Console.WriteLine(node.Value + " ");
                PrintTreeDFS(node.RightChild);
            }
        }
    }
}
