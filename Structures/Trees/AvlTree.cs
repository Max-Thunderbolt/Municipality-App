using System;
using System.Collections.Generic;
using Municipality_App.Structures.Helpers;

namespace Municipality_App.Structures.Trees
{
    /// <summary>
    /// Self-balancing AVL tree for ordered key/value storage with O(log n) operations.
    /// </summary>
    public class AvlTree<TKey, TValue>
    {
        private TreeNode<TKey, TValue> _root;
        private int _count;
        private readonly IComparer<TKey> _comparer;

        public int Count => _count;

        public AvlTree()
        {
            _comparer = Comparer<TKey>.Default;
        }

        public AvlTree(IComparer<TKey> comparer)
        {
            _comparer = comparer ?? Comparer<TKey>.Default;
        }

        public void Insert(TKey key, TValue value)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            _root = InsertInternal(_root, key, value, out bool insertedNew);
            if (insertedNew)
                _count++;
        }

        public void AddOrUpdate(TKey key, TValue value)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            _root = InsertInternal(_root, key, value, out bool insertedNew);
            if (insertedNew)
                _count++;
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            value = default;
            var node = FindNode(_root, key);
            if (node == null)
                return false;
            value = node.Value;
            return true;
        }

        public bool Remove(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            bool removed = false;
            _root = DeleteInternal(_root, key, ref removed);
            if (removed)
                _count--;
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
            TValue value,
            out bool insertedNew
        )
        {
            if (node == null)
            {
                insertedNew = true;
                return new TreeNode<TKey, TValue>(key, value);
            }

            int comparison = _comparer.Compare(key, node.Key);
            if (comparison < 0)
            {
                node.Left = InsertInternal(node.Left, key, value, out insertedNew);
            }
            else if (comparison > 0)
            {
                node.Right = InsertInternal(node.Right, key, value, out insertedNew);
            }
            else
            {
                node.Value = value;
                insertedNew = false;
                return node;
            }

            UpdateHeight(node);
            return Balance(node);
        }

        private TreeNode<TKey, TValue> DeleteInternal(
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
                node.Left = DeleteInternal(node.Left, key, ref removed);
            }
            else if (comparison > 0)
            {
                node.Right = DeleteInternal(node.Right, key, ref removed);
            }
            else
            {
                removed = true;

                if (node.Left == null || node.Right == null)
                {
                    node = node.Left ?? node.Right;
                }
                else
                {
                    var successor = GetMin(node.Right);
                    node.Key = successor.Key;
                    node.Value = successor.Value;
                    bool dummy = false;
                    node.Right = DeleteInternal(node.Right, successor.Key, ref dummy);
                }
            }

            if (node == null)
                return null;

            UpdateHeight(node);
            return Balance(node);
        }

        private TreeNode<TKey, TValue> Balance(TreeNode<TKey, TValue> node)
        {
            int balanceFactor = GetBalance(node);

            if (balanceFactor > 1)
            {
                if (GetBalance(node.Left) < 0)
                {
                    node.Left = RotateLeft(node.Left);
                }
                return RotateRight(node);
            }

            if (balanceFactor < -1)
            {
                if (GetBalance(node.Right) > 0)
                {
                    node.Right = RotateRight(node.Right);
                }
                return RotateLeft(node);
            }

            return node;
        }

        private static TreeNode<TKey, TValue> RotateLeft(TreeNode<TKey, TValue> node)
        {
            var pivot = node.Right;
            var temp = pivot.Left;

            pivot.Left = node;
            node.Right = temp;

            UpdateHeight(node);
            UpdateHeight(pivot);

            return pivot;
        }

        private static TreeNode<TKey, TValue> RotateRight(TreeNode<TKey, TValue> node)
        {
            var pivot = node.Left;
            var temp = pivot.Right;

            pivot.Right = node;
            node.Left = temp;

            UpdateHeight(node);
            UpdateHeight(pivot);

            return pivot;
        }

        private static void UpdateHeight(TreeNode<TKey, TValue> node)
        {
            node.Height = 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));
        }

        private static int GetHeight(TreeNode<TKey, TValue> node)
        {
            return node?.Height ?? 0;
        }

        private static int GetBalance(TreeNode<TKey, TValue> node)
        {
            return node == null ? 0 : GetHeight(node.Left) - GetHeight(node.Right);
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
