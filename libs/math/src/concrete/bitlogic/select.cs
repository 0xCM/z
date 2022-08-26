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
        /// Computes the bitwise select of the operands
        /// </summary>
        /// <param name="a">The first operand</param>
        /// <param name="b">The second operand</param>
        /// <param name="c">The third operand</param>
        [MethodImpl(Inline), Select]
        public static sbyte select(sbyte a, sbyte b, sbyte c)
            => (sbyte)select((int)a, (int)b, (int)c);

        /// <summary>
        /// Computes the bitwise select of the operands
        /// </summary>
        /// <param name="a">The first operand</param>
        /// <param name="b">The second operand</param>
        /// <param name="c">The third operand</param>
        [MethodImpl(Inline), Select]
        public static byte select(byte a, byte b, byte c)
            => (byte)select((uint)a, (uint)b, (uint)c);

        /// <summary>
        /// Computes the bitwise select of the operands
        /// </summary>
        /// <param name="a">The first operand</param>
        /// <param name="b">The second operand</param>
        /// <param name="c">The third operand</param>
        [MethodImpl(Inline), Select]
        public static short select(short a, short b, short c)
            => (short)select((int)a, (int)b, (int)c);

        /// <summary>
        /// Computes the bitwise select of the operands
        /// </summary>
        /// <param name="a">The first operand</param>
        /// <param name="b">The second operand</param>
        /// <param name="c">The third operand</param>
        [MethodImpl(Inline), Select]
        public static ushort select(ushort a, ushort b, ushort c)
            => (ushort)select((uint)a, (uint)b, (uint)c);

        /// <summary>
        /// Computes the bitwise select of the operands
        /// </summary>
        /// <param name="a">The first operand</param>
        /// <param name="b">The second operand</param>
        /// <param name="c">The third operand</param>
        [MethodImpl(Inline), Select]
        public static int select(int a, int b, int c)
            => or(and(a,b), nonimpl(a,c));

        /// <summary>
        /// Computes the bitwise select of the operands
        /// </summary>
        /// <param name="a">The first operand</param>
        /// <param name="b">The second operand</param>
        /// <param name="c">The third operand</param>
        [MethodImpl(Inline), Select]
        public static uint select(uint a, uint b, uint c)
            => or(and(a,b), nonimpl(a,c));

        /// <summary>
        /// Computes the bitwise select of the operands
        /// </summary>
        /// <param name="a">The first operand</param>
        /// <param name="b">The second operand</param>
        /// <param name="c">The third operand</param>
        [MethodImpl(Inline), Select]
        public static long select(long a, long b, long c)
            => or(and(a,b), nonimpl(a,c));

        /// <summary>
        /// Computes the bitwise select of the operands
        /// </summary>
        /// <param name="a">The first operand</param>
        /// <param name="b">The second operand</param>
        /// <param name="c">The third operand</param>
        [MethodImpl(Inline), Select]
        public static ulong select(ulong a, ulong b, ulong c)
            => or(and(a,b), nonimpl(a,c));
    }
}