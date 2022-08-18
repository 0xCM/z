//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XText
    {
        [TextUtility]
        public static string Between(this string src, char left, char right)
            => RP.between(src, left, right);
    }
}