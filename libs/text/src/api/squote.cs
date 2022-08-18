//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class RP
    {
        [MethodImpl(Inline), Op]
        public static string squote(object src)
            => enclose(src, CharText.SQuote);
    }
}