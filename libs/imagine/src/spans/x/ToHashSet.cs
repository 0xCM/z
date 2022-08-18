//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    using static Algs;
    
    partial class XTend
    {
        public static HashSet<T> ToHashSet<T>(this ReadOnlySpan<T> src)
        {
            var dst = hashset<T>();
            iter(src, x => dst.Add(x));
            return dst;
        }

        public static HashSet<T> ToHashSet<T>(this Span<T> src)
            => src.ReadOnly().ToHashSet();
    }
}