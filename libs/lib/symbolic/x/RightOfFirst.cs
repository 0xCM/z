//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XText
    {
        /// <summary>
        /// Gets the string to the right of, but not including, the first instance of a specified character
        /// </summary>
        /// <param name="src">The string to search</param>
        /// <param name="match">The character to match</param>
        [TextUtility]
        public static string RightOfFirst(this string src, char match)
            => src.RightOfIndex(src.IndexOf(match));

        /// <summary>
        /// Gets the string to the right of, but not including, a specified substring
        /// </summary>
        /// <param name="src">The string to search</param>
        /// <param name="match">The substring to match</param>
        [TextUtility]
        public static string RightOfFirst(this string src, string match)
        {
            var idx = src.IndexOf(match);
            if (idx != -1)
                return src.RightOfIndex(idx + match.Length - 1);
            else
                return string.Empty;
        }
    }
}