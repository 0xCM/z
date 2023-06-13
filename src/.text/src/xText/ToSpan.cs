//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XText
    {
        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> ToSpan(this string src)
            => src;
    }
}