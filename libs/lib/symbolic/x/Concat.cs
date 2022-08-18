//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    partial class XText
    {
        /// <summary>
        /// Forms a string by source character juxtaposition
        /// </summary>
        /// <param name="src">The characters to concatenate</param>
        [TextUtility]
        public static string Concat(this IEnumerable<char> src)
            => new string(src.ToArray());

        /// <summary>
        /// Forms a string from a character array
        /// </summary>
        /// <param name="src">The source array</param>
        [TextUtility]
        public static string Concat(this char[] src)
            => new string(src);

        /// <summary>
        /// Forms a string by source character juxtaposition
        /// </summary>
        /// <param name="src">The source span</param>
        [TextUtility]
        public static string Concat(this ReadOnlySpan<char> src)
            => new string(src);

        /// <summary>
        /// Forms a string by source character juxtaposition
        /// </summary>
        /// <param name="src">The source span</param>
        [TextUtility]
        public static string Concat(this Span<char> src)
            => new string(src);

        /// <summary>
        /// Forms a string by source character juxtaposition
        /// </summary>
        /// <param name="src">The source span</param>
        [TextUtility]
        public static ReadOnlySpan<char> Concat(this ReadOnlySpan<char> a, ReadOnlySpan<char> b)
            => a.Concat() + b.Concat();

        /// <summary>
        /// Joins the strings provided by the enumerable with an optional separator
        /// </summary>
        /// <param name="src">The source strings</param>
        /// <param name="sep">The separator, if any</param>
        [TextUtility]
        public static string Concat(this IEnumerable<string> src, string delimiter = "")
            => string.Join(delimiter, src);

        /// <summary>
        /// Joins the strings provided by the enumerable with an optional separator
        /// </summary>
        /// <param name="src">The source strings</param>
        /// <param name="sep">The separator, if any</param>
        [TextUtility]
        public static string Concat(this string[] src, string delimiter = "")
            => string.Join(delimiter, src);

        /// <summary>
        /// Sequentially concatenates each indexed cell to the next without deimiters/interspersal
        /// </summary>
        /// <param name="src">The source text</param>
        [TextUtility]
        public static string Concat(this Span<string> src, string delimiter = "")
            => src.Join(delimiter);
    }
}