//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        /// <summary>
        /// Splits the source string predicated on a string delimiter, removing any empy entries
        /// </summary>
        /// <param name="s">The string to split</param>
        /// <param name="delimiter">The delimiter</param>
        [TextUtility]
        public static string[] SplitClean(this string s, string delimiter)
            => s.Split(new string[]{delimiter}, StringSplitOptions.RemoveEmptyEntries);

        /// <summary>
        /// Splits the source string predicated on a character delimiter, removing any empy entries
        /// </summary>
        /// <param name="s">The string to split</param>
        /// <param name="delimiter">The delimiter</param>
        [TextUtility]
        public static string[] SplitClean(this string s, char delimiter)
            => s.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
    }
}