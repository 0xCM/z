//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct gcalc
    {
        [MethodImpl(Inline), Srl, Closures(Closure)]
        public static Span<T> srl<T>(ReadOnlySpan<T> src, byte count, Span<T> dst)
            where T : unmanaged
        {
            var len = dst.Length;
            ref readonly var input = ref first(src);
            ref var target = ref first(dst);
            for(var i = 0; i<len; i++)
                seek(target,i) = gmath.srl(skip(input,i), count);
            return dst;
        }
    }
}