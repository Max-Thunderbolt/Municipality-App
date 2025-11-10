using System;
using System.Collections;
using System.Collections.Generic;

namespace Municipality_App.Structures
{
    /// <summary>
    /// Custom implementation of a stack using an array-based LIFO structure
    /// Provides O(1) push, pop, and peek operations
    /// </summary>
    public class CustomStack<T> : IEnumerable<T>
    {
        private T[] _items;
        private int _count;
        private const int DefaultCapacity = 4;

        /// <summary>
        /// Gets the number of elements in the stack
        /// </summary>
        public int Count => _count;

        /// <summary>
        /// Initializes a new instance of CustomStack with default capacity
        /// </summary>
        public CustomStack()
        {
            _items = new T[DefaultCapacity];
            _count = 0;
        }

        /// <summary>
        /// Initializes a new instance of CustomStack with specified capacity
        /// </summary>
        public CustomStack(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException(nameof(capacity));
            _items = new T[capacity];
            _count = 0;
        }

        /// <summary>
        /// Pushes an element onto the stack
        /// Time complexity: O(1) amortized
        /// </summary>
        public void Push(T item)
        {
            if (_count == _items.Length)
            {
                Resize(_items.Length * 2);
            }
            _items[_count] = item;
            _count++;
        }

        /// <summary>
        /// Removes and returns the element at the top of the stack
        /// Time complexity: O(1)
        /// </summary>
        public T Pop()
        {
            if (_count == 0)
                throw new InvalidOperationException("Stack is empty.");

            _count--;
            T item = _items[_count];
            _items[_count] = default(T);
            return item;
        }

        /// <summary>
        /// Returns the element at the top of the stack without removing it
        /// Time complexity: O(1)
        /// </summary>
        public T Peek()
        {
            if (_count == 0)
                throw new InvalidOperationException("Stack is empty.");

            return _items[_count - 1];
        }

        /// <summary>
        /// Removes all elements from the stack
        /// </summary>
        public void Clear()
        {
            Array.Clear(_items, 0, _count);
            _count = 0;
        }

        /// <summary>
        /// Converts the stack to a list (maintains LIFO order when iterated)
        /// </summary>
        public CustomList<T> ToList()
        {
            var list = new CustomList<T>();
            // Add in reverse order to maintain stack order
            for (int i = _count - 1; i >= 0; i--)
            {
                list.Add(_items[i]);
            }
            return list;
        }

        /// <summary>
        /// Resizes the internal array
        /// </summary>
        private void Resize(int newCapacity)
        {
            T[] newItems = new T[newCapacity];
            Array.Copy(_items, 0, newItems, 0, _count);
            _items = newItems;
        }

        /// <summary>
        /// Returns an enumerator that iterates through the stack (from top to bottom)
        /// </summary>
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = _count - 1; i >= 0; i--)
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
