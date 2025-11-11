using System;
using System.Collections.Generic;
using Municipality_App.Structures;

namespace Municipality_App.Structures.Trees
{
    /// <summary>
    /// Node representation for a general-purpose (n-ary) tree.
    /// </summary>
    public class BasicTreeNode<T>
    {
        public T Value { get; }
        public BasicTreeNode<T> Parent { get; private set; }
        public CustomList<BasicTreeNode<T>> Children { get; }

        public BasicTreeNode(T value)
        {
            Value = value;
            Children = new CustomList<BasicTreeNode<T>>();
        }

        internal void SetParent(BasicTreeNode<T> parent)
        {
            Parent = parent;
        }

        public BasicTreeNode<T> AddChild(T childValue)
        {
            var child = new BasicTreeNode<T>(childValue);
            AddChild(child);
            return child;
        }

        public void AddChild(BasicTreeNode<T> child)
        {
            if (child == null)
                throw new ArgumentNullException(nameof(child));

            child.SetParent(this);
            Children.Add(child);
        }
    }

    /// <summary>
    /// Provides traversal and search helpers for a basic tree structure.
    /// </summary>
    public class BasicTree<T>
    {
        public BasicTreeNode<T> Root { get; }

        public BasicTree(T rootValue)
        {
            Root = new BasicTreeNode<T>(rootValue);
        }

        public BasicTreeNode<T> AddChild(BasicTreeNode<T> parent, T value)
        {
            if (parent == null)
                throw new ArgumentNullException(nameof(parent));
            return parent.AddChild(value);
        }

        public IEnumerable<T> TraverseDepthFirst()
        {
            var stack = new CustomStack<BasicTreeNode<T>>();
            stack.Push(Root);

            while (stack.Count > 0)
            {
                var current = stack.Pop();
                yield return current.Value;

                for (int i = current.Children.Count - 1; i >= 0; i--)
                {
                    stack.Push(current.Children[i]);
                }
            }
        }

        public IEnumerable<T> TraverseBreadthFirst()
        {
            var queue = new CustomQueue<BasicTreeNode<T>>();
            queue.Enqueue(Root);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                yield return current.Value;

                foreach (var child in current.Children)
                {
                    queue.Enqueue(child);
                }
            }
        }

        public BasicTreeNode<T> Find(Predicate<T> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            var queue = new CustomQueue<BasicTreeNode<T>>();
            queue.Enqueue(Root);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                if (predicate(current.Value))
                    return current;

                foreach (var child in current.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return null;
        }
    }
}
