//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static System.Runtime.Intrinsics.X86.Bmi1;
    using static System.Runtime.Intrinsics.X86.Bmi1.X64;

    partial class math
    {
       /// <summary>
        /// Computes the material nonimplication z := ~a & b for operands a and b
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [MethodImpl(Inline), NonImpl]
        public static sbyte nonimpl(sbyte a, sbyte b)
            => (sbyte)AndNot((uint)a,(uint)b);

        /// <summary>
        /// Computes the material nonimplication z := ~a & b for operands a and b
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [MethodImpl(Inline), NonImpl]
        public static byte nonimpl(byte a, byte b)
            => (byte)AndNot((uint)a,(uint)b);

        /// <summary>
        /// Computes the material nonimplication z := ~a & b for operands a and b
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [MethodImpl(Inline), NonImpl]
        public static short nonimpl(short a, short b)
            => (short)AndNot((uint)a,(uint)b);

        /// <summary>
        /// Computes the material nonimplication z := ~a & b for operands a and b
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [MethodImpl(Inline), NonImpl]
        public static ushort nonimpl(ushort a, ushort b)
            => (ushort)AndNot((uint)a,(uint)b);

        /// <summary>
        /// Computes the material nonimplication z := ~a & b for operands a and b
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [MethodImpl(Inline), NonImpl]
        public static int nonimpl(int a, int b)
            => (int)AndNot((uint)a,(uint)b);

        /// <summary>
        /// Computes the material nonimplication z := ~a & b for operands a and b
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [MethodImpl(Inline), NonImpl]
        public static uint nonimpl(uint a, uint b)
            => AndNot(a,b);

        /// <summary>
        /// Computes the material nonimplication z := ~a & b for operands a and b
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [MethodImpl(Inline), NonImpl]
        public static long nonimpl(long a, long b)
            => (long)AndNot((ulong)a,(ulong)b);

        /// <summary>
        /// Computes the material nonimplication z := ~a & b for operands a and b
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [MethodImpl(Inline), NonImpl]
        public static ulong nonimpl(ulong a, ulong b)
            => AndNot(a,b);

    }
}