//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XText
    {
        [TextUtility]
        public static IEnumerable<string> Trim(this IEnumerable<string> src)
            => src.Select(s => s.Trim());

        [TextUtility]
        public static string[] Trim(this string[] src)
            => src.Select(s => s.Trim());
    }
}