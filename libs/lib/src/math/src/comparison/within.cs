//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    partial class math
    {
        /// <summary>
        /// Defines the test within:bit := dist(a,b) <= delta
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        /// <param name="delta">The delta</param>
        [MethodImpl(Inline), Within]
        public static bit within(sbyte a, sbyte b, sbyte delta)
            => dist(a,b) <= (uint)delta;

        /// <summary>
        /// Defines the test within:bit := dist(a,b) <= delta
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        /// <param name="delta">The delta</param>
        [MethodImpl(Inline), Within]
        public static bit within(byte a, byte b, byte delta)
            => dist(a,b) <= delta;

        /// <summary>
        /// Defines the test within:bit := dist(a,b) <= delta
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        /// <param name="delta">The delta</param>
        [MethodImpl(Inline), Within]
        public static bit within(short a, short b, short delta)
            => dist(a,b) <= (uint)delta;

        /// <summary>
        /// Defines the test within:bit := dist(a,b) <= delta
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        /// <param name="delta">The delta</param>
        [MethodImpl(Inline), Within]
        public static bit within(ushort a, ushort b, ushort delta)
            => dist(a,b) <= delta;

        /// <summary>
        /// Defines the test within:bit := dist(a,b) <= delta
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        /// <param name="delta">The delta</param>
        [MethodImpl(Inline), Within]
        public static bit within(int a, int b, int delta)
            => dist(a,b) <= (uint)delta;

        /// <summary>
        /// Defines the test within:bit := dist(a,b) <= delta
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        /// <param name="delta">The delta</param>
        [MethodImpl(Inline), Within]
        public static bit within(uint a, uint b, uint delta)
            => dist(a,b) <= delta;

        /// <summary>
        /// Defines the test within:bit := dist(a,b) <= delta
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        /// <param name="delta">The delta</param>
        [MethodImpl(Inline), Within]
        public static bit within(long a, long b, long delta)
            => dist(a,b) <= (ulong)delta;

        /// <summary>
        /// Defines the test within:bit := dist(a,b) <= delta
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        /// <param name="delta">The delta</param>
        [MethodImpl(Inline), Within]
        public static bit within(ulong a, ulong b, ulong delta)
            => dist(a,b) <= delta;
    }
}