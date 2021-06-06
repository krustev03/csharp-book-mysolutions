using System;
using System.Collections.Generic;
using System.Text;

namespace DictionaryClass.Interfaces
{
    public interface IDictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
    {
        TValue Set(TKey key, TValue value);

        TValue Get(TKey key);

        TValue this[TKey key] { get;set; }

        bool Remove(TKey key);

        int Count { get; }

        void Clear();
    }
}
