using System;
using System.Collections.Generic;
using System.Linq;
using HashTable;

namespace CustomHashTable
{
    public class HashTable<TKey, TValue> : IHashTable<TKey, TValue>
    {
        private const int HashPrime = 101;
        private const int InitialSize = 7;
        private const double LoadFactor = 0.72;

        private static readonly int[] PrimeBucketSizes =
        {
            3, 7, 11, 17, 23, 29, 37, 47, 59, 71, 89, 107, 131, 163, 197, 239, 293, 353, 431,
            521, 631, 761, 919, 1103, 1327, 1597, 1931, 2333, 2801, 3371, 4049, 4861, 5839, 7013,
            8419, 10103, 12143, 14591, 17519, 21023, 25229, 30293, 36353, 43627, 52361, 62851,
            75431, 90523, 108631, 130363, 156437, 187751, 225307, 270371, 324449, 389357, 467237,
            560689, 672827, 807403, 968897, 1162687, 1395263, 1674319, 2009191, 2411033, 2893249,
            3471899, 4166287, 4999559, 5999471, 7199369
        };

        private int _existingBucketsCount;
        private Bucket[] _buckets;


        public HashTable() : this(InitialSize) { }


        public HashTable(int capacity)
        {
            if (capacity < 0) throw new ArgumentOutOfRangeException(nameof(capacity));

            Capacity = GetPrimeCapacity(capacity);
            _buckets = new Bucket[Capacity];
        }


        internal int Capacity { get; private set; }
        public int Count { get; private set; }


        public TValue this[TKey key]
        {
            get => Get(key);
            set => Set(key, value);
        }


        public void Add(TKey key, TValue value)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            if (value == null)
                throw new ArgumentNullException(nameof(value));

            if (_existingBucketsCount / (double)Capacity > LoadFactor)
                Resize();

            var hashIndex = GetHashIndex(key);
            var newNode = new Node { Key = key, Value = value };

            if (_buckets[hashIndex] == null)
            {
                _buckets[hashIndex] = new Bucket();
                _buckets[hashIndex].Nodes.Add(newNode);
                _existingBucketsCount++;
            }
            else
            {
                if (_buckets[hashIndex].Nodes.Any(p => p.Key.Equals(newNode.Key)))
                    throw new DuplicateKeyException<TKey>(key);

                _buckets[hashIndex].Nodes.Add(newNode);
            }

            Count++;
        }


        public bool Contains(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            var hash = GetHashIndex(key);
            var currentBucket = _buckets[hash];

            return currentBucket?.Nodes.Any(p => p.Key.Equals(key)) ?? false;
        }


        public bool TryGet(TKey key, out TValue value)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            var node = GetNodeByKey(key);
            value = node != null ? node.Value : default(TValue);
            return !EqualityComparer<TValue>.Default.Equals(value, default(TValue));
        }


        private Node GetNodeByKey(TKey key)
        {
            var hash = GetHashIndex(key);
            var currentBucket = _buckets[hash];
            return currentBucket?.Nodes.FirstOrDefault(p => p.Key.Equals(key));
        }


        private int GetPrimeCapacity(int oldCapacity)
        {
            var newCapacity = PrimeBucketSizes.FirstOrDefault(p => p > oldCapacity);
            return newCapacity != 0 ? newCapacity : GeneratePrime(newCapacity);
        }


        private void Resize()
        {
            var oldBucketArray = _buckets;
            Capacity = GetPrimeCapacity(Capacity * 2);

            Count = 0;
            _existingBucketsCount = 0;
            _buckets = new Bucket[Capacity];

            foreach (var bucket in oldBucketArray)
            {
                if (bucket == null) continue;

                foreach (var list in bucket.Nodes)
                    Add(list.Key, list.Value);
            }
        }


        private int GeneratePrime(int capacity)
        {
            capacity = capacity + (int)(capacity * 0.2);
            if (capacity % 2 == 0)
                capacity += 1;

            for (; capacity < int.MaxValue; capacity += 2)
                if (IsPrime(capacity))
                    return capacity;

            return int.MaxValue;
        }


        private bool IsPrime(int value)
        {
            var sqrt = (int)Math.Sqrt(value);
            foreach (var prime in Enumerable.Range(2, sqrt))
                if (value % prime == 0)
                    return false;

            return true;
        }


        private uint GetHashIndex(TKey key)
        {
            return ((uint)key.GetHashCode() & 0x7FFFFFFF) * HashPrime % ((uint)Capacity - 1);
        }


        private TValue Get(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            var nodeByKey = GetNodeByKey(key) ??
                            throw new ArgumentException("Invalid key parameter", nameof(key));


            return nodeByKey.Value;
        }


        private void Set(TKey key, TValue value)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            if (value == null)
                throw new ArgumentNullException(nameof(value));

            var nodeByKey = GetNodeByKey(key) ??
                            throw new ArgumentException("Invalid key parameter", nameof(key));

            nodeByKey.Value = value;
        }


        private class Bucket
        {
            public List<Node> Nodes { get; } = new List<Node>();
        }

        private class Node
        {
            public TKey Key { get; set; }
            public TValue Value { get; set; }
        }
    }
}