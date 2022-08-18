//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using T = KeyedValue<CliToken,System.Type>;
    using V = System.Type;
    using K = CliToken;

    [ApiComplete]
    public readonly struct ClrTypeLookup
    {
        readonly KeyedValues<K, V> Data;

        [MethodImpl(Inline)]
        static K kf(in V t)
            => t.MetadataToken;

        [MethodImpl(Inline)]
        public ClrTypeLookup(V[] src)
            => Data = new KeyedValues<K, V>(kf, src);

        [MethodImpl(Inline)]
        public ClrTypeLookup(KeyedValues<K, V> src)
            => Data = src;

        public ref V this[in K id]
        {
            [MethodImpl(Inline)]
            get => ref Data[id];
        }

        public ref T this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        [MethodImpl(Inline)]
        public bool Search(Func<Type,bool> predicate, out Type found)
            => Data.Search(predicate, out found);

        public Span<T> Pairs
        {
            [MethodImpl(Inline)]
            get => Data.Edit;
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }
    }
}