//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct Symbols
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static uint kinds<T>(Symbols<T> src, Span<T> dst)
            where T : unmanaged
        {
            var count = (uint)min(src.Length,dst.Length);
            var view = src.Kinds;
            for(var i=0u; i<count; i++)
                seek(dst,i) = skip(view,i);
            return count;
        }

        public static ReadOnlySpan<K> kinds<K>()
            where K : unmanaged, Enum
                => index<K>().Kinds;
    }
}