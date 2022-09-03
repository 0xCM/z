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
    public struct MutableSeq<T> : IIndex<T>
    {
        [MethodImpl(Inline)]
        public static MutableSeq<X> concat<X>(MutableSeq<X> head, MutableSeq<X> tail)
            => new MutableSeq<X>(sys.array(head.Storage.Concat(tail.Storage)));

        T[] Data;

        [MethodImpl(Inline)]
        public MutableSeq(T[] src)
            => Data = src != null ? src : sys.empty<T>();

        [MethodImpl(Inline)]
        public MutableSeq(T[] src, bool @internal)
            => Data = src;

        public Span<T> Terms
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
            [MethodImpl(Inline)]
            set => Data = value;
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

        public MutableSeq<T> Reverse()
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
        public MutableSeq<T> WithContent(IEnumerable<T> content)
            => mutable(content);

        [MethodImpl(Inline)]
        public bool Equals(MutableSeq<T> src)
            => Data.Equals(src.Data);

        public MutableSeq<T> Concat(MutableSeq<T> tail)
            => concat(this, tail);

        public MutableSeq<Y> Select<Y>(Func<T,Y> project)
             => mutable(
                 from x in Data
                 select project(x)
                 );

        public MutableSeq<Z> SelectMany<Y,Z>(Func<T,MutableSeq<Y>> lift, Func<T,Y,Z> project)
            => mutable(
                from x in Data
                from y in lift(x).Data
                select project(x, y)
                );

        public MutableSeq<Y> SelectMany<Y>(Func<T,MutableSeq<Y>> lift)
            => mutable(
                from x in Data
                from y in lift(x).Data
                select y
                );

        public MutableSeq<T> Where(Func<T,bool> predicate)
            => new MutableSeq<T>(from x in Data where predicate(x) select x);

        [MethodImpl(Inline)]
        public static implicit operator MutableSeq<T>(T[] src)
            => new MutableSeq<T>(src);

        [MethodImpl(Inline)]
        public static implicit operator T[](MutableSeq<T> src)
            => src.Data;

        static Span<T> EmptyTermSeq
        {
            [MethodImpl(Inline)]
            get => Span<T>.Empty;
        }

        [MethodImpl(Inline)]
        static MutableSeq<X> mutable<X>(IEnumerable<X> src)
            => new MutableSeq<X>(src.Array());

    }
}