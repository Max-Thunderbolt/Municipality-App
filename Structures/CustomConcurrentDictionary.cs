using System;
using System.Collections;
using System.Collections.Generic;

namespace Municipality_App.Structures
{
    /// <summary>
    /// Thread-safe wrapper around CustomDictionary using lock statements
    /// Provides thread-safe dictionary operations for concurrent access
    /// </summary>
    public class CustomConcurrentDictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
    {
        private readonly CustomDictionary<TKey, TValue> _dictionary;
        private readonly object _lockObject = new object();

        /// <summary>
        /// Gets the number of key-value pairs in the dictionary
        /// </summary>
        public int Count
        {
            get
            {
                lock (_lockObject)
                {
                    return _dictionary.Count;
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of CustomConcurrentDictionary
        /// </summary>
        public CustomConcurrentDictionary()
        {
            _dictionary = new CustomDictionary<TKey, TValue>();
        }

        /// <summary>
        /// Initializes a new instance of CustomConcurrentDictionary with specified capacity
        /// </summary>
        public CustomConcurrentDictionary(int capacity)
        {
            _dictionary = new CustomDictionary<TKey, TValue>(capacity);
        }

        /// <summary>
        /// Adds a key-value pair or updates the value if the key exists
        /// Thread-safe operation
        /// </summary>
        public void AddOrUpdate(TKey key, TValue value)
        {
            lock (_lockObject)
            {
                _dictionary.AddOrUpdate(key, value);
            }
        }

        /// <summary>
        /// Adds a key-value pair or updates the value if the key exists using a factory function
        /// Thread-safe operation
        /// </summary>
        public TValue AddOrUpdate(
            TKey key,
            TValue addValue,
            Func<TKey, TValue, TValue> updateValueFactory
        )
        {
            lock (_lockObject)
            {
                if (_dictionary.TryGetValue(key, out TValue existingValue))
                {
                    TValue newValue = updateValueFactory(key, existingValue);
                    _dictionary.AddOrUpdate(key, newValue);
                    return newValue;
                }
                else
                {
                    _dictionary.AddOrUpdate(key, addValue);
                    return addValue;
                }
            }
        }

        /// <summary>
        /// Gets the value associated with the specified key
        /// Thread-safe operation
        /// </summary>
        public bool TryGetValue(TKey key, out TValue value)
        {
            lock (_lockObject)
            {
                return _dictionary.TryGetValue(key, out value);
            }
        }

        /// <summary>
        /// Determines whether the dictionary contains the specified key
        /// Thread-safe operation
        /// </summary>
        public bool ContainsKey(TKey key)
        {
            lock (_lockObject)
            {
                return _dictionary.ContainsKey(key);
            }
        }

        /// <summary>
        /// Removes all key-value pairs from the dictionary
        /// Thread-safe operation
        /// </summary>
        public void Clear()
        {
            lock (_lockObject)
            {
                _dictionary.Clear();
            }
        }

        /// <summary>
        /// Removes the value with the specified key
        /// Thread-safe operation
        /// </summary>
        public bool TryRemove(TKey key, out TValue value)
        {
            lock (_lockObject)
            {
                if (_dictionary.TryGetValue(key, out value))
                {
                    return _dictionary.Remove(key);
                }
                return false;
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the dictionary
        /// Note: The enumeration is not thread-safe and should be used with caution
        /// </summary>
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            // Create a snapshot to avoid issues during enumeration
            CustomList<KeyValuePair<TKey, TValue>> snapshot;
            lock (_lockObject)
            {
                snapshot = new CustomList<KeyValuePair<TKey, TValue>>();
                foreach (var kvp in _dictionary)
                {
                    snapshot.Add(kvp);
                }
            }

            foreach (var kvp in snapshot)
            {
                yield return kvp;
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
