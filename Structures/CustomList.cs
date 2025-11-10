using System;
using System.Collections;
using System.Collections.Generic;

namespace Municipality_App.Structures
{
    /// <summary>
    /// Custom implementation of a dynamic list using an array-based structure
    /// Provides O(1) indexed access, O(1) amortized insertion, O(n) removal
    /// </summary>
    public class CustomList<T> : IEnumerable<T>
    {
        private T[] _items;
        private int _count;
        private const int DefaultCapacity = 4;

        /// <summary>
        /// Gets the number of elements in the list
        /// </summary>
        public int Count => _count;

        /// <summary>
        /// Gets or sets the element at the specified index
        /// </summary>
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= _count)
                    throw new ArgumentOutOfRangeException(nameof(index));
                return _items[index];
            }
            set
            {
                if (index < 0 || index >= _count)
                    throw new ArgumentOutOfRangeException(nameof(index));
                _items[index] = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of CustomList with default capacity
        /// </summary>
        public CustomList()
        {
            _items = new T[DefaultCapacity];
            _count = 0;
        }

        /// <summary>
        /// Initializes a new instance of CustomList with specified capacity
        /// </summary>
        public CustomList(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException(nameof(capacity));
            _items = new T[capacity];
            _count = 0;
        }

        /// <summary>
        /// Initializes a new instance of CustomList with initial collection
        /// </summary>
        public CustomList(IEnumerable<T> collection)
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection));

            _items = new T[DefaultCapacity];
            _count = 0;

            foreach (var item in collection)
            {
                Add(item);
            }
        }

        /// <summary>
        /// Adds an item to the end of the list
        /// Time complexity: O(1) amortized
        /// </summary>
        public void Add(T item)
        {
            if (_count == _items.Length)
            {
                Resize(_items.Length * 2);
            }
            _items[_count] = item;
            _count++;
        }

        /// <summary>
        /// Adds multiple items to the list
        /// </summary>
        public void AddRange(IEnumerable<T> collection)
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection));

            foreach (var item in collection)
            {
                Add(item);
            }
        }

        /// <summary>
        /// Removes the first occurrence of the specified item
        /// Time complexity: O(n)
        /// </summary>
        public bool Remove(T item)
        {
            int index = IndexOf(item);
            if (index >= 0)
            {
                RemoveAt(index);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Removes the item at the specified index
        /// Time complexity: O(n)
        /// </summary>
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _count)
                throw new ArgumentOutOfRangeException(nameof(index));

            _count--;
            if (index < _count)
            {
                Array.Copy(_items, index + 1, _items, index, _count - index);
            }
            _items[_count] = default(T);
        }

        /// <summary>
        /// Removes all items from the list
        /// </summary>
        public void Clear()
        {
            Array.Clear(_items, 0, _count);
            _count = 0;
        }

        /// <summary>
        /// Determines whether the list contains the specified item
        /// Time complexity: O(n)
        /// </summary>
        public bool Contains(T item)
        {
            return IndexOf(item) >= 0;
        }

        /// <summary>
        /// Returns the zero-based index of the first occurrence of the item
        /// Time complexity: O(n)
        /// </summary>
        public int IndexOf(T item)
        {
            for (int i = 0; i < _count; i++)
            {
                if (EqualityComparer<T>.Default.Equals(_items[i], item))
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Inserts an item at the specified index
        /// Time complexity: O(n)
        /// </summary>
        public void Insert(int index, T item)
        {
            if (index < 0 || index > _count)
                throw new ArgumentOutOfRangeException(nameof(index));

            if (_count == _items.Length)
            {
                Resize(_items.Length * 2);
            }

            if (index < _count)
            {
                Array.Copy(_items, index, _items, index + 1, _count - index);
            }

            _items[index] = item;
            _count++;
        }

        /// <summary>
        /// Copies the list elements to an array
        /// </summary>
        public T[] ToArray()
        {
            T[] array = new T[_count];
            Array.Copy(_items, 0, array, 0, _count);
            return array;
        }

        /// <summary>
        /// Returns a list containing all elements
        /// </summary>
        public CustomList<T> ToList()
        {
            return new CustomList<T>(this);
        }

        /// <summary>
        /// Resizes the internal array to the specified capacity
        /// </summary>
        private void Resize(int newCapacity)
        {
            T[] newItems = new T[newCapacity];
            Array.Copy(_items, 0, newItems, 0, _count);
            _items = newItems;
        }

        /// <summary>
        /// Returns an enumerator that iterates through the list
        /// </summary>
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _count; i++)
            {
                yield return _items[i];
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
