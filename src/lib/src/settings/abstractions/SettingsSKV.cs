//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;


    public abstract class Settings<S,K,V> : ReadOnlySeq<S,Setting<K,V>>, ILookup<K,V>
        where K : unmanaged, IExpr, IDataType<K>
        where S : Settings<S,K,V>, new()
    {

        readonly ConstLookup<K,V> Lookup;

        public Settings()
        {
            Lookup = ConstLookup<K,V>.Empty;
        }

        protected Settings(Setting<K,V>[] data)
            : base(data)
        {
            var dst = dict<K,V>();
            iter(data, s => dst.TryAdd(s.Name,s.Value));
            Lookup = dst;
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

        public static new S Empty => new S();
    }
}