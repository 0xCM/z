//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Spans
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> fuse<T>(Span<T> xs, Span<T> ys, Func<T,T,T> f)
        {
            var count = xs.Length;
            ref var xh = ref Spans.first(xs);
            ref var yh = ref Spans.first(ys);
            for(var i = 0u; i<count ; i++)
                sys.seek(xh, i) = f(sys.skip(xh,i), sys.skip(yh, i));
            return xs;
        }
    }
}