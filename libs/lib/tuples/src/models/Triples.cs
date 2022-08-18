//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly ref struct Triples<T>
    {
        readonly Index<Triple<T>> Data;

        [MethodImpl(Inline)]
        public Triples(Triple<T>[] src)
            => Data = src;
        public Triple<T>[] Storage
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        [MethodImpl(Inline)]

        public ref Triple<T> Select(int index)
            => ref Data[index];

        [MethodImpl(Inline)]
        public ref Triple<T> Select(uint index)
            => ref Data[index];

        public ref Triple<T> this[int index]
        {
            [MethodImpl(Inline)]
            get => ref Select(index);
        }

        public ref Triple<T> this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref Select(index);
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => (uint)Data.Length;
        }

        [MethodImpl(Inline)]
        public static implicit operator Triples<T>(Triple<T>[] src)
            => new Triples<T>(src);

        [MethodImpl(Inline)]
        public static implicit operator Triples<T>(Index<Triple<T>> src)
            => new Triples<T>(src);

    }
}