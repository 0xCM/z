//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    partial class XTend
    {
        public static Seq<T> ToSeq<T>(this ICollection src)
        {
            var dst = sys.alloc<T>(src.Count);
            src.CopyTo(dst,0);
            return dst;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Seq<T> ToSeq<T>(this IEnumerable<T> src)
            => sys.array(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Seq<T> ToSeq<T>(this T[] src)
            => new (src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySeq<T> ToReadOnlySeq<T>(this T[] src)
            => new (src);

        public static Seq<T> SelectMany<S,T>(this Seq<S> source, Func<S,IEnumerable<T>> selector)
            => Enumerable.SelectMany(source,selector).ToArray();

        public static ReadOnlySeq<T> SelectMany<S,T>(this ReadOnlySeq<S> source, Func<S,IEnumerable<T>> selector)
            => Enumerable.SelectMany(source,selector).ToArray();
    }
}