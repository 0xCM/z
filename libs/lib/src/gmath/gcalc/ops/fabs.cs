//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct gcalc
    {
        [MethodImpl(Inline), Abs, Closures(Floats)]
        public static Span<T> fabs<T>(ReadOnlySpan<T> src, Span<T> dst)
            where T : unmanaged
        {
            var count = src.Length;
            ref var a = ref first(dst);
            ref readonly var b = ref first(src);
            for(var i =0; i<count; i++)
                seek(a, i) = gfp.abs(skip(b, i));
            return dst;
        }
    }
}