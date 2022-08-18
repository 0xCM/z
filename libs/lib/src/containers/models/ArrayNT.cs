//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    //using static core;

    using System.Linq;

    using api = NaturalArrays;

    public class NaturalArrays
    {
        public static Z[] flat<N,T,Y,Z>(Array<N,T> src, Func<T,Array<N,Y>> lift, Func<T,Y,Z> project)
            where N : unmanaged, ITypeNat
                => Algs.array(
                        from x in src.Storage
                        from y in lift(x).Storage
                        select project(x, y)
                    );

        public static Y[] flat<N,T,Y>(Array<N,T> src, Func<T,Array<N,Y>> lift)
            where N : unmanaged, ITypeNat
            => Algs.array(from x in src.Storage
                from y in lift(x).Storage
                select y);

        /// <summary>
        /// Allocates an array of natural length
        /// </summary>
        /// <typeparam name="N">The number of cells in the constructed array</typeparam>
        /// <typeparam name="T">The call type</typeparam>
        public static Array<N,T> array<N,T>()
            where N : unmanaged, ITypeNat
                => new Array<N,T>();

        /// <summary>
        /// Adapts an existing array to a natural array provided the length of the source array agrees with the specified natural length
        /// </summary>
        /// <param name="n">A natural representative</param>
        /// <param name="src">The soruce array</param>
        /// <typeparam name="N">The number of cells in the constructed array</typeparam>
        /// <typeparam name="T">The call type</typeparam>
        public static Array<N,T> array<N,T>(N n, params T[] src)
            where N : unmanaged, ITypeNat
        {
            Require.equal(n.NatValue, (ulong)src.Length);
            return new Array<N,T>(src);
        }

        public static Array<N,Y> map<N,T,Y>(Array<N,T> src, Func<T,Y> project)
            where N : unmanaged, ITypeNat
        {
            var dst = array<N,Y>();
            for(var i=0; i<src.Count; i++)
                dst[i] = project(src[i]);
            return dst;
        }
    }

    public readonly struct Array<N,T>
        where N : unmanaged, ITypeNat
    {

        readonly Index<T> Data;

        public Array()
        {
            Data = new T[Typed.nat32u<N>()];
        }

        internal Array(T[] data)
        {
            Data = data;
        }

        public T[] Storage
        {
            [MethodImpl(Inline)]
            get => Data.Storage;
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => Data.Length;
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

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Length == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Length != 0;
        }

        public ref T this[long i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        public ref T this[ulong i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => (uint)Length;
        }

        public ref T First
        {
            [MethodImpl(Inline)]
            get => ref Data.First;
        }

        public ref T Last
        {
            [MethodImpl(Inline)]
            get => ref Data.Last;
        }

        public Array<N,T> Clear()
        {
            if(Length !=0)
                Data.Clear();
            return this;
        }

        public bool Equals<C>(Array<N,T> src, C comparer)
            where C : IEqualityComparer<T>
                => Algs.equal(View, src.View, comparer);

        [MethodImpl(Inline)]
        public bool Search(Func<T,bool> predicate, out T found)
            => Data.Search(predicate, out found);

        public Array<N,Y> Cast<Y>()
            => new (Data.Select(x => (Y)(object)x));

        public Array<N,Y> Select<Y>(Func<T,Y> projector)
             => api.map(this, projector);

        public Index<T> Distinct()
            => Data.Distinct();

        public string Format()
            => IsNonEmpty ? string.Join(Chars.Comma, Data) : EmptyString;

        public override string ToString()
            => Format();

        public Index<T> Reverse()
            => Data.Reverse();
    }
}