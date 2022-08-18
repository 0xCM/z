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
        /// Computes the bitwise not of the right operand
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [MethodImpl(Inline), RNot]
        public static sbyte rnot(sbyte a, sbyte b)
            => not(b);

        /// <summary>
        /// Computes the bitwise not of the right operand
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [MethodImpl(Inline), RNot]
        public static byte rnot(byte a, byte b)
            => not(b);

        /// <summary>
        /// Computes the bitwise not of the right operand
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [MethodImpl(Inline), RNot]
        public static short rnot(short a, short b)
            => not(b);

        /// <summary>
        /// Computes the bitwise not of the right operand
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [MethodImpl(Inline), RNot]
        public static ushort rnot(ushort a, ushort b)
            => not(b);

        /// <summary>
        /// Computes the bitwise not of the right operand
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [MethodImpl(Inline), RNot]
        public static int rnot(int a, int b)
            => not(b);

        /// <summary>
        /// Computes the bitwise not of the right operand
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [MethodImpl(Inline), RNot]
        public static uint rnot(uint a, uint b)
            => not(b);

        /// <summary>
        /// Computes the bitwise not of the right operand
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [MethodImpl(Inline), RNot]
        public static long rnot(long a, long b)
            => not(b);

        /// <summary>
        /// Computes the bitwise not of the right operand
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [MethodImpl(Inline), RNot]
        public static ulong rnot(ulong a, ulong b)
            => not(b);
    }
}