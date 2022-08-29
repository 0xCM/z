//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class sys
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> right<T>(ReadOnlySpan<T> src, int i)
        {
            var offset = i + 1;
            if(i >  0 && src.Length > offset)
                return slice(src, offset);
            else
                return ReadOnlySpan<T>.Empty;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> right<T>(ReadOnlySpan<T> src, uint i)
            => right(src,(int)i);
    }
}