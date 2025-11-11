using System;
using System.Collections.Generic;
using Municipality_App.Structures.Helpers;

namespace Municipality_App.Structures.Trees
{
    /// <summary>
    /// Unbalanced binary search tree supporting ordered insertion, lookup, and deletion.
    /// </summary>
    public class BinarySearchTree<TKey, TValue>
    {
        private TreeNode<TKey, TValue> _root;
        private int _count;
        private readonly IComparer<TKey> _comparer;

        public int Count => _count;

        public BinarySearchTree()
        {
            _comparer = Comparer<TKey>.Default;
        }

        public BinarySearchTree(IComparer<TKey> comparer)
        {
            _comparer = comparer ?? Comparer<TKey>.Default;
        }

        public void Insert(TKey key, TValue value)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            _root = InsertInternal(_root, key, value);
        }

        public bool ContainsKey(TKey key)
        {
            return FindNode(_root, key) != null;
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            var node = FindNode(_root, key);
            if (node != null)
            {
                value = node.Value;
                return true;
            }

            value = default;
            return false;
        }

        public bool Remove(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            bool removed = false;
            _root = RemoveInternal(_root, key, ref removed);
            if (removed)
            {
                _count--;
            }

            return removed;
        }

        public IEnumerable<KeyValuePair<TKey, TValue>> InOrderTraversal()
        {
            var stack = new Stack<TreeNode<TKey, TValue>>();
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

        private TreeNode<TKey, TValue> InsertInternal(
            TreeNode<TKey, TValue> node,
            TKey key,
            TValue value
        )
        {
            if (node == null)
            {
                _count++;
                return new TreeNode<TKey, TValue>(key, value);
            }

            int comparison = _comparer.Compare(key, node.Key);
            if (comparison < 0)
            {
                node.Left = InsertInternal(node.Left, key, value);
            }
            else if (comparison > 0)
            {
                node.Right = InsertInternal(node.Right, key, value);
            }
            else
            {
                node.Value = value;
            }

            return node;
        }

        private TreeNode<TKey, TValue> FindNode(TreeNode<TKey, TValue> node, TKey key)
        {
            while (node != null)
            {
                int comparison = _comparer.Compare(key, node.Key);
                if (comparison == 0)
                    return node;

                node = comparison < 0 ? node.Left : node.Right;
            }

            return null;
        }

        private TreeNode<TKey, TValue> RemoveInternal(
            TreeNode<TKey, TValue> node,
            TKey key,
            ref bool removed
        )
        {
            if (node == null)
                return null;

            int comparison = _comparer.Compare(key, node.Key);
            if (comparison < 0)
            {
                node.Left = RemoveInternal(node.Left, key, ref removed);
                return node;
            }

            if (comparison > 0)
            {
                node.Right = RemoveInternal(node.Right, key, ref removed);
                return node;
            }

            // Node found
            removed = true;

            if (node.Left == null)
                return node.Right;
            if (node.Right == null)
                return node.Left;

            // Two children: replace with inorder successor
            var successor = GetMin(node.Right);
            node.Key = successor.Key;
            node.Value = successor.Value;

            bool dummy = false;
            node.Right = RemoveInternal(node.Right, successor.Key, ref dummy);
            return node;
        }

        private static TreeNode<TKey, TValue> GetMin(TreeNode<TKey, TValue> node)
        {
            while (node.Left != null)
            {
                node = node.Left;
            }
            return node;
        }
    }
}
