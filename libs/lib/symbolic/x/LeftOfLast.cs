//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XText
    {
        [TextUtility]
        public static string LeftOfLast(this string src, string match)
            => text.leftoflast(src,match);

        [TextUtility]
        public static string LeftOfLast(this string src, char match)
            => text.leftoflast(src,match);
    }
}