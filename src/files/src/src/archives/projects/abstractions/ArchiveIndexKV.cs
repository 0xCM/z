//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class ArchiveIndex<K,V>
        where K : IDataType<K>, new() 
    {
        protected readonly ConcurrentDictionary<K,V> Data;

        protected ArchiveIndex()
        {
            Data = new();
        }

        public IReadOnlyCollection<KeyValuePair<K, V>> Entries
            => Data;

        public IEnumerable<K> Keys 
            => Data.Keys;

        public IEnumerable<V> Values
            => Data.Values;

        public bool Find(K key, out V value)
            => Data.TryGetValue(key, out value);

        public Task Include(params Paired<K,V>[] src)
            => sys.start(() =>sys.iter(src, entry => Data.TryAdd(entry.Left, entry.Right))); 

        public Task Include(params KeyValuePair<K,V>[] src)
            => sys.start(() =>sys.iter(src, entry => Data.TryAdd(entry.Key, entry.Value))); 

        public Task Include(params KeyedValue<K,V>[] src)
            => sys.start(() =>sys.iter(src, entry => Data.TryAdd(entry.Key, entry.Value))); 
    }
}