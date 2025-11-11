using System;
using System.Collections.Generic;

namespace Municipality_App.Structures.Trees
{
    public enum RedBlackNodeColor
    {
        Red,
        Black,
    }

    internal class RedBlackNode<TKey, TValue>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }
        public RedBlackNodeColor Color { get; set; }
        public RedBlackNode<TKey, TValue> Left { get; set; }
        public RedBlackNode<TKey, TValue> Right { get; set; }
        public RedBlackNode<TKey, TValue> Parent { get; set; }

        public RedBlackNode(TKey key, TValue value)
        {
            Key = key;
            Value = value;
            Color = RedBlackNodeColor.Red;
        }
    }

    /// <summary>
    /// Balanced red-black tree providing O(log n) insert and lookup operations.
    /// </summary>
    public class RedBlackTree<TKey, TValue>
    {
        private RedBlackNode<TKey, TValue> _root;
        private readonly IComparer<TKey> _comparer;
        private int _count;

        public int Count => _count;

        public RedBlackTree()
        {
            _comparer = Comparer<TKey>.Default;
        }

        public RedBlackTree(IComparer<TKey> comparer)
        {
            _comparer = comparer ?? Comparer<TKey>.Default;
        }

        public void Insert(TKey key, TValue value)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            var node = new RedBlackNode<TKey, TValue>(key, value);
            InsertNode(node);
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            var node = FindNode(key);
            if (node != null)
            {
                value = node.Value;
                return true;
            }

            value = default;
            return false;
        }

        public bool ContainsKey(TKey key)
        {
            return FindNode(key) != null;
        }

        public IEnumerable<KeyValuePair<TKey, TValue>> InOrderTraversal()
        {
            var stack = new Stack<RedBlackNode<TKey, TValue>>();
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

        private void InsertNode(RedBlackNode<TKey, TValue> node)
        {
            RedBlackNode<TKey, TValue> parent = null;
            var current = _root;

            while (current != null)
            {
                parent = current;
                int comparison = _comparer.Compare(node.Key, current.Key);
                if (comparison == 0)
                {
                    current.Value = node.Value;
                    return;
                }
                current = comparison < 0 ? current.Left : current.Right;
            }

            node.Parent = parent;
            if (parent == null)
            {
                _root = node;
            }
            else if (_comparer.Compare(node.Key, parent.Key) < 0)
            {
                parent.Left = node;
            }
            else
            {
                parent.Right = node;
            }

            node.Color = RedBlackNodeColor.Red;
            _count++;
            FixInsert(node);
        }

        private void FixInsert(RedBlackNode<TKey, TValue> node)
        {
            while (
                node != _root && node.Parent != null && node.Parent.Color == RedBlackNodeColor.Red
            )
            {
                var grandParent = node.Parent.Parent;
                if (grandParent != null && node.Parent == grandParent.Left)
                {
                    var uncle = grandParent.Right;
                    if (uncle != null && uncle.Color == RedBlackNodeColor.Red)
                    {
                        node.Parent.Color = RedBlackNodeColor.Black;
                        uncle.Color = RedBlackNodeColor.Black;
                        grandParent.Color = RedBlackNodeColor.Red;
                        node = grandParent;
                    }
                    else
                    {
                        if (node == node.Parent.Right)
                        {
                            node = node.Parent;
                            RotateLeft(node);
                        }
                        node.Parent.Color = RedBlackNodeColor.Black;
                        grandParent.Color = RedBlackNodeColor.Red;
                        RotateRight(grandParent);
                    }
                }
                else if (grandParent != null)
                {
                    var uncle = grandParent.Left;
                    if (uncle != null && uncle.Color == RedBlackNodeColor.Red)
                    {
                        node.Parent.Color = RedBlackNodeColor.Black;
                        uncle.Color = RedBlackNodeColor.Black;
                        grandParent.Color = RedBlackNodeColor.Red;
                        node = grandParent;
                    }
                    else
                    {
                        if (node == node.Parent.Left)
                        {
                            node = node.Parent;
                            RotateRight(node);
                        }
                        node.Parent.Color = RedBlackNodeColor.Black;
                        grandParent.Color = RedBlackNodeColor.Red;
                        RotateLeft(grandParent);
                    }
                }
                else
                {
                    break;
                }
            }

            _root.Color = RedBlackNodeColor.Black;
        }

        private void RotateLeft(RedBlackNode<TKey, TValue> node)
        {
            var pivot = node.Right;
            node.Right = pivot.Left;
            if (pivot.Left != null)
            {
                pivot.Left.Parent = node;
            }

            pivot.Parent = node.Parent;
            if (node.Parent == null)
            {
                _root = pivot;
            }
            else if (node == node.Parent.Left)
            {
                node.Parent.Left = pivot;
            }
            else
            {
                node.Parent.Right = pivot;
            }

            pivot.Left = node;
            node.Parent = pivot;
        }

        private void RotateRight(RedBlackNode<TKey, TValue> node)
        {
            var pivot = node.Left;
            node.Left = pivot.Right;
            if (pivot.Right != null)
            {
                pivot.Right.Parent = node;
            }

            pivot.Parent = node.Parent;
            if (node.Parent == null)
            {
                _root = pivot;
            }
            else if (node == node.Parent.Right)
            {
                node.Parent.Right = pivot;
            }
            else
            {
                node.Parent.Left = pivot;
            }

            pivot.Right = node;
            node.Parent = pivot;
        }

        private RedBlackNode<TKey, TValue> FindNode(TKey key)
        {
            var current = _root;
            while (current != null)
            {
                int comparison = _comparer.Compare(key, current.Key);
                if (comparison == 0)
                    return current;
                current = comparison < 0 ? current.Left : current.Right;
            }

            return null;
        }
    }
}
