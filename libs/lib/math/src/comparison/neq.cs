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
        /// Defines the test neq:bit := a != b, succeeding if the operands are not equal
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [MethodImpl(Inline), Neq]
        public static bit neq(sbyte a, sbyte b)
            => a != b;

        /// <summary>
        /// Defines the test neq:bit := a != b, succeeding if the operands are not equal
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [MethodImpl(Inline), Neq]
        public static bit neq(byte a, byte b)
            => a != b;

        /// <summary>
        /// Defines the test neq:bit := a != b, succeeding if the operands are not equal
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [MethodImpl(Inline), Neq]
        public static bit neq(short a, short b)
            => a != b;

        /// <summary>
        /// Defines the test neq:bit := a != b, succeeding if the operands are not equal
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [MethodImpl(Inline), Neq]
        public static bit neq(ushort a, ushort b)
            => a != b;

        /// <summary>
        /// Defines the test neq:bit := a != b, succeeding if the operands are not equal
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [MethodImpl(Inline), Neq]
        public static bit neq(int a, int b)
            => a != b;

        /// <summary>
        /// Defines the test neq:bit := a != b, succeeding if the operands are not equal
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [MethodImpl(Inline), Neq]
        public static bit neq(uint a, uint b)
            => a != b;

        /// <summary>
        /// Defines the test neq:bit := a != b, succeeding if the operands are not equal
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [MethodImpl(Inline), Neq]
        public static bit neq(long a, long b)
            => a != b;

        /// <summary>
        /// Defines the test neq:bit := a != b, succeeding if the operands are not equal
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [MethodImpl(Inline), Neq]
        public static bit neq(ulong a, ulong b)
            => a != b;
    }
}