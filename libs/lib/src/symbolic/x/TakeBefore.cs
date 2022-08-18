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
        [MethodImpl(Inline), TextUtility]
        public static string TakeBefore(this string src, char match)
            => RpOps.before(src, match);
    }
}