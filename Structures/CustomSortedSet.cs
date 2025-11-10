using System;
using System.Collections;
using System.Collections.Generic;
using Municipality_App.Structures.Helpers;

namespace Municipality_App.Structures
{
    /// <summary>
    /// Custom implementation of a sorted set using AVL tree
    /// Provides O(log n) insertion, deletion, and lookup operations
    /// Maintains elements in sorted order
    /// </summary>
    public class CustomSortedSet<T> : IEnumerable<T>
    {
        private TreeNode<T> _root;
        private int _count;
        private readonly IComparer<T> _comparer;

        /// <summary>
        /// Gets the number of elements in the set
        /// </summary>
        public int Count => _count;

        /// <summary>
        /// Initializes a new instance of CustomSortedSet
        /// </summary>
        public CustomSortedSet()
        {
            _root = null;
            _count = 0;
            _comparer = Comparer<T>.Default;
        }

        /// <summary>
        /// Initializes a new instance of CustomSortedSet with custom comparer
        /// </summary>
        public CustomSortedSet(IComparer<T> comparer)
        {
            _root = null;
            _count = 0;
            _comparer = comparer ?? Comparer<T>.Default;
        }

        /// <summary>
        /// Initializes a new instance of CustomSortedSet with initial collection
        /// </summary>
        public CustomSortedSet(IEnumerable<T> collection)
            : this()
        {
            if (collection != null)
            {
                foreach (var item in collection)
                {
                    Add(item);
                }
            }
        }

        /// <summary>
        /// Adds an element to the set
        /// Time complexity: O(log n)
        /// </summary>
        public bool Add(T item)
        {
            int initialCount = _count;
            _root = Insert(_root, item);
            return _count > initialCount;
        }

        /// <summary>
        /// Removes an element from the set
        /// Time complexity: O(log n)
        /// </summary>
        public bool Remove(T item)
        {
            int initialCount = _count;
            _root = Delete(_root, item);
            if (_count < initialCount)
            {
                _count--;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Determines whether the set contains the specified element
        /// Time complexity: O(log n)
        /// </summary>
        public bool Contains(T item)
        {
            return Find(_root, item) != null;
        }

        /// <summary>
        /// Removes all elements from the set
        /// </summary>
        public void Clear()
        {
            _root = null;
            _count = 0;
        }

        /// <summary>
        /// Finds a node with the given value
        /// </summary>
        private TreeNode<T> Find(TreeNode<T> node, T value)
        {
            if (node == null)
                return null;

            int comparison = _comparer.Compare(value, node.Value);
            if (comparison == 0)
                return node;
            else if (comparison < 0)
                return Find(node.Left, value);
            else
                return Find(node.Right, value);
        }

        /// <summary>
        /// Inserts a new node into the AVL tree
        /// </summary>
        private TreeNode<T> Insert(TreeNode<T> node, T value)
        {
            if (node == null)
            {
                _count++;
                return new TreeNode<T>(value);
            }

            int comparison = _comparer.Compare(value, node.Value);
            if (comparison < 0)
                node.Left = Insert(node.Left, value);
            else if (comparison > 0)
                node.Right = Insert(node.Right, value);
            else
                return node; // Value already exists

            // Update height
            node.Height = 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));

            // Get balance factor
            int balance = GetBalance(node);

            // Left Left Case
            if (balance > 1 && _comparer.Compare(value, node.Left.Value) < 0)
                return RightRotate(node);

            // Right Right Case
            if (balance < -1 && _comparer.Compare(value, node.Right.Value) > 0)
                return LeftRotate(node);

            // Left Right Case
            if (balance > 1 && _comparer.Compare(value, node.Left.Value) > 0)
            {
                node.Left = LeftRotate(node.Left);
                return RightRotate(node);
            }

            // Right Left Case
            if (balance < -1 && _comparer.Compare(value, node.Right.Value) < 0)
            {
                node.Right = RightRotate(node.Right);
                return LeftRotate(node);
            }

            return node;
        }

        /// <summary>
        /// Deletes a node from the AVL tree
        /// </summary>
        private TreeNode<T> Delete(TreeNode<T> node, T value)
        {
            if (node == null)
                return node;

            int comparison = _comparer.Compare(value, node.Value);

            if (comparison < 0)
                node.Left = Delete(node.Left, value);
            else if (comparison > 0)
                node.Right = Delete(node.Right, value);
            else
            {
                // Node to delete found
                if (node.Left == null || node.Right == null)
                {
                    TreeNode<T> temp = node.Left ?? node.Right;
                    if (temp == null)
                    {
                        temp = node;
                        node = null;
                    }
                    else
                    {
                        node = temp;
                    }
                }
                else
                {
                    // Node with two children: get inorder successor
                    TreeNode<T> temp = GetMinValueNode(node.Right);
                    node.Value = temp.Value;
                    node.Right = Delete(node.Right, temp.Value);
                }
            }

            if (node == null)
                return node;

            // Update height
            node.Height = 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));

            // Get balance factor
            int balance = GetBalance(node);

            // Left Left Case
            if (balance > 1 && GetBalance(node.Left) >= 0)
                return RightRotate(node);

            // Left Right Case
            if (balance > 1 && GetBalance(node.Left) < 0)
            {
                node.Left = LeftRotate(node.Left);
                return RightRotate(node);
            }

            // Right Right Case
            if (balance < -1 && GetBalance(node.Right) <= 0)
                return LeftRotate(node);

            // Right Left Case
            if (balance < -1 && GetBalance(node.Right) > 0)
            {
                node.Right = RightRotate(node.Right);
                return LeftRotate(node);
            }

            return node;
        }

        /// <summary>
        /// Gets the minimum value node in a subtree
        /// </summary>
        private TreeNode<T> GetMinValueNode(TreeNode<T> node)
        {
            TreeNode<T> current = node;
            while (current.Left != null)
                current = current.Left;
            return current;
        }

        /// <summary>
        /// Performs a right rotation
        /// </summary>
        private TreeNode<T> RightRotate(TreeNode<T> y)
        {
            TreeNode<T> x = y.Left;
            TreeNode<T> T2 = x.Right;

            x.Right = y;
            y.Left = T2;

            y.Height = Math.Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;
            x.Height = Math.Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;

            return x;
        }

        /// <summary>
        /// Performs a left rotation
        /// </summary>
        private TreeNode<T> LeftRotate(TreeNode<T> x)
        {
            TreeNode<T> y = x.Right;
            TreeNode<T> T2 = y.Left;

            y.Left = x;
            x.Right = T2;

            x.Height = Math.Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;
            y.Height = Math.Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;

            return y;
        }

        /// <summary>
        /// Gets the height of a node
        /// </summary>
        private int GetHeight(TreeNode<T> node)
        {
            return node == null ? 0 : node.Height;
        }

        /// <summary>
        /// Gets the balance factor of a node
        /// </summary>
        private int GetBalance(TreeNode<T> node)
        {
            return node == null ? 0 : GetHeight(node.Left) - GetHeight(node.Right);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the set in sorted order
        /// </summary>
        public IEnumerator<T> GetEnumerator()
        {
            var stack = new CustomStack<TreeNode<T>>();
            var current = _root;

            while (current != null || stack.Count > 0)
            {
                while (current != null)
                {
                    stack.Push(current);
                    current = current.Left;
                }

                current = stack.Pop();
                yield return current.Value;
                current = current.Right;
            }
        }

        /// <summary>
        /// Returns a non-generic enumerator
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
