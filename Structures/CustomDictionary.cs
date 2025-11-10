using System;
using System.Collections;
using System.Collections.Generic;

namespace Municipality_App.Structures
{
    /// <summary>
    /// Hash table entry for chaining collision resolution
    /// </summary>
    internal class HashTableEntry<TKey, TValue>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }
        public HashTableEntry<TKey, TValue> Next { get; set; }

        public HashTableEntry(TKey key, TValue value)
        {
            Key = key;
            Value = value;
            Next = null;
        }
    }

    /// <summary>
    /// Custom implementation of a dictionary using hash table with chaining for collision resolution
    /// Provides O(1) average case lookup, insertion, and deletion
    /// </summary>
    public class CustomDictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
    {
        private HashTableEntry<TKey, TValue>[] _buckets;
        private int _count;
        private const int DefaultCapacity = 16;
        private const double LoadFactor = 0.75;

        /// <summary>
        /// Gets the number of key-value pairs in the dictionary
        /// </summary>
        public int Count => _count;

        /// <summary>
        /// Gets or sets the value associated with the specified key
        /// </summary>
        public TValue this[TKey key]
        {
            get
            {
                if (TryGetValue(key, out TValue value))
                    return value;
                throw new KeyNotFoundException($"The key '{key}' was not found in the dictionary.");
            }
            set { AddOrUpdate(key, value); }
        }

        /// <summary>
        /// Gets a collection containing the keys in the dictionary
        /// </summary>
        public CustomList<TKey> Keys
        {
            get
            {
                var keys = new CustomList<TKey>();
                foreach (var kvp in this)
                {
                    keys.Add(kvp.Key);
                }
                return keys;
            }
        }

        /// <summary>
        /// Gets a collection containing the values in the dictionary
        /// </summary>
        public CustomList<TValue> Values
        {
            get
            {
                var values = new CustomList<TValue>();
                foreach (var kvp in this)
                {
                    values.Add(kvp.Value);
                }
                return values;
            }
        }

        /// <summary>
        /// Initializes a new instance of CustomDictionary with default capacity
        /// </summary>
        public CustomDictionary()
        {
            _buckets = new HashTableEntry<TKey, TValue>[DefaultCapacity];
            _count = 0;
        }

        /// <summary>
        /// Initializes a new instance of CustomDictionary with specified capacity
        /// </summary>
        public CustomDictionary(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException(nameof(capacity));
            _buckets = new HashTableEntry<TKey, TValue>[capacity];
            _count = 0;
        }

        /// <summary>
        /// Adds a key-value pair to the dictionary
        /// Time complexity: O(1) average case
        /// </summary>
        public void Add(TKey key, TValue value)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            if (ContainsKey(key))
                throw new ArgumentException($"An item with the key '{key}' already exists.");

            AddOrUpdate(key, value);
        }

        /// <summary>
        /// Adds or updates a key-value pair in the dictionary
        /// </summary>
        public void AddOrUpdate(TKey key, TValue value)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            // Check if resize is needed
            if ((double)_count / _buckets.Length >= LoadFactor)
            {
                Resize(_buckets.Length * 2);
            }

            int bucketIndex = GetBucketIndex(key);
            var entry = _buckets[bucketIndex];

            // Check if key already exists in the chain
            while (entry != null)
            {
                if (EqualityComparer<TKey>.Default.Equals(entry.Key, key))
                {
                    entry.Value = value;
                    return;
                }
                entry = entry.Next;
            }

            // Add new entry at the beginning of the chain
            var newEntry = new HashTableEntry<TKey, TValue>(key, value)
            {
                Next = _buckets[bucketIndex],
            };
            _buckets[bucketIndex] = newEntry;
            _count++;
        }

        /// <summary>
        /// Removes the value with the specified key
        /// Time complexity: O(1) average case
        /// </summary>
        public bool Remove(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            int bucketIndex = GetBucketIndex(key);
            var entry = _buckets[bucketIndex];
            HashTableEntry<TKey, TValue> previous = null;

            while (entry != null)
            {
                if (EqualityComparer<TKey>.Default.Equals(entry.Key, key))
                {
                    if (previous == null)
                    {
                        _buckets[bucketIndex] = entry.Next;
                    }
                    else
                    {
                        previous.Next = entry.Next;
                    }
                    _count--;
                    return true;
                }
                previous = entry;
                entry = entry.Next;
            }

            return false;
        }

        /// <summary>
        /// Determines whether the dictionary contains the specified key
        /// Time complexity: O(1) average case
        /// </summary>
        public bool ContainsKey(TKey key)
        {
            if (key == null)
                return false;

            int bucketIndex = GetBucketIndex(key);
            var entry = _buckets[bucketIndex];

            while (entry != null)
            {
                if (EqualityComparer<TKey>.Default.Equals(entry.Key, key))
                    return true;
                entry = entry.Next;
            }

            return false;
        }

        /// <summary>
        /// Gets the value associated with the specified key
        /// Time complexity: O(1) average case
        /// </summary>
        public bool TryGetValue(TKey key, out TValue value)
        {
            value = default(TValue);

            if (key == null)
                return false;

            int bucketIndex = GetBucketIndex(key);
            var entry = _buckets[bucketIndex];

            while (entry != null)
            {
                if (EqualityComparer<TKey>.Default.Equals(entry.Key, key))
                {
                    value = entry.Value;
                    return true;
                }
                entry = entry.Next;
            }

            return false;
        }

        /// <summary>
        /// Removes all key-value pairs from the dictionary
        /// </summary>
        public void Clear()
        {
            Array.Clear(_buckets, 0, _buckets.Length);
            _count = 0;
        }

        /// <summary>
        /// Calculates the bucket index for a given key
        /// </summary>
        private int GetBucketIndex(TKey key)
        {
            int hashCode = key.GetHashCode();
            // Use bitwise AND to ensure positive index
            return (hashCode & 0x7FFFFFFF) % _buckets.Length;
        }

        /// <summary>
        /// Resizes the hash table and rehashes all entries
        /// </summary>
        private void Resize(int newCapacity)
        {
            var oldBuckets = _buckets;
            _buckets = new HashTableEntry<TKey, TValue>[newCapacity];
            _count = 0;

            foreach (var oldBucket in oldBuckets)
            {
                var entry = oldBucket;
                while (entry != null)
                {
                    var next = entry.Next;
                    // Rehash and insert
                    int bucketIndex = GetBucketIndex(entry.Key);
                    entry.Next = _buckets[bucketIndex];
                    _buckets[bucketIndex] = entry;
                    _count++;
                    entry = next;
                }
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the dictionary
        /// </summary>
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            foreach (var bucket in _buckets)
            {
                var entry = bucket;
                while (entry != null)
                {
                    yield return new KeyValuePair<TKey, TValue>(entry.Key, entry.Value);
                    entry = entry.Next;
                }
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
