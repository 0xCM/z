//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Linq;

    using static Root;

    partial class XText
    {
        /// <summary>
        /// Determines whether a string begins with a specific character
        /// </summary>
        /// <param name="s">The string to search</param>
        /// <param name="c">The character to match</param>
        [TextUtility]
        public static bool StartsWith(this string s, char c)
            => !string.IsNullOrWhiteSpace(s) ? s.StartsWith(c.ToString()) : false;

        /// <summary>
        /// Determines whether a string starts with a value from a supplied set
        /// </summary>
        /// <param name="src">The string to examine</param>
        /// <param name="values">The characters for which to search</param>
        [TextUtility]
        public static bool StartsWithAny(this string src, IEnumerable<string> values)
        {
            foreach (var v in values)
                if (src.StartsWith(v))
                    return true;
            return false;
        }

        /// <summary>
        /// Determines whether a string leads with any of a specified set of characters
        /// </summary>
        /// <param name="src">The string to examine</param>
        /// <param name="chars">The characters for which to search</param>
        [TextUtility]
        public static bool StartsWithAny(this string src, IEnumerable<char> chars)
            => string.IsNullOrWhiteSpace(src) ? false : chars.Contains(src[0]);

        /// <summary>
        /// Determines whether a string starts with a digit
        /// </summary>
        /// <param name="s">The string to search</param>
        [MethodImpl(Inline), TextUtility]
        public static bool StartsWithDigit(this string src)
            => !string.IsNullOrWhiteSpace(src) ? Char.IsDigit(src.First()) : false;
    }
}