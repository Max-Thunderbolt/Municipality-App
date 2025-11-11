using System;
using System.Collections.Generic;

namespace Municipality_App.Structures.Heaps
{
    /// <summary>
    /// Binary min-heap implementation backed by a dynamic array.
    /// Provides O(log n) insert and extract-min operations.
    /// </summary>
    public class MinHeap<T>
    {
        private readonly Structures.CustomList<T> _items;
        private readonly IComparer<T> _comparer;

        public int Count => _items.Count;

        public MinHeap()
            : this(null) { }

        public MinHeap(IComparer<T> comparer)
        {
            _items = new Structures.CustomList<T>();
            _comparer = comparer ?? Comparer<T>.Default;
        }

        public void Insert(T value)
        {
            _items.Add(value);
            HeapifyUp(_items.Count - 1);
        }

        public T Peek()
        {
            if (_items.Count == 0)
                throw new InvalidOperationException("Heap is empty.");
            return _items[0];
        }

        public T ExtractMin()
        {
            if (_items.Count == 0)
                throw new InvalidOperationException("Heap is empty.");

            var min = _items[0];
            var last = _items[_items.Count - 1];
            _items[0] = last;
            _items.RemoveAt(_items.Count - 1);

            if (_items.Count > 0)
            {
                HeapifyDown(0);
            }

            return min;
        }

        public bool TryExtractMin(out T value)
        {
            if (_items.Count == 0)
            {
                value = default;
                return false;
            }

            value = ExtractMin();
            return true;
        }

        public void BuildHeap(IEnumerable<T> values)
        {
            if (values == null)
                throw new ArgumentNullException(nameof(values));

            foreach (var value in values)
            {
                _items.Add(value);
            }

            for (int i = ParentIndex(_items.Count - 1); i >= 0; i--)
            {
                HeapifyDown(i);
            }
        }

        public void Clear()
        {
            _items.Clear();
        }

        private void HeapifyUp(int index)
        {
            while (index > 0)
            {
                int parentIndex = ParentIndex(index);
                if (_comparer.Compare(_items[index], _items[parentIndex]) >= 0)
                    break;

                Swap(index, parentIndex);
                index = parentIndex;
            }
        }

        private void HeapifyDown(int index)
        {
            while (true)
            {
                int left = LeftChildIndex(index);
                int right = RightChildIndex(index);
                int smallest = index;

                if (left < _items.Count && _comparer.Compare(_items[left], _items[smallest]) < 0)
                {
                    smallest = left;
                }

                if (right < _items.Count && _comparer.Compare(_items[right], _items[smallest]) < 0)
                {
                    smallest = right;
                }

                if (smallest == index)
                    break;

                Swap(index, smallest);
                index = smallest;
            }
        }

        private void Swap(int a, int b)
        {
            var temp = _items[a];
            _items[a] = _items[b];
            _items[b] = temp;
        }

        private static int ParentIndex(int index) => (index - 1) / 2;

        private static int LeftChildIndex(int index) => (index * 2) + 1;

        private static int RightChildIndex(int index) => (index * 2) + 2;
    }
}
