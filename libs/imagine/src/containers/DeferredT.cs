//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    /// <summary>
    /// Defines a LINQ-monadic cover for a deferred finite or infinite parametric sequence
    /// </summary>
    public readonly struct Deferred<T> : IDeferred<Deferred<T>,T>
    {
        [MethodImpl(Inline)]
        public static Deferred<X> cover<X>(IEnumerable<X> src)
            => new Deferred<X>(src);

        [MethodImpl(Inline)]
        public static Deferred<X> cover<X>(ICollection<X> src)
            => new Deferred<X>(src);

        [MethodImpl(Inline)]
        public static Deferred<T> concat(Deferred<T> head, Deferred<T> tail)
            => head.Concat(tail);

        [MethodImpl(Inline)]
        public static Deferred<T> concat(Deferred<T> s1, Deferred<T> s2, Deferred<T> s3)
            => s1.Concat(s2).Concat(s3);

        readonly IEnumerable<T> E;

        [MethodImpl(Inline)]
        public Deferred(IEnumerable<T> src)
            => E = src;

        public T[] Yield()
            => E.ToArray();

        public readonly IEnumerable<T> Content
        {
            [MethodImpl(Inline)]
            get => E ?? sys.empty<T>();
        }

        [MethodImpl(Inline)]
        public Deferred<T> WithContent(IEnumerable<T> src)
            => new Deferred<T>(src);

        public Deferred<T> Concat(Deferred<T> tail)
            => new Deferred<T>(Content.Concat(tail.Content));

        public Deferred<Y> Select<Y>(Func<T,Y> project)
             => cover(
                 from x in Content
                 select project(x)
                 );

        public Deferred<Z> SelectMany<Y,Z>(Func<T,Deferred<Y>> lift, Func<T,Y,Z> project)
            => cover(
                from x in Content
                from y in lift(x).Content
                select project(x, y)
                );

        public Deferred<Y> SelectMany<Y>(Func<T,Deferred<Y>> lift)
            => cover(
                from x in Content
                from y in lift(x).Content
                select y
                );

        public Deferred<T> Where(Func<T,bool> predicate)
            => cover(
                from x in Content
                where predicate(x)
                select x
                );

        public static Deferred<T> operator + (Deferred<T> head, Deferred<T> tail)
            => head.Concat(tail);

        /// <summary>
        /// Implicitly constructs a sequence from an array
        /// </summary>
        /// <param name="src">The source array</param>
        public static implicit operator Deferred<T>(T[] src)
            => new Deferred<T>(src);

        public static Deferred<T> Empty
            => new Deferred<T>(sys.empty<T>());
    }
}