namespace Municipality_App.Structures.Helpers
{
    /// <summary>
    /// Node for binary search tree structures
    /// </summary>
    internal class TreeNode<TKey, TValue>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }
        public TreeNode<TKey, TValue> Left { get; set; }
        public TreeNode<TKey, TValue> Right { get; set; }
        public int Height { get; set; }

        public TreeNode(TKey key, TValue value)
        {
            Key = key;
            Value = value;
            Left = null;
            Right = null;
            Height = 1;
        }
    }

    /// <summary>
    /// Node for binary search tree structures (value-only, for sets)
    /// </summary>
    internal class TreeNode<T>
    {
        public T Value { get; set; }
        public TreeNode<T> Left { get; set; }
        public TreeNode<T> Right { get; set; }
        public int Height { get; set; }

        public TreeNode(T value)
        {
            Value = value;
            Left = null;
            Right = null;
            Height = 1;
        }
    }
}
