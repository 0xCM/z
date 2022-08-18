//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    partial class XText
    {
        /// <summary>
        /// Returns true if the character spans are equal as strings, false otherwise
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [TextUtility]
        public static bool Same(this ReadOnlySpan<char> a, ReadOnlySpan<char> b)
             => SQ.eq(a, b);

        /// <summary>
        /// Returns true if the character spans are equal as strings, false otherwise
        /// </summary>
        /// <param name="lhs">The left operand</param>
        /// <param name="rhs">The right operand</param>
        [TextUtility]
        public static bool Same(this Span<char> lhs, ReadOnlySpan<char> rhs)
             => SQ.eq(lhs, rhs);

        /// <summary>
        /// Returns true if the character spans are equal as strings, false otherwise
        /// </summary>
        /// <param name="lhs">The left operand</param>
        /// <param name="rhs">The right operand</param>
        [TextUtility]
        public static bool Same(this Span<char> lhs, Span<char> rhs)
             => SQ.eq(lhs, rhs);
    }
}