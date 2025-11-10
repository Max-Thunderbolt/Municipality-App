using System;
using System.Collections;
using System.Collections.Generic;

namespace Municipality_App.Structures
{
    /// <summary>
    /// Custom implementation of a hash set using hash table internally
    /// Provides O(1) average case add, remove, and contains operations
    /// </summary>
    public class CustomHashSet<T> : IEnumerable<T>
    {
        private CustomDictionary<T, bool> _dictionary;

        /// <summary>
        /// Gets the number of elements in the set
        /// </summary>
        public int Count => _dictionary.Count;

        /// <summary>
        /// Initializes a new instance of CustomHashSet
        /// </summary>
        public CustomHashSet()
        {
            _dictionary = new CustomDictionary<T, bool>();
        }

        /// <summary>
        /// Initializes a new instance of CustomHashSet with initial collection
        /// </summary>
        public CustomHashSet(IEnumerable<T> collection)
        {
            _dictionary = new CustomDictionary<T, bool>();
            if (collection != null)
            {
                foreach (var item in collection)
                {
                    Add(item);
                }
            }
        }

        /// <summary>
        /// Adds an element to the set
        /// Time complexity: O(1) average case
        /// </summary>
        public bool Add(T item)
        {
            if (Contains(item))
                return false;

            _dictionary.Add(item, true);
            return true;
        }

        /// <summary>
        /// Removes an element from the set
        /// Time complexity: O(1) average case
        /// </summary>
        public bool Remove(T item)
        {
            return _dictionary.Remove(item);
        }

        /// <summary>
        /// Determines whether the set contains the specified element
        /// Time complexity: O(1) average case
        /// </summary>
        public bool Contains(T item)
        {
            return _dictionary.ContainsKey(item);
        }

        /// <summary>
        /// Removes all elements from the set
        /// </summary>
        public void Clear()
        {
            _dictionary.Clear();
        }

        /// <summary>
        /// Converts the set to a list
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
        /// Returns an enumerator that iterates through the set
        /// </summary>
        public IEnumerator<T> GetEnumerator()
        {
            foreach (var key in _dictionary.Keys)
            {
                yield return key;
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
