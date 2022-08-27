//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    public abstract class Deferred<D,T> : IDeferred<D,T>
        where D : Deferred<D,T>, new()
    {
        public ReadOnlySeq<T> Compute()
            => Content.ToArray();

        public IEnumerable<T> Content {get;}

        public D WithContent(IEnumerable<T> content)
        {
            var dst = new D();
            dst.WithContent(content);
            return dst;
        }

        protected Deferred()
        {
            Content = sys.empty<T>();
        }

        protected Deferred(IEnumerable<T> src)
        {
            Content = Require.notnull(src);
        }
    }

    /// <summary>
    /// Defines a LINQ-monadic cover for a deferred finite or infinite parametric sequence
    /// </summary>
    public class Deferred<T> : Deferred<Deferred<T>,T>
    {
        readonly IEnumerable<T> E;

        public Deferred()
            : base(sys.empty<T>())
        {
            
        }

        public Deferred(IEnumerable<T> src)
            : base(src)
        {

        }
            
        public Deferred<T> Concat(Deferred<T> tail)
            => Deferrals.concat(this, tail);

        public Deferred<Y> Select<Y>(Func<T,Y> project)
             => Deferrals.defer(
                 from x in Content
                 select project(x)
                 );

        public Deferred<Z> SelectMany<Y,Z>(Func<T,Deferred<Y>> lift, Func<T,Y,Z> project)
            => Deferrals.defer(
                from x in Content
                from y in lift(x).Content
                select project(x, y)
                );

        public Deferred<Y> SelectMany<Y>(Func<T,Deferred<Y>> lift)
            => Deferrals.defer(
                from x in Content
                from y in lift(x).Content
                select y
                );

        public Deferred<T> Where(Func<T,bool> predicate)
            => Deferrals.defer(
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