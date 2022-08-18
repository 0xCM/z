//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XText
    {
        [TextUtility]
        public static string Join(this IEnumerable<string> src, char sep)
            => string.Join(sep, src);

        /// <summary>
        /// Joins the strings provided by the enumerable with an optional separator
        /// </summary>
        /// <param name="src">The source strings</param>
        /// <param name="sep">The separator, if any</param>
        [TextUtility]
        public static string Join(this IEnumerable<string> src, string sep)
            => string.Join(sep, src);

        [TextUtility]
        public static string Join(this Span<string> src, string sep)
            => text.concat(src, sep);

        [TextUtility]
        public static string Join(this ReadOnlySpan<string> src, char sep)
            => text.concat(src, sep);

        [TextUtility]
        public static string Join(this ReadOnlySpan<string> src, string sep)
            => text.concat(src, sep);

        /// <summary>
        /// Sequentially concatenates each indexed cell to the next, separated by a specified character
        /// </summary>
        /// <param name="src">The source text</param>
        [TextUtility]
        public static string Join(this Span<string> src, char sep)
            => text.concat(src, sep);
    }
}