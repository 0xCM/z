//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class text
    {
        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> chars(string src)
            => src;
    }
}