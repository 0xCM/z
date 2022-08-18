//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static Root;

    partial class XText
    {
        /// <summary>
        /// Creates a new string from the first n - 1 characters of a string of length n
        /// </summary>
        /// <param name="s">The source string</param>
        [TextUtility]
        public static string RemoveLast(this string s)
            => string.IsNullOrWhiteSpace(s) ? EmptyString : s.Substring(0, s.Length - 1);
    }
}