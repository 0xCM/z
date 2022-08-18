//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XText
    {
        /// <summary>
        /// Searches for the last index of a specified character in a string
        /// </summary>
        /// <param name="src">The string to search</param>
        /// <param name="match">The character to match</param>
        [TextUtility]
        public static Option<int> LastIndexOf(this string src, char match)
        {
            var idx = src.LastIndexOf(match);
            return idx != -1 ? idx : Option.none<int>();
        }

        /// <summary>
        /// Searches for the last index of a specified character in a string
        /// </summary>
        /// <param name="src">The string to search</param>
        /// <param name="match">The substring to match</param>
        [TextUtility]
        public static Option<int> LastIndexOf(this string src, string match)
        {
            var idx = src.LastIndexOf(match);
            return idx != -1 ? idx : Option.none<int>();
        }
    }
}