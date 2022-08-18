//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Spans;
    using static Refs;

    partial struct Intervals
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void traverse<T>(ClosedInterval<T> src, Action<T> f)
            where T : unmanaged, IEquatable<T>
        {
            var min = Sized.bw64(src.Min);
            var max = Sized.bw64(src.Max);
            for(var i=min; i<max; i++)
                f(sys.@as<T>(i));
        }

        [MethodImpl(Inline)]
        public static uint traverse<S,T>(ClosedInterval<S> src, Func<S,T> f, uint offset, Span<T> dst)
            where S : unmanaged, IEquatable<S>
        {
            var min = Sized.bw64(src.Min);
            var max = Sized.bw64(src.Max);
            var i0=offset;
            var j=offset;
            for(var i=i0; i<max; i++, j++)
                seek(dst,j) = f(sys.@as<S>(i));
            return i0 - j;
        }
    }
}