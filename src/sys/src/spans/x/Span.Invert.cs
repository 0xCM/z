//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> Invert<T>(this Span<T> src)
        {
            src.Reverse();
            return src;
        }
    }
}