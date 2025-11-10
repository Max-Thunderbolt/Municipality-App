using System;
using System.Collections;
using System.Collections.Generic;
using Municipality_App.Structures.Helpers;

namespace Municipality_App.Structures
{
    /// <summary>
    /// Custom implementation of a sorted dictionary using AVL tree
    /// Provides O(log n) insertion, deletion, and lookup operations
    /// Maintains keys in sorted order
    /// </summary>
    public class CustomSortedDictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
    {
        private TreeNode<TKey, TValue> _root;
        private int _count;
        private readonly IComparer<TKey> _comparer;

        /// <summary>
        /// Gets the number of key-value pairs in the dictionary
        /// </summary>
        public int Count => _count;

        /// <summary>
        /// Gets or sets the value associated with the specified key
        /// </summary>
        public TValue this[TKey key]
        {
            get
            {
                if (TryGetValue(key, out TValue value))
                    return value;
                throw new KeyNotFoundException($"The key '{key}' was not found in the dictionary.");
            }
            set { AddOrUpdate(key, value); }
        }

        /// <summary>
        /// Gets a collection containing the keys in sorted order
        /// </summary>
        public CustomList<TKey> Keys
        {
            get
            {
                var keys = new CustomList<TKey>();
                InOrderTraversal(_root, node => keys.Add(node.Key));
                return keys;
            }
        }

        /// <summary>
        /// Gets a collection containing the values in sorted key order
        /// </summary>
        public CustomList<TValue> Values
        {
            get
            {
                var values = new CustomList<TValue>();
                InOrderTraversal(_root, node => values.Add(node.Value));
                return values;
            }
        }

        /// <summary>
        /// Initializes a new instance of CustomSortedDictionary
        /// </summary>
        public CustomSortedDictionary()
        {
            _root = null;
            _count = 0;
            _comparer = Comparer<TKey>.Default;
        }

        /// <summary>
        /// Initializes a new instance of CustomSortedDictionary with custom comparer
        /// </summary>
        public CustomSortedDictionary(IComparer<TKey> comparer)
        {
            _root = null;
            _count = 0;
            _comparer = comparer ?? Comparer<TKey>.Default;
        }

        /// <summary>
        /// Adds a key-value pair to the dictionary
        /// Time complexity: O(log n)
        /// </summary>
        public void Add(TKey key, TValue value)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            if (ContainsKey(key))
                throw new ArgumentException($"An item with the key '{key}' already exists.");

            _root = Insert(_root, key, value);
            _count++;
        }

