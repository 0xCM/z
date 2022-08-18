//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [Free]
    public class PointMappers
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline)]
        public static PointMap<A,B> map<A,B>(A[] a, B[] b)
            => new PointMap<A,B>(a,b);

        public static PointMap<A,B> map<A,B>(Paired<A,B>[] src)
        {
            var count = src.Length;
            var a = alloc<A>(count);
            var b = alloc<B>(count);
            for(var i=0; i<count; i++)
            {
                seek(a,i) = skip(src,i).Left;
                seek(b,i) = skip(src,i).Right;
            }
            return new PointMap<A,B>(a,b);
        }

        /// <summary>
        /// Defines a bijective correspondence between members of source/target sequences of common length over a common domain
        /// </summary>
        /// <param name="src">The source sequence</param>
        /// <param name="dst">The target sequence</param>
        /// <typeparam name="T">The domain type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BijectivePoints<T> bijection<T>(Index<T> src, Index<T> dst)
            => BijectivePoints<T>.bijection(src,dst);

        /// <summary>
        /// Defines a bijective correspondence between members of source/target sequences of common length
        /// </summary>
        /// <param name="src">The source sequence</param>
        /// <param name="dst">The target sequence</param>
        /// <typeparam name="S">The source domain type</typeparam>
        /// <typeparam name="T">The target domain type</typeparam>
        [MethodImpl(Inline)]
        public static BijectivePoints<S,T> bijection<S,T>(Index<S> src, Index<T> dst)
            => BijectivePoints<S,T>.bijection(src,dst);

        public static PointMapper<K,T> mapper<K,T>(Symbols<K> symbols, Func<uint,K,T> f)
            where K : unmanaged
            where T : unmanaged
        {
            var count = symbols.Length;
            var buffer = alloc<Paired<K,T>>(count);
            var symview = symbols.View;
            ref var dst = ref first(buffer);
            for(var i=0u; i<count; i++)
            {
                ref readonly var k = ref skip(symview,i);
                ref var map = ref seek(dst,i);
                kseek(dst, k.Kind).Left = k.Kind;
                kseek(dst, k.Kind).Right = f(i,k);
            }
            return new PointMapper<K,T>(buffer);
        }

        [Op]
        public static Index<byte> serialize<K,T>(PointMapper<K,T> src)
            where K : unmanaged
            where T : unmanaged
        {
            var points = src.Points;
            var count = points.Length;
            var ksize = size<K>()*count;
            var tsize = size<T>()*count;
            var buffer = alloc<byte>(ksize + tsize);
            var lo = recover<K>(slice(span(buffer),0,size<K>()*count));
            var hi = recover<T>(slice(span(buffer), ksize, tsize));
            var j=0;
            for(var i=0; i<count; i++)
            {
                ref readonly var point = ref seek(points,i);
                seek(lo,i) = point.Left;
                seek(hi,i) = point.Right;
            }

            return buffer;
        }
    }
}