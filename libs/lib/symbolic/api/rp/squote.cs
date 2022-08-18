//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct RpOps
    {
        [MethodImpl(Inline), Op]
        public static string squote(object src)
            => text.enclose(src, CharText.SQuote);
    }
}