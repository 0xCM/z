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
        /// Returns 0, irrespective of the operand values
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        /// <typeparam name="T">The primal operand type</typeparam>
        [MethodImpl(Inline), False]
        public static sbyte @false(sbyte a, sbyte b)
            => 0;

        /// <summary>
        /// Returns 0, irrespective of the operand values
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        /// <typeparam name="T">The primal operand type</typeparam>
        [MethodImpl(Inline), False]
        public static byte @false(byte a, byte b)
            => 0;

        /// <summary>
        /// Returns 0, irrespective of the operand values
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        /// <typeparam name="T">The primal operand type</typeparam>
        [MethodImpl(Inline), False]
        public static short @false(short a, short b)
            => 0;

        /// <summary>
        /// Returns 0, irrespective of the operand values
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        /// <typeparam name="T">The primal operand type</typeparam>
        [MethodImpl(Inline), False]
        public static ushort @false(ushort a, ushort b)
            => 0;

        /// <summary>
        /// Returns 0, irrespective of the operand values
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        /// <typeparam name="T">The primal operand type</typeparam>
        [MethodImpl(Inline), False]
        public static int @false(int a, int b)
            => 0;

        /// <summary>
        /// Returns 0, irrespective of the operand values
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        /// <typeparam name="T">The primal operand type</typeparam>
        [MethodImpl(Inline), False]
        public static uint @false(uint a, uint b)
            => 0;

        /// <summary>
        /// Returns 0, irrespective of the operand values
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        /// <typeparam name="T">The primal operand type</typeparam>
        [MethodImpl(Inline), False]
        public static long @false(long a, long b)
            => 0;

        /// <summary>
        /// Returns 0, irrespective of the operand values
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        /// <typeparam name="T">The primal operand type</typeparam>
        [MethodImpl(Inline), False]
        public static ulong @false(ulong a, ulong b)
            => 0;
    }
}