//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct Symbols
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void descriptions<T>(Symbols<T> src, Span<TextBlock> dst)
            where T : unmanaged
        {
            var count = min(src.Length,dst.Length);
            var view = src.View;
            for(var i=0u; i<count; i++)
                seek(dst,i) = src[i].Description;
        }
    }
}