using System.Collections;
using System.Collections.Generic;

namespace DictionaryClass
{
    public class HashDictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
    {
        private const int DEFAULT_CAPACITY = 16;
        private const float DFAULT_LOAD_FACTOR = 0.75f;

        private List<KeyValuePair<TKey, TValue>>[] table;
        private float loadFactor;
        private int threshold;
        private int size;
        private int initialCapacity;

        public HashDictionary()
            : this(DEFAULT_CAPACITY, DFAULT_LOAD_FACTOR)
        {
        }

        public HashDictionary(int capacity, float loadFactor)
        {
            this.initialCapacity = capacity;
            this.table = new List<KeyValuePair<TKey, TValue>>[capacity];
            this.loadFactor = loadFactor;

            unchecked
            {
                this.threshold = (int)(capacity * this.loadFactor);
            }
        }

        public void Clear()
        {
            this.table = new List<KeyValuePair<TKey, TValue>>[initialCapacity];
            this.size = 0;
        }

        private List<KeyValuePair<TKey, TValue>> FindChain(TKey key, bool createIfMissing)
        {
            int index = key.GetHashCode();
            index = index & 0x7FFFFFFF; // clear the negative bit
            index = index % this.table.Length;

            if (this.table[index] == null && createIfMissing)
            {
                this.table[index] = new List<KeyValuePair<TKey, TValue>>();
            }

            return this.table[index] as List<KeyValuePair<TKey, TValue>>;
        }

        public TValue Get(TKey key)
        {
            var chain = this.FindChain(key, false);

            if (chain != null)
            {
                foreach (var entry in chain)
                {
                    if (entry.Key.Equals(key))
                    {
                        return entry.Value;
                    }
                }
            }

            return default(TValue);
        }

        public TValue this[TKey key]
        {
            get => this.Get(key);
            set => this.Set(key, value);
        }

        public int Count => this.size;

        public TValue Set(TKey key, TValue value)
        {
            if (this.size >= this.threshold)
            {
                this.Expand();
            }

            var chain = this.FindChain(key, true);

            for (int i = 0; i < chain.Count; i++)
            {
                KeyValuePair<TKey, TValue> entry = chain[i];

                if (entry.Key.Equals(key))
                {
                    var newEntry = new KeyValuePair<TKey, TValue>(key, value);
                    chain[i] = newEntry;

                    return entry.Value;
                }
            }

            chain.Add(new KeyValuePair<TKey, TValue>(key, value));
            this.size++;

            return default(TValue);
        }

        private void Expand()
        {
            int newCapacity = 2 * this.table.Length;

            var oldTable = this.table;

            this.table = new List<KeyValuePair<TKey, TValue>>[newCapacity];
            this.threshold = (int)(newCapacity * this.loadFactor);

            foreach (var oldChain in oldTable)
            {
                if (oldChain != null)
                {
                    foreach (var keyValuePair in oldChain)
                    {
                        var chain = FindChain(keyValuePair.Key, true);
                        chain.Add(keyValuePair);
                    }
                }
            }
        }

        public bool Remove(TKey key)
        {
            var chain = this.FindChain(key, false);

            if (chain != null)
            {
                for (int i = 0; i < chain.Count; i++)
                {
                    KeyValuePair<TKey, TValue> entry = chain[i];

                    if (entry.Key.Equals(key))
                    {
                        chain.RemoveAt(i);
                        this.size--;

                        return true;
                    }
                }
            }

            return false;
        }


        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            foreach (var chain in this.table)
            {
                if (chain != null)
                {
                    foreach (var entry in chain)
                    {
                        yield return entry;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<KeyValuePair<TKey, TValue>>)this).GetEnumerator();
        }
    }
}
