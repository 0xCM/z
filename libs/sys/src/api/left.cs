//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class sys
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> left<T>(ReadOnlySpan<T> src, int i)
        {
            var count = i + 1;
            if(count > 0)
            {
                if(src.Length > count)
                    return slice(src,0,count);
                else
                    return src;
            }
            else
                return ReadOnlySpan<T>.Empty;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> left<T>(ReadOnlySpan<T> src, uint i)
            => left(src,(int)i);
    }
}