//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    using static sys;

    public readonly struct Index<I,T> : IIndex<I,T>
        where I : unmanaged
    {
        [MethodImpl(Inline)]
        public static Index<I,X> cover<X>(X[] src)
            => new Index<I,X>(src);

        [MethodImpl(Inline)]
        public static Index<I,X> load<X>(IEnumerable<X> src)
            => new Index<I,X>(src.Array());

        readonly Index<T> Data;

        [MethodImpl(Inline)]
        public Index(T[] src)
            => Data = src;

        public Index(uint count)
            => Data = sys.alloc<T>(count);

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

        public ref T this[I index]
        {
            [MethodImpl(Inline)]
            get => ref Data[@as<I,uint>(index)];
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => Data.Length;
        }

        public ref T First
        {
            [MethodImpl(Inline)]
            get => ref Data.First;
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => (uint)Length;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Length == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !IsEmpty;
        }

        [MethodImpl(Inline)]
        public bool Equals(Index<I,T> rhs)
            => Data.Equals(rhs.Data);

        public string Format()
            => Data.Format();

        public Index<I,Y> Select<Y>(Func<T,Y> selector)
             => Algs.map(Data.Storage, selector);

        public Index<I,Z> SelectMany<Y,Z>(Func<T,Index<I,Y>> lift, Func<T,Y,Z> project)
            => load(
                from x in Data.Storage
                from y in lift(x).Storage
                select project(x, y)
                );

        public Index<I,Y> SelectMany<Y>(Func<T,Index<I,Y>> lift)
            => load(
                from x in Data.Storage
                from y in lift(x).Data.Storage
                select y
                );

        public Index<I,T> Where(Func<T,bool> predicate)
            => cover(
                from x in Data.Storage
                where predicate(x)
                select x
                );

        [MethodImpl(Inline)]
        public static implicit operator Index<I,T>(T[] src)
            => new Index<I,T>(src);

        [MethodImpl(Inline)]
        public static implicit operator T[](Index<I,T> src)
            => src.Data;

        public static Index<I,T> Empty => new Index<I,T>(sys.empty<T>());
    }
}