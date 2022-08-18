//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        /// <summary>
        /// Gets the string to the left of, but not including, a specified index
        /// </summary>
        /// <param name="src">The string to search</param>
        /// <param name="idx">The index</param>
        [TextUtility]
        public static string LeftOfIndex(this string src, int idx)
            => src.Substring(0, idx);
    }
}