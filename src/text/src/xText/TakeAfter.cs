//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XText
    {
        [MethodImpl(Inline), TextUtility]
        public static string TakeAfter(this string src, char match)
            => RP.after(src,match);

        [MethodImpl(Inline), TextUtility]
        public static string TakeAfter(this string s, string match)
            => RP.after(s,match);
    }
}