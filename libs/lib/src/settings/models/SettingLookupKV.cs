//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class SettingLookup<K,V> : ReadOnlySeq<Setting<K,V>>, ILookup<K,V>
        where K : unmanaged, IExpr, IDataType<K>
    {
        readonly ConstLookup<K,V> Lookup;

        public SettingLookup()
        {
            Lookup = ConstLookup<K,V>.Empty;
        }

        public SettingLookup(Setting<K,V>[] data)
            : base(data)
        {
            var dst = dict<K,V>();
            core.iter(data, s => dst.TryAdd(s.Name,s.Value));
            Lookup = dst;
        }

        public SettingLookup(Setting<K,V>[] data, Dictionary<K,V> lookup)
            : base(data)
        {
            Lookup = lookup;
        }

        public V Find(K name, V @default)
        {
            var dst = @default;
            Lookup.Find(name, out dst);
            return dst;
        }

        public bool Find(K name, out V dst)
            => Lookup.Find(name, out dst);

        public override string Delimiter => "\n";

        public override Fence<char>? Fence => null;

        public static new SettingLookup<K,V> Empty => new SettingLookup<K,V>();
    }
}