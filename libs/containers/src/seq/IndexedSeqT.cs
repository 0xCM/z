//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    /// <summary>
    /// Reifies a canonical indexed sequence container
    /// </summary>
    public readonly struct IndexedSeq<T> : IIndex<T>
    {
        [MethodImpl(Inline)]
        public static IndexedSeq<S> load<S>(IEnumerable<S> src)
            => new IndexedSeq<S>(src.Array());

        [MethodImpl(Inline)]
        public static IndexedSeq<S> load<S>(S[] src)
            => new IndexedSeq<S>(src);

        [MethodImpl(Inline)]
        public static IndexedSeq<T> concat(IndexedSeq<T> head, IndexedSeq<T> tail)
            => new IndexedSeq<T>(Algs.concat(head.Storage, tail.Storage));

        readonly T[] Data;

        [MethodImpl(Inline)]
        public IndexedSeq(T[] src)
            => Data = src != null ? src : sys.empty<T>();

        [MethodImpl(Inline)]
        public IndexedSeq(T[] src, bool @internal)
            => Data = src;

        public Span<T> Terms
        {
            [MethodImpl(Inline)]
            get => Data;
        }

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
            get => Data;
        }

        public ref T Head
        {
            [MethodImpl(Inline)]
            get => ref Data[0];
        }

        public ref T Tail
        {
            [MethodImpl(Inline)]
            get => ref Data[Length - 1];
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => (uint)Data.Length;
        }

        public IndexedSeq<T> Reverse()
        {
            Array.Reverse(Data);
            return this;
        }

        public bool IsEmpty
        {
             [MethodImpl(Inline)]
             get => Data.Length == 1 && object.Equals(default, Head);
        }

        public bool IsNonEmpty
        {
             [MethodImpl(Inline)]
             get => !IsEmpty;
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => Data.Length;
        }

        [MethodImpl(Inline)]
        uint IFinite.Count()
            => (uint)Data.Length;

        public ref T this[long index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public ref T this[ulong index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        [MethodImpl(Inline)]
        public ref T Lookup(int index)
            => ref this[index];

        [MethodImpl(Inline)]
        public IndexedSeq<T> WithContent(IEnumerable<T> content)
            => load(content);

        [MethodImpl(Inline)]
        public bool Equals(IndexedSeq<T> rhs)
            => Data.Equals(rhs.Data);

        public IndexedSeq<T> Concat(IndexedSeq<T> tail)
            => concat(this, tail);

        public IndexedSeq<Y> Select<Y>(Func<T,Y> project)
             => load(
                 from x in Data
                 select project(x)
                 );

        public IndexedSeq<Z> SelectMany<Y,Z>(Func<T,IndexedSeq<Y>> lift, Func<T,Y,Z> project)
            => load(
                from x in Data
                from y in lift(x).Data
                select project(x, y)
                );

        public IndexedSeq<Y> SelectMany<Y>(Func<T,IndexedSeq<Y>> lift)
            => load(
                from x in Data
                from y in lift(x).Data
                select y
                );

        public IndexedSeq<T> Where(Func<T,bool> predicate)
            => load(
                from x in Data
                where predicate(x)
                select x
                );

        [MethodImpl(Inline)]
        public static implicit operator IndexedSeq<T>(T[] src)
            => load(src);

        [MethodImpl(Inline)]
        public static implicit operator T[](IndexedSeq<T> src)
            => src.Data;

        static Span<T> EmptyTermSeq
        {
            [MethodImpl(Inline)]
            get => Span<T>.Empty;
        }
    }
}