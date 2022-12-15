//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class SettingStore<K,V> : ILookup<K,V>
        where K : unmanaged, IExpr, IDataType<K>
    {
        readonly Dictionary<K,V> Data;

        public SettingStore()
        {
            Data = dict<K,V>();
        }

        public SettingStore(Setting<K,V>[] data)
        {
            var dst = dict<K,V>();
            iter(data, s => dst.TryAdd(s.Name,s.Value));
            Data = dst;
        }

        public V Find(K name, V @default)
        {
            var dst = @default;
            Data.TryGetValue(name, out dst);
            return dst;
        }

        public bool Find(K name, out V dst)
            => Data.TryGetValue(name, out dst);

        public void Set(K name, V value)
            => Data[name] = value;

        public uint Count => (uint)Data.Count;

        public ICollection<K> Keys => Data.Keys;

        public ICollection<V> Values => Data.Values;

        public static SettingStore<K,V> Empty => new SettingStore<K,V>();
    }
}