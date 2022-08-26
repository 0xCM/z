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
        /// Computes the bitwise nand c := ~(a & b) for operands a and b
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        /// <typeparam name="T">The primal operand type</typeparam>
        [MethodImpl(Inline), Nand]
        public static sbyte nand(sbyte a, sbyte b)
            => not(and(a,b));

        /// <summary>
        /// Computes the bitwise nand c := ~(a & b) for operands a and b
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        /// <typeparam name="T">The primal operand type</typeparam>
        [MethodImpl(Inline), Nand]
        public static byte nand(byte a, byte b)
            => not(and(a,b));

        /// <summary>
        /// Computes the bitwise nand c := ~(a & b) for operands a and b
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        /// <typeparam name="T">The primal operand type</typeparam>
        [MethodImpl(Inline), Nand]
        public static short nand(short a, short b)
            => not(and(a,b));

        /// <summary>
        /// Computes the bitwise nand c := ~(a & b) for operands a and b
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        /// <typeparam name="T">The primal operand type</typeparam>
        [MethodImpl(Inline), Nand]
        public static ushort nand(ushort a, ushort b)
            => not(and(a,b));

        /// <summary>
        /// Computes the bitwise nand c := ~(a & b) for operands a and b
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        /// <typeparam name="T">The primal operand type</typeparam>
        [MethodImpl(Inline), Nand]
        public static int nand(int a, int b)
            => ~ (a & b);

        /// <summary>
        /// Computes the bitwise nand c := ~(a & b) for operands a and b
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        /// <typeparam name="T">The primal operand type</typeparam>
        [MethodImpl(Inline), Nand]
        public static uint nand(uint a, uint b)
            => ~ (a & b);

        /// <summary>
        /// Computes the bitwise nand c := ~(a & b) for operands a and b
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        /// <typeparam name="T">The primal operand type</typeparam>
        [MethodImpl(Inline), Nand]
        public static long nand(long a, long b)
            => ~ (a & b);

        /// <summary>
        /// Computes the bitwise nand c := ~(a & b) for operands a and b
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        /// <typeparam name="T">The primal operand type</typeparam>
        [MethodImpl(Inline), Nand]
        public static ulong nand(ulong a, ulong b)
            => ~ (a & b);
    }
}