//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost]
    public readonly partial struct Loops
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void run<T>(in RangeLoop<uint,T> loop, ReadOnlySpan<T> src)
        {
            for(var i=loop.Min; i<loop.Max; i+= loop.Step)
                loop.Receiver(i, skip(src,i));
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe void run<T>(uint min, uint max, uint step, T* pSrc, Action<uint,T> dst)
            where T : unmanaged
        {
            for(var i=min; i<max; i+= step)
                dst(i, skip(pSrc,i));
        }


        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe void run<T>(ReadOnlySpan<T> src, Action<uint,T> dst)
            where T : unmanaged
        {
            for(var i=0u; i<src.Length; i++)
                dst(i, skip(src,i));
        }

        public static RangeLoop<K,T> define<T,K>(K min, K max, K step, Action<K,T> receiver)
            where K : unmanaged
                => new RangeLoop<K,T>(min, max, step, receiver);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref Accrue<I> run<I>(RangeLoop<I> loop, ref Accrue<I> dst)
            where I : unmanaged, IComparable<I>
        {
            var min = int64(loop.LowerBound) + (loop.LowerInclusive ? 0 : -1);
            var max = int64(loop.UpperBound) + (loop.UpperInclusive ? 1 : 0);
            for(var a=min; a<max; a++)
                dst.Next(@as<long,I>(a));
            return ref dst;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static RangeLoop<I> define<I>(Interval<I> bounds, I? step = null)
            where I : unmanaged, IComparable<I>
       {
            var dst = new RangeLoop<I>();
            dst.LowerBound = bounds.Left;
            dst.UpperBound = bounds.Right;
            dst.LowerInclusive = bounds.LeftClosed;
            dst.UpperInclusive = bounds.RightClosed;
            dst.Step = step ?? one<I>();
            return dst;
       }

        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static void run<T>(Pair<T> limits, Func<T,T> f, Action<T> g)
            where T : unmanaged
        {
            var min = limits.Left;
            var max = limits.Right;
            var i = min;
            while(gmath.lt(i,max))
            {
                g(f(i));
                i = gmath.inc(i);
            }
        }

        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static void run<T>(in T min, in T max, Action<T> f, in T step)
            where T : unmanaged
        {
            var i = min;
            while(gmath.lt(i,max))
            {
                f(i);
                i = gmath.add(i,step);
            }
        }
    }
}