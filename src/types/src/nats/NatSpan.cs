    //-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    /// <summary>
    /// Defines a span of natural length N
    /// </summary>
    [CustomSpan(IDI.NatSpan), NatSpan]
    public readonly ref struct NatSpan<N,T>
        where N : unmanaged, ITypeNat
        where T : unmanaged
    {
        readonly Span<T> Data;

        static N n => default;

        [MethodImpl(Inline)]
        internal NatSpan(Span<T> src)
            => Data = src;

        /// <summary>
        /// The backing storage
        /// </summary>
        public Span<T> Edit
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => nat32u<N>();
        }

        public N NatCount
            => n;

        public ReadOnlySpan<T> View
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        /// <summary>
        /// The leading storage cell
        /// </summary>
        public ref T First
        {
            [MethodImpl(Inline)]
            get => ref first(Data);
        }

        /// <summary>
        /// True if no capacity exist, false otherwise
        /// </summary>
        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsEmpty;
        }

        /// <summary>
        /// True if no capacity exist, false otherwise
        /// </summary>
        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !Data.IsEmpty;
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => nat32i<N>();
        }

        /// <summary>
        /// Queries/manipulates an index-identified cell
        /// </summary>
        public ref T this[long index]
        {
            [MethodImpl(Inline)]
            get => ref Unsafe.Add(ref First, (int)index);
        }

        /// <summary>
        /// Queries/manipulates an index-identified cell
        /// </summary>
        public ref T this[byte index]
        {
            [MethodImpl(Inline)]
            get => ref Unsafe.Add(ref First, (int)index);
        }

        /// <summary>
        /// Queries/manipulates an index-identified cell
        /// </summary>
        public ref T this[ushort index]
        {
            [MethodImpl(Inline)]
            get => ref Unsafe.Add(ref First, (int)index);
        }

        /// <summary>
        /// Queries/manipulates an index-identified cell
        /// </summary>
        public ref T this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref Unsafe.Add(ref First, (int)index);
        }

        /// <summary>
        /// Queries/manipulates an index-identified cell
        /// </summary>
        public ref T this[ulong index]
        {
            [MethodImpl(Inline)]
            get => ref Unsafe.Add(ref First, (int)index);
        }

        /// <summary>
        /// Queries/manipulates the underlying storage through the perspective of another type
        /// </summary>
        [MethodImpl(Inline)]
        public ref S Cell<S>(ulong index)
            => ref Unsafe.Add(ref @as<T,S>(First), (int)index);

        [MethodImpl(Inline)]
        public Span<T>.Enumerator GetEnumerator()
            => Data.GetEnumerator();

        [MethodImpl(Inline)]
        public ref T GetPinnableReference()
            => ref Data.GetPinnableReference();

        [MethodImpl(Inline)]
        public NatSpan<N,S> As<S>()
            where S : unmanaged
                => new NatSpan<N,S>(recover<T,S>(Data));

        [MethodImpl(Inline)]
        public static implicit operator Span<T>(in NatSpan<N,T> src)
            => src.Data;

        [MethodImpl(Inline)]
        public static implicit operator NatSpan<N,T>(Span<T> src)
            => NatSpans.load(src,n);

        [MethodImpl(Inline)]
        public static implicit operator ReadOnlySpan<T> (in NatSpan<N,T> src)
            => src.Data;
    }
}