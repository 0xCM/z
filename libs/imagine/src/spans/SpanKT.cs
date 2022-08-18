//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Spans;
    using static sys;

    /// <summary>
    /// Defines a <typeparamref name="K"/> -indexed span
    /// </summary>
    public readonly ref struct Span<K,T>
        where K : unmanaged
    {
        readonly Span<T> Data;

        [MethodImpl(Inline)]
        public Span(Span<T> src)
        {
            Data = src;
        }

        public Span<T> Storage
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => (uint)Data.Length;
        }

        public uint Length
        {
            [MethodImpl(Inline)]
            get => (uint)Data.Length;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Count == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Count != 0;
        }

        public ref T this[K i]
        {
            [MethodImpl(Inline)]
            get => ref sys.seek(Data, u32(i));
        }

        public ref T First
        {
            [MethodImpl(Inline)]
            get => ref sys.first(Data);
        }

        [MethodImpl(Inline)]
        public static implicit operator Span<K,T>(Span<T> src)
            => new Span<K,T>(src);

        [MethodImpl(Inline)]
        public static implicit operator Span<T>(Span<K,T> src)
            => src.Data;

        [MethodImpl(Inline)]
        public static implicit operator Span<K,T>(T[] src)
            => default;
    }
}