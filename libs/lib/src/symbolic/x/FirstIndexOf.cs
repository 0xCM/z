//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static Root;
    using static core;

    partial class XText
    {
        /// <summary>
        /// Searches a string for the first occurrence of a specified character
        /// </summary>
        /// <param name="src">The string to search</param>
        /// <param name="match">The character to match</param>
        [TextUtility]
        public static Option<int> FirstIndexOf(this string src, char match)
        {
            var idx = src.IndexOf(match);
            return idx != -1 ? idx : Option.none<int>();
        }

        /// <summary>
        /// Searches a string for the first occurrence of a specified character
        /// </summary>
        /// <param name="src">The string to search</param>
        /// <param name="match">The character to match</param>
        [TextUtility, Closures(UInt8k | UInt16k)]
        public static Option<int> FirstIndexOf<T>(this string src, T match)
            where T : unmanaged
        {
            var idx = src.IndexOf(@as<T,char>(match));
            return idx != -1 ? idx : Option.none<int>();
        }

        /// <summary>
        /// Searches a string for the first occurrence of a specified substring
        /// </summary>
        /// <param name="src">The string to search</param>
        /// <param name="match">The substring to match</param>
        [TextUtility]
        public static Option<int> FirstIndexOf(this string src, string match)
        {
            var idx = src.IndexOf(match);
            return idx != -1 ? idx : Option.none<int>();
        }
    }
}