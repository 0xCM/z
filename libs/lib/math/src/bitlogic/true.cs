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
        /// Returns all 1's, irrespective of the operand values
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        /// <typeparam name="T">The primal operand type</typeparam>
        [MethodImpl(Inline), False]
        public static sbyte @true(sbyte a, sbyte b)
            => sbyte.MinValue;

        /// <summary>
        /// Returns all 1's, irrespective of the operand values
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        /// <typeparam name="T">The primal operand type</typeparam>
        [MethodImpl(Inline), False]
        public static byte @true(byte a, byte b)
            => byte.MaxValue;

        /// <summary>
        /// Returns all 1's, irrespective of the operand values
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        /// <typeparam name="T">The primal operand type</typeparam>
        [MethodImpl(Inline), False]
        public static short @true(short a, short b)
            => short.MinValue;

        /// <summary>
        /// Returns all 1's, irrespective of the operand values
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        /// <typeparam name="T">The primal operand type</typeparam>
        [MethodImpl(Inline), False]
        public static ushort @true(ushort a, ushort b)
            => ushort.MaxValue;

        /// <summary>
        /// Returns all 1's, irrespective of the operand values
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        /// <typeparam name="T">The primal operand type</typeparam>
        [MethodImpl(Inline), False]
        public static int @true(int a, int b)
            => int.MinValue;

        /// <summary>
        /// Returns all 1's, irrespective of the operand values
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        /// <typeparam name="T">The primal operand type</typeparam>
        [MethodImpl(Inline), False]
        public static uint @true(uint a, uint b)
            => uint.MaxValue;

        /// <summary>
        /// Returns all 1's, irrespective of the operand values
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        /// <typeparam name="T">The primal operand type</typeparam>
        [MethodImpl(Inline), False]
        public static long @true(long a, long b)
            => long.MinValue;

        /// <summary>
        /// Returns all 1's, irrespective of the operand values
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        /// <typeparam name="T">The primal operand type</typeparam>
        [MethodImpl(Inline), False]
        public static ulong @true(ulong a, ulong b)
            => ulong.MaxValue;
    }
}