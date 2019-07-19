using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgeOpen.Shared
{
    public class HashMap<K, V> : IEnumerable<KeyValuePair<K, ICollection<V>>>
    {
        private readonly IDictionary<K, ICollection<V>> map = new Dictionary<K, ICollection<V>>();

        public ICollection<K> Keys => map.Keys;
        public IEnumerable<V> Values => map.Values.SelectMany(x => x);

        public void Add(K key, V value)
        {
            if (ContainsKey(key))
                map[key].Add(value);
            else
                map.Add(key, new List<V> { value });
        }

        public ICollection<V> this[K key]
        {
            get {
                return map[key];
            }
        }

        public bool ContainsKey(K key)
        {
            return map.ContainsKey(key);
        }

        public IEnumerator<KeyValuePair<K, ICollection<V>>> GetEnumerator()
        {
            return map.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
