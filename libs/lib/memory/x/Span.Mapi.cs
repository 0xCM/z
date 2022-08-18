//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XTend
    {
        public static T[] Mapi<S,T>(this ReadOnlySpan<S> src, Func<int,S,T> f)
        {
            var count = src.Length;
            var dst = new T[count];
            for(var i=0; i<count; i++)
                seek(dst, i) = f(i, skip(src,i));
            return dst;
        }

        public static T[] Mapi<S,T>(this Span<S> src, Func<int,S,T> f)
        {
            var count = src.Length;
            var dst = new T[count];
            for(var i=0; i<count; i++)
                seek(dst, i) = f(i, skip(src,i));
            return dst;
        }
    }
}