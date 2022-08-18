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
        /// Removes all occurrences of a substring from the source strings where extant
        /// </summary>
        /// <param name="s">The strings to manipulate</param>
        /// <param name="substring">The substring to remove</param>
        [TextUtility]
        public static IEnumerable<string> RemoveSubstring(this IEnumerable<string> src, string substring)
            => src.Select(x => x.Remove(substring));
    }
}