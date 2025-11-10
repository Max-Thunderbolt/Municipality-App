using System;
using System.Collections;
using System.Collections.Generic;

namespace Municipality_App.Structures
{
    /// <summary>
    /// Custom implementation of a queue using a circular array-based FIFO structure
    /// Provides O(1) enqueue, dequeue, and peek operations
    /// </summary>
    public class CustomQueue<T> : IEnumerable<T>
    {
        private T[] _items;
        private int _head;
        private int _tail;
        private int _count;
        private const int DefaultCapacity = 4;

        /// <summary>
        /// Gets the number of elements in the queue
        /// </summary>
        public int Count => _count;

        /// <summary>
        /// Initializes a new instance of CustomQueue with default capacity
        /// </summary>
        public CustomQueue()
        {
            _items = new T[DefaultCapacity];
            _head = 0;
            _tail = 0;
            _count = 0;
        }

        /// <summary>
        /// Initializes a new instance of CustomQueue with specified capacity
        /// </summary>
        public CustomQueue(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException(nameof(capacity));
            _items = new T[capacity];
            _head = 0;
            _tail = 0;
            _count = 0;
        }

        /// <summary>
        /// Adds an element to the end of the queue
        /// Time complexity: O(1) amortized
        /// </summary>
        public void Enqueue(T item)
        {
            if (_count == _items.Length)
            {
                Resize(_items.Length * 2);
            }

            _items[_tail] = item;
            _tail = (_tail + 1) % _items.Length;
            _count++;
        }

        /// <summary>
        /// Removes and returns the element at the beginning of the queue
        /// Time complexity: O(1)
        /// </summary>
        public T Dequeue()
        {
            if (_count == 0)
                throw new InvalidOperationException("Queue is empty.");

            T item = _items[_head];
            _items[_head] = default(T);
            _head = (_head + 1) % _items.Length;
            _count--;
            return item;
        }

        /// <summary>
        /// Returns the element at the beginning of the queue without removing it
        /// Time complexity: O(1)
        /// </summary>
        public T Peek()
        {
            if (_count == 0)
                throw new InvalidOperationException("Queue is empty.");

            return _items[_head];
        }

        /// <summary>
        /// Removes all elements from the queue
        /// </summary>
        public void Clear()
        {
            Array.Clear(_items, 0, _items.Length);
            _head = 0;
            _tail = 0;
            _count = 0;
        }

        /// <summary>
        /// Converts the queue to a list (maintains FIFO order)
        /// </summary>
        public CustomList<T> ToList()
        {
            var list = new CustomList<T>();
            foreach (var item in this)
            {
                list.Add(item);
            }
            return list;
        }

        /// <summary>
        /// Resizes the internal array and reorganizes elements
        /// </summary>
        private void Resize(int newCapacity)
        {
            T[] newItems = new T[newCapacity];

            if (_count > 0)
            {
                if (_head < _tail)
                {
                    // Elements are in a contiguous block
                    Array.Copy(_items, _head, newItems, 0, _count);
                }
                else
                {
                    // Elements wrap around the array
                    int elementsFromHead = _items.Length - _head;
                    Array.Copy(_items, _head, newItems, 0, elementsFromHead);
                    Array.Copy(_items, 0, newItems, elementsFromHead, _tail);
                }
            }

            _items = newItems;
            _head = 0;
            _tail = _count;
        }

        /// <summary>
        /// Returns an enumerator that iterates through the queue (from head to tail)
        /// </summary>
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _count; i++)
            {
                int index = (_head + i) % _items.Length;
                yield return _items[index];
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
