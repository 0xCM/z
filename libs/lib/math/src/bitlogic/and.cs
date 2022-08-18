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
        /// Computes the bitwise and c := ~(a & b) for operands a and b
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        /// <typeparam name="T">The primal operand type</typeparam>
        [MethodImpl(Inline), And]
        public static sbyte and(sbyte a, sbyte b)
            => (sbyte)(a & b);

        /// <summary>
        /// Computes the bitwise and c := ~(a & b) for operands a and b
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        /// <typeparam name="T">The primal operand type</typeparam>
        [MethodImpl(Inline), And]
        public static byte and(byte a, byte b)
            => (byte)(a & b);

        /// <summary>
        /// Computes the bitwise and c := ~(a & b) for operands a and b
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        /// <typeparam name="T">The primal operand type</typeparam>
        [MethodImpl(Inline), And]
        public static short and(short a, short b)
            => (short)(a & b);

        /// <summary>
        /// Computes the bitwise and c := ~(a & b) for operands a and b
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        /// <typeparam name="T">The primal operand type</typeparam>
        [MethodImpl(Inline), And]
        public static ushort and(ushort a, ushort b)
            => (ushort)(a & b);

        /// <summary>
        /// Computes the bitwise and c := ~(a & b) for operands a and b
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        /// <typeparam name="T">The primal operand type</typeparam>
        [MethodImpl(Inline), And]
        public static int and(int a, int b)
            => a & b;

        /// <summary>
        /// Computes the bitwise and c := ~(a & b) for operands a and b
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        /// <typeparam name="T">The primal operand type</typeparam>
        [MethodImpl(Inline), And]
        public static uint and(uint a, uint b)
            => a & b;

        /// <summary>
        /// Computes the bitwise and c := ~(a & b) for operands a and b
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        /// <typeparam name="T">The primal operand type</typeparam>
        [MethodImpl(Inline), And]
        public static long and(long a, long b)
            => a & b;

        /// <summary>
        /// Computes the bitwise and c := ~(a & b) for operands a and b
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        /// <typeparam name="T">The primal operand type</typeparam>
        [MethodImpl(Inline), And]
        public static ulong and(ulong a, ulong b)
            => a & b;
  }
}