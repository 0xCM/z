//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XText
    {
        [MethodImpl(Inline), TextUtility]
        public static string TakeBefore(this string src, char match)
            => RP.before(src, match);
    }
}