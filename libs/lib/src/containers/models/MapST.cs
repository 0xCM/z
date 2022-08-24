//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class Map<S,T>
    {
        Dictionary<S,uint> Lookup;

        Index<MapEntry<S,T>> Entries;

        public Map(MapEntry<S,T>[] src)
        {
            Entries = src;
            var count = Entries.Length;
            Lookup = new(count);
            for(var i=0u; i<count; i++)
                Lookup[Entries[i].Source] = i;
        }

        public Map(Paired<S,T>[] src)
        {
            var count = src.Length;
            Entries = alloc<MapEntry<S,T>>(count);
            Lookup = new(count);
            for(var i=0u; i<count; i++)
            {
                ref readonly var pair = ref skip(src,i);
                var entry = new MapEntry<S,T>(i, pair.Left, pair.Right);
                Entries[i] = entry;
                Lookup[entry.Source] = i;
            }
        }

        public ref readonly T this[S src]
        {
            [MethodImpl(Inline)]
            get => ref Entries[Lookup[src]].Target;
        }
    }
}