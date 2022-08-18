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
        /// Defines the test gt:bit := a > b, succeeding if the left operand is larger than the right operand
        /// </summary>
        /// <param name="a">The first operand</param>
        /// <param name="b">The second operand</param>
        [MethodImpl(Inline), Gt]
        public static bit gt(sbyte a, sbyte b)
            => a > b;

        /// <summary>
        /// Defines the test gt:bit := a > b, succeeding if the left operand is larger than the right operand
        /// </summary>
        /// <param name="a">The first operand</param>
        /// <param name="b">The second operand</param>
        [MethodImpl(Inline), Gt]
        public static bit gt(byte a, byte b)
            => a > b;

        /// <summary>
        /// Defines the test gt:bit := a > b, succeeding if the left operand is larger than the right operand
        /// </summary>
        /// <param name="a">The first operand</param>
        /// <param name="b">The second operand</param>
        [MethodImpl(Inline), Gt]
        public static bit gt(short a, short b)
            => a > b;

        /// <summary>
        /// Defines the test gt:bit := a > b, succeeding if the left operand is larger than the right operand
        /// </summary>
        /// <param name="a">The first operand</param>
        /// <param name="b">The second operand</param>
        [MethodImpl(Inline), Gt]
        public static bit gt(ushort a, ushort b)
            => a > b;

        /// <summary>
        /// Defines the test gt:bit := a > b, succeeding if the left operand is larger than the right operand
        /// </summary>
        /// <param name="a">The first operand</param>
        /// <param name="b">The second operand</param>
        [MethodImpl(Inline), Gt]
        public static bit gt(int a, int b)
            => a > b;

        /// <summary>
        /// Defines the test gt:bit := a > b, succeeding if the left operand is larger than the right operand
        /// </summary>
        /// <param name="a">The first operand</param>
        /// <param name="b">The second operand</param>
        [MethodImpl(Inline), Gt]
        public static bit gt(uint a, uint b)
            => a > b;

        /// <summary>
        /// Defines the test gt:bit := a > b, succeeding if the left operand is larger than the right operand
        /// </summary>
        /// <param name="a">The first operand</param>
        /// <param name="b">The second operand</param>
        [MethodImpl(Inline), Gt]
        public static bit gt(long a, long b)
            => a > b;

        /// <summary>
        /// Defines the test gt:bit := a > b, succeeding if the left operand is larger than the right operand
        /// </summary>
        /// <param name="a">The first operand</param>
        /// <param name="b">The second operand</param>
        [MethodImpl(Inline), Gt]
        public static bit gt(ulong a, ulong b)
            => a > b;
    }
}