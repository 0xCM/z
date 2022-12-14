//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class sys
    {
        [Op, Closures(Closure)]
        public static T[] reverse<T>(T[] src)
        {
            Array.Reverse(src);
            return src;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void reverse<T>(ReadOnlySpan<T> src, Span<T> dst)
        {
            var count = src.Length;
            var j=0;
            for(var i=count-1; i>= 0; i--,j++)
                seek(dst,j) = skip(src,i);
        }
    }
}