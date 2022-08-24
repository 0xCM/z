//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        public static ReadOnlySpan<T> ViewDeposited<T>(this List<T> src)
            => Lists.view(src);
    }
}