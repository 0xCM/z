//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    partial struct gfp
    {
        [MethodImpl(Inline), Ceil, Closures(Floats)]
        public static Span<T> ceil<T>(ReadOnlySpan<T> src, Span<T> dst)
            where T : unmanaged
        {
            var count = math.min(src.Length, dst.Length);
            ref var output = ref first(dst);
            ref readonly var input = ref first(src);
            for(var i =0; i<count; i++)
                seek(output, i) = gfp.ceil(skip(input, i));
            return dst;
        }

        [MethodImpl(Inline), Ceil, Closures(Floats)]
        public static Span<T> ceil<T>(Span<T> src)
            where T : unmanaged
        {
            var count = src.Length;
            ref var a = ref first(src);
            ref readonly var b = ref first(src);
            for(var i =0; i<count; i++)
                seek(a, i) = gfp.ceil(skip(b, i));
            return src;
        }
    }
}