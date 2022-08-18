//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class XText
    {
        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> ToSpan(this string src)
            => src;
    }
}