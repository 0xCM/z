//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class text
    {
       [MethodImpl(Inline), Op]
        public static char last(ReadOnlySpan<char> src)
            => src.Length == 0 ? Chars.Null : sys.skip(src, src.Length - 1);
    }
}