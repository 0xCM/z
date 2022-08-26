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
        /// Computes the material implication c := a | ~b for operands a and b
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [MethodImpl(Inline), Impl]
        public static sbyte impl(sbyte a, sbyte b)
            => (sbyte)((int)a | ~(int)b);

        /// <summary>
        /// Computes the material implication c := a | ~b for operands a and b
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [MethodImpl(Inline), Impl]
        public static byte impl(byte a, byte b)
            => (byte)(a | ~b);

        /// <summary>
        /// Computes the material implication c := a | ~b for operands a and b
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [MethodImpl(Inline), Impl]
        public static short impl(short a, short b)
            => (short)((int)a | ~(int)b);

        /// <summary>
        /// Computes the material implication c := a | ~b for operands a and b
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [MethodImpl(Inline), Impl]
        public static ushort impl(ushort a, ushort b)
            => (ushort)(a | ~b);

        /// <summary>
        /// Computes the material implication c := a | ~b for operands a and b
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [MethodImpl(Inline), Impl]
        public static int impl(int a, int b)
            => a | ~ b;

        /// <summary>
        /// Computes the material implication c := a | ~b for operands a and b
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [MethodImpl(Inline), Impl]
        public static uint impl(uint a, uint b)
            => a | ~b;

        /// <summary>
        /// Computes the material implication c := a | ~b for operands a and b
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [MethodImpl(Inline), Impl]
        public static long impl(long a, long b)
            => a | ~ b;

        /// <summary>
        /// Computes the material implication c := a | ~b for operands a and b
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [MethodImpl(Inline), Impl]
        public static ulong impl(ulong a, ulong b)
            => a | ~b;
    }
}