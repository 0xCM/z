//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using T = KeyedValue<EcmaToken,System.Type>;
    using V = System.Type;
    using K = EcmaToken;

    [ApiComplete]
    public readonly struct EcmaTypeLookup
    {
        readonly KeyedValues<K, V> Data;

        [MethodImpl(Inline)]
        static K kf(in V t)
            => t.MetadataToken;

        [MethodImpl(Inline)]
        public EcmaTypeLookup(V[] src)
            => Data = new KeyedValues<K,V>(kf, src);

        [MethodImpl(Inline)]
        public EcmaTypeLookup(KeyedValues<K,V> src)
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