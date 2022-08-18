//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    partial class XText
    {
        /// <summary>
        /// Extracts content demarcated by left/right character boundaries
        /// </summary>
        /// <param name="src">The source text</param>
        /// <param name="left">The left marker</param>
        /// <param name="right">THe right marker</param>
        [TextUtility]
        public static string Unfence(this string src, char left, char right)
            => src.RightOfFirst(left).LeftOfLast(right);
    }
}