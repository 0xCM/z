//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct gcalc
    {
        [MethodImpl(Inline), Srlv, Closures(Closure)]
        public static Span<T> srlv<T>(ReadOnlySpan<T> src, ReadOnlySpan<byte> counts, Span<T> dst)
            where T : unmanaged
        {
            var len = dst.Length;
            ref readonly var input = ref first(src);
            ref readonly var count = ref first(counts);
            ref var target = ref first(dst);
            for(var i=0; i < len; i++)
                seek(target,i) = gmath.srl(skip(input,i), skip(count,i));
            return dst;
        }
    }
}