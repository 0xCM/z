//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class text
    {
        /// <summary>
        /// Returns true if the source ends with a specified substring
        /// </summary>
        /// <param name="src">The input</param>
        /// <param name="match">The substring to match</param>
        [MethodImpl(Inline), Op]
        public static bool ends(string src, string match)
            => length(src) != 0 && src.EndsWith(match);

        /// <summary>
        /// Returns true if the source ends with a specified character
        /// </summary>
        /// <param name="src">The input</param>
        /// <param name="match">The character to match</param>
        [MethodImpl(Inline), Op]
        public static bool ends(string src, char match)
            => length(src) != 0 && src[length(src) - 1] == match;

        /// <summary>
        /// Returns true if the source begins with a specified substring
        /// </summary>
        /// <param name="src">The input</param>
        /// <param name="match">The substring to match</param>
        [MethodImpl(Inline), Op]
        public static bool ends(ReadOnlySpan<char> src, ReadOnlySpan<char> match)
            => length(src) != 0 && src.StartsWith(match);
    }
}