//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Hex
    {
        [MethodImpl(Inline)]
        public static char delimiter(string src)
            => SQ.index(src, Chars.Comma) > 0 ? Chars.Comma : Chars.Space;
    }
}