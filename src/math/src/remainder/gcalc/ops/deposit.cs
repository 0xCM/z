//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct gcalc
    {
        /// <summary>
        /// Deposits each source point, when possible, into some histogram bucket
        /// </summary>
        /// <param name="src">The point source</param>
        /// <param name="dst">The target histogram</param>
        /// <typeparam name="T">The point domain</typeparam>
        [MethodImpl(Inline), Op, Closures(UInt64k)]
        public static void deposit<T>(ReadOnlySpan<T> src, in Histogram<T> dst)
            where T : unmanaged, IEquatable<T>, IComparable<T>
        {
            ref var counts = ref first(span(dst.Counts));
            ref readonly var points = ref first(src);
            for(var i=0u; i<src.Length; i++)
            {
                ref readonly var point = ref skip(points,i);
                var index = gcalc.index<T>(dst, point);
                if(index != uint.MaxValue)
                    ++seek(counts, index - 1);
            }
        }

        /// <summary>
        /// Deposits a point, if possible, into a histogram bucket
        /// </summary>
        /// <param name="src">The point one would like to deposit</param>
        /// <param name="dst">The target histogram</param>
        /// <param name="undeposited">If specified, invoked whenever a bucket can't be found</param>
        /// <typeparam name="T">The point domain</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void deposit<T>(T src, in Histogram<T> dst, Action<T> undeposited = null)
            where T : unmanaged, IEquatable<T>, IComparable<T>
        {
            var deposited = false;
            var segments = dst.Partitions.Length;
            for(var i = 1u; i<segments; i++)
            {
                if(segment(dst, i).Contains(src))
                {
                    dst.Counts[i-1] = ++dst.Counts[i-1];
                    deposited = true;
                    break;
                }
            }

            if(!deposited && undeposited != null)
                undeposited(src);
        }
    }
}