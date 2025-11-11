using System;
using System.Collections.Generic;

namespace Municipality_App.Structures.Trees
{
    public class BinaryTreeNode<T>
    {
        public T Value { get; set; }
        public BinaryTreeNode<T> Left { get; set; }
        public BinaryTreeNode<T> Right { get; set; }

        public BinaryTreeNode(T value)
        {
            Value = value;
        }
    }

    /// <summary>
    /// Basic binary tree that allows manual placement of nodes with traversal helpers.
    /// </summary>
    public class BinaryTree<T>
    {
        public BinaryTreeNode<T> Root { get; private set; }

        public BinaryTree(T rootValue)
        {
            Root = new BinaryTreeNode<T>(rootValue);
        }

        public BinaryTreeNode<T> InsertLeft(BinaryTreeNode<T> parent, T value)
        {
            if (parent == null)
                throw new ArgumentNullException(nameof(parent));

            var node = new BinaryTreeNode<T>(value);
            parent.Left = node;
            return node;
        }

        public BinaryTreeNode<T> InsertRight(BinaryTreeNode<T> parent, T value)
        {
            if (parent == null)
                throw new ArgumentNullException(nameof(parent));

            var node = new BinaryTreeNode<T>(value);
            parent.Right = node;
            return node;
        }

        public IEnumerable<T> TraversePreOrder()
        {
            var list = new List<T>();
            TraversePreOrder(Root, list);
            return list;
        }

        public IEnumerable<T> TraverseInOrder()
        {
            var list = new List<T>();
            TraverseInOrder(Root, list);
            return list;
        }

        public IEnumerable<T> TraversePostOrder()
        {
            var list = new List<T>();
            TraversePostOrder(Root, list);
            return list;
        }

        public IEnumerable<T> TraverseLevelOrder()
        {
            var queue = new Queue<BinaryTreeNode<T>>();
            var list = new List<T>();

            queue.Enqueue(Root);
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                list.Add(current.Value);

                if (current.Left != null)
                {
                    queue.Enqueue(current.Left);
                }

                if (current.Right != null)
                {
                    queue.Enqueue(current.Right);
                }
            }

            return list;
        }

        public int GetHeight()
        {
            return GetHeight(Root);
        }

        private static void TraversePreOrder(BinaryTreeNode<T> node, List<T> list)
        {
            if (node == null)
                return;
            list.Add(node.Value);
            TraversePreOrder(node.Left, list);
            TraversePreOrder(node.Right, list);
        }

        private static void TraverseInOrder(BinaryTreeNode<T> node, List<T> list)
        {
            if (node == null)
                return;
            TraverseInOrder(node.Left, list);
            list.Add(node.Value);
            TraverseInOrder(node.Right, list);
        }

        private static void TraversePostOrder(BinaryTreeNode<T> node, List<T> list)
        {
            if (node == null)
                return;
            TraversePostOrder(node.Left, list);
            TraversePostOrder(node.Right, list);
            list.Add(node.Value);
        }

        private static int GetHeight(BinaryTreeNode<T> node)
        {
            if (node == null)
                return 0;
            return 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));
        }
    }
}
