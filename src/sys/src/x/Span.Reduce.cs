//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class XTend
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T Reduce<T>(this ReadOnlySpan<T> src, Func<T,T,T> f)
        {
            var count = src.Length;
            if(count == 0)
                return default;
            else if(count == 1)
                return first(src);
            else
            {
                var x = first(src);
                for(var i=1; i<count; i++)
                    x = f(x, skip(src,i));
                return x;
            }
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T Reduce<T>(this Span<T> src, Func<T,T,T> f)
            => src.ReadOnly().Reduce(f);
    }
}