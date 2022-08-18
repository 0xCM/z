//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    using static core;

    public readonly struct IndexedSeq<I,T> : IIndex<IndexedSeq<I,T>,I,T>
        where I : unmanaged
    {

        [MethodImpl(Inline)]
        public static IndexedSeq<I,T> concat(IndexedSeq<I,T> head, IndexedSeq<I,T> tail)
            => new IndexedSeq<I,T>(Algs.concat(head.Storage, tail.Storage));

        [MethodImpl(Inline)]
        public static IndexedSeq<I,Y> load<Y>(IEnumerable<Y> src)
            => new IndexedSeq<I,Y>(src.Array());

        [MethodImpl(Inline)]
        public static IndexedSeq<I,Y> cover<Y>(Y[] src)
            => new IndexedSeq<I,Y>(src);

        [MethodImpl(Inline)]
        public static IndexedSeq<I,T> cover(T[] src)
            => new IndexedSeq<I,T>(src);

        readonly T[] Data;

        [MethodImpl(Inline)]
        public IndexedSeq(T[] src)
            => Data = src;

        [MethodImpl(Inline)]
        public void Clear()
            => Edit.Clear();

        public Span<T> Edit
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public ReadOnlySpan<T> View
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public T[] Storage
        {
            [MethodImpl(Inline)]
            get => Data ?? Array.Empty<T>();
        }

        public ref T this[I index]
        {
            [MethodImpl(Inline)]
            get => ref seek(Storage, @as<I,uint>(index));
        }

        public I Count
        {
            [MethodImpl(Inline)]
            get => @as<uint,I>(Length);
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Length == 0;
        }

        [MethodImpl(Inline)]
        public bool Equals(IndexedSeq<I,T> rhs)
            => Data?.Equals(rhs.Data) ?? false;

        [MethodImpl(Inline)]
        public IndexedSeq<I,T> WithContent(IEnumerable<T> content)
            => load(content);

        [MethodImpl(Inline)]
        public IndexedSeq<I,T> Concat(IndexedSeq<I,T> rhs)
            => concat(this, rhs);

        /// <summary>
        /// Creates an indexed sequence from a parameter array
        /// </summary>
        /// <param name="src">The data source</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(UInt8k)]
        private static IndexedSeq<I,X> view<X>(IEnumerable<X> src)
            => new IndexedSeq<I,X>(src.Array());

        public IndexedSeq<I,Y> Select<Y>(Func<T,Y> project)
             => Data.Select(project);

        public IndexedSeq<I,Z> SelectMany<Y,Z>(Func<T,IndexedSeq<I,Y>> lift, Func<T,Y,Z> project)
            => load(
                from x in Data
                from y in lift(x).Data
                select project(x, y)
                );

        public IndexedSeq<I,Y> SelectMany<Y>(Func<T,IndexedSeq<I,Y>> lift)
            => load(
                from x in Data
                from y in lift(x).Data
                select y
                );

        public IndexedSeq<I,T> Where(Func<T,bool> predicate)
            => cover(
                from x in Data
                where predicate(x)
                select x
                );

        int IMeasured.Length
            => (int)Length;

        ref T IIndex<T>.this[int index]
            => ref Data[index];

        uint Length
        {
            [MethodImpl(Inline)]
            get => (uint)(Data?.Length ?? 0);
        }

        [MethodImpl(Inline)]
        public static implicit operator IndexedSeq<I,T>(T[] src)
            => new IndexedSeq<I,T>(src);

        [MethodImpl(Inline)]
        public static implicit operator T[](IndexedSeq<I,T> src)
            => src.Data;

        static Span<T> EmptyTermSeq
        {
            [MethodImpl(Inline)]
            get => Span<T>.Empty;
        }

        public static IndexedSeq<I,T> Empty
        {
            [MethodImpl(Inline)]
            get => new IndexedSeq<I,T>(Array.Empty<T>());
        }
    }
}