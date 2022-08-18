//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct core
    {
        [MethodImpl(Inline), Sum, Closures(Closure)]
        public static T sum<T>(ReadOnlySpan<T> src)
            where T : unmanaged
        {
            var count = src.Length;
            var total = 0ul;
            for(var i=0; i<count; i++)
                total += bw64(skip(src,i));
            return @as<ulong,T>(total);
        }
    }
}