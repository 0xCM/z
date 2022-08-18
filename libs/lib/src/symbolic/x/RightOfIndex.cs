//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Root;

    partial class XText
    {
        /// <summary>
        /// Gets the string to the right of, but not including, a specified index
        /// </summary>
        /// <param name="src">The string to search</param>
        /// <param name="idx">The index</param>
        [TextUtility]
        public static string RightOfIndex(this string src, int idx)
            => (idx >= src.Length - 1) ? EmptyString : src.Substring(idx + 1) ?? EmptyString;
    }
}