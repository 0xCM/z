//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class sys
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T cast<T>(object src)
            => (T)src;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void cast<T>(ReadOnlySpan<object> src, Span<T> dst)
        {
            var count = Math.Min(src.Length, dst.Length);
            for(var i=0u; i<count; i++)
                seek(dst, i) = (T)(skip(src,i));
        }            
    }
}