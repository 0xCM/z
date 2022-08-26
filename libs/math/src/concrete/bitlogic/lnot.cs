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
        /// Computes the bitwise not of the left operand
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [MethodImpl(Inline), LNot]
        public static sbyte lnot(sbyte a, sbyte b)
            => not(a);

        /// <summary>
        /// Computes the bitwise not of the left operand
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [MethodImpl(Inline), LNot]
        public static byte lnot(byte a, byte b)
            => not(a);

        /// <summary>
        /// Computes the bitwise not of the left operand
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [MethodImpl(Inline), LNot]
        public static short lnot(short a, short b)
            => not(a);

        /// <summary>
        /// Computes the bitwise not of the left operand
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [MethodImpl(Inline), LNot]
        public static ushort lnot(ushort a, ushort b)
            => not(a);

        /// <summary>
        /// Computes the bitwise not of the left operand
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [MethodImpl(Inline), LNot]
        public static int lnot(int a, int b)
            => not(a);

        /// <summary>
        /// Computes the bitwise not of the left operand
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [MethodImpl(Inline), LNot]
        public static uint lnot(uint a, uint b)
            => not(a);

        /// <summary>
        /// Computes the bitwise not of the left operand
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [MethodImpl(Inline), LNot]
        public static long lnot(long a, long b)
            => not(a);

        /// <summary>
        /// Computes the bitwise not of the left operand
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [MethodImpl(Inline), LNot]
        public static ulong lnot(ulong a, ulong b)
            => not(a);
    }
}