        /// <summary>
        /// Adds or updates a key-value pair in the dictionary
        /// </summary>
        public void AddOrUpdate(TKey key, TValue value)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            if (ContainsKey(key))
            {
                UpdateValue(_root, key, value);
            }
            else
            {
                _root = Insert(_root, key, value);
                _count++;
            }
        }

        /// <summary>
        /// Removes the value with the specified key
        /// Time complexity: O(log n)
        /// </summary>
        public bool Remove(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            int initialCount = _count;
            _root = Delete(_root, key);
            if (_count < initialCount)
            {
                _count--;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Determines whether the dictionary contains the specified key
        /// Time complexity: O(log n)
        /// </summary>
        public bool ContainsKey(TKey key)
        {
            if (key == null)
                return false;
            return Find(_root, key) != null;
        }

        /// <summary>
        /// Gets the value associated with the specified key
        /// Time complexity: O(log n)
        /// </summary>
        public bool TryGetValue(TKey key, out TValue value)
        {
            value = default(TValue);

            if (key == null)
                return false;

            var node = Find(_root, key);
            if (node != null)
            {
                value = node.Value;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Removes all key-value pairs from the dictionary
        /// </summary>
        public void Clear()
        {
            _root = null;
            _count = 0;
        }

        /// <summary>
        /// Finds a node with the given key
        /// </summary>
        private TreeNode<TKey, TValue> Find(TreeNode<TKey, TValue> node, TKey key)
        {
            if (node == null)
                return null;

            int comparison = _comparer.Compare(key, node.Key);
            if (comparison == 0)
                return node;
            else if (comparison < 0)
                return Find(node.Left, key);
            else
                return Find(node.Right, key);
        }

        /// <summary>
        /// Updates the value of an existing node
        /// </summary>
        private void UpdateValue(TreeNode<TKey, TValue> node, TKey key, TValue value)
        {
            if (node == null)
                return;

            int comparison = _comparer.Compare(key, node.Key);
            if (comparison == 0)
                node.Value = value;
            else if (comparison < 0)
                UpdateValue(node.Left, key, value);
            else
                UpdateValue(node.Right, key, value);
        }

        /// <summary>
        /// Inserts a new node into the AVL tree
        /// </summary>
        private TreeNode<TKey, TValue> Insert(TreeNode<TKey, TValue> node, TKey key, TValue value)
        {
            if (node == null)
                return new TreeNode<TKey, TValue>(key, value);

            int comparison = _comparer.Compare(key, node.Key);
            if (comparison < 0)
                node.Left = Insert(node.Left, key, value);
            else if (comparison > 0)
                node.Right = Insert(node.Right, key, value);
            else
                return node; // Key already exists (shouldn't happen if Add is called correctly)

            // Update height
            node.Height = 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));

            // Get balance factor
            int balance = GetBalance(node);

            // Left Left Case
            if (balance > 1 && _comparer.Compare(key, node.Left.Key) < 0)
                return RightRotate(node);

            // Right Right Case
            if (balance < -1 && _comparer.Compare(key, node.Right.Key) > 0)
                return LeftRotate(node);

            // Left Right Case
            if (balance > 1 && _comparer.Compare(key, node.Left.Key) > 0)
            {
                node.Left = LeftRotate(node.Left);
                return RightRotate(node);
            }

            // Right Left Case
            if (balance < -1 && _comparer.Compare(key, node.Right.Key) < 0)
            {
                node.Right = RightRotate(node.Right);
                return LeftRotate(node);
            }

            return node;
        }

        /// <summary>
        /// Deletes a node from the AVL tree
        /// </summary>
        private TreeNode<TKey, TValue> Delete(TreeNode<TKey, TValue> node, TKey key)
        {
            if (node == null)
                return node;

            int comparison = _comparer.Compare(key, node.Key);

            if (comparison < 0)
                node.Left = Delete(node.Left, key);
            else if (comparison > 0)
                node.Right = Delete(node.Right, key);
            else
            {
                // Node to delete found
                if (node.Left == null || node.Right == null)
                {
                    TreeNode<TKey, TValue> temp = node.Left ?? node.Right;
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
                    TreeNode<TKey, TValue> temp = GetMinValueNode(node.Right);
                    node.Key = temp.Key;
                    node.Value = temp.Value;
                    node.Right = Delete(node.Right, temp.Key);
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
        private TreeNode<TKey, TValue> GetMinValueNode(TreeNode<TKey, TValue> node)
        {
            TreeNode<TKey, TValue> current = node;
            while (current.Left != null)
                current = current.Left;
            return current;
        }

        /// <summary>
        /// Performs a right rotation
        /// </summary>
        private TreeNode<TKey, TValue> RightRotate(TreeNode<TKey, TValue> y)
        {
            TreeNode<TKey, TValue> x = y.Left;
            TreeNode<TKey, TValue> T2 = x.Right;

            x.Right = y;
            y.Left = T2;

            y.Height = Math.Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;
            x.Height = Math.Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;

            return x;
        }

        /// <summary>
        /// Performs a left rotation
        /// </summary>
        private TreeNode<TKey, TValue> LeftRotate(TreeNode<TKey, TValue> x)
        {
            TreeNode<TKey, TValue> y = x.Right;
            TreeNode<TKey, TValue> T2 = y.Left;

            y.Left = x;
            x.Right = T2;

            x.Height = Math.Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;
            y.Height = Math.Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;

            return y;
        }

        /// <summary>
        /// Gets the height of a node
        /// </summary>
        private int GetHeight(TreeNode<TKey, TValue> node)
        {
            return node == null ? 0 : node.Height;
        }

        /// <summary>
        /// Gets the balance factor of a node
        /// </summary>
        private int GetBalance(TreeNode<TKey, TValue> node)
        {
            return node == null ? 0 : GetHeight(node.Left) - GetHeight(node.Right);
        }

        /// <summary>
        /// Performs in-order traversal
        /// </summary>
        private void InOrderTraversal(
            TreeNode<TKey, TValue> node,
            Action<TreeNode<TKey, TValue>> action
        )
        {
            if (node != null)
            {
                InOrderTraversal(node.Left, action);
                action(node);
                InOrderTraversal(node.Right, action);
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the dictionary in sorted order
        /// </summary>
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            var stack = new CustomStack<TreeNode<TKey, TValue>>();
            var current = _root;

            while (current != null || stack.Count > 0)
            {
                while (current != null)
                {
                    stack.Push(current);
                    current = current.Left;
                }

                current = stack.Pop();
                yield return new KeyValuePair<TKey, TValue>(current.Key, current.Value);
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
