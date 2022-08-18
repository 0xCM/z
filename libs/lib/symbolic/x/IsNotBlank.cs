//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XText
    {
        /// <summary>
        /// Returns true if a string has at least one character that is not considered whitespace
        /// </summary>
        /// <param name="src">The string to evaluate</param>
        [TextUtility]
        public static bool IsNotBlank(this string src)
            => !string.IsNullOrWhiteSpace(src);
    }
}