//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XText
    {
        /// <summary>
        /// Retrieves the substring that follows the last occurrence of a marker
        /// </summary>
        /// <param name="src">The string to search</param>
        /// <param name="match">The substring to match</param>
        [TextUtility]
        public static string RightOfLast(this string src, string match)
            => text.rightoflast(src,match);

        /// <summary>
        /// Retrieves the substring that follows the last occurrence of a marker
        /// </summary>
        /// <param name="src">The string to search</param>
        /// <param name="match">The substring to match</param>
        [TextUtility]
        public static string RightOfLast(this string src, char match)
            => text.rightoflast(src,match);
    }
}