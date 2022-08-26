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
        /// Returns the left operand value
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        /// <typeparam name="T">The primal operand type</typeparam>
        [MethodImpl(Inline), Left]
        public static sbyte left(sbyte a, sbyte b)
            => a;

        /// <summary>
        /// Returns the left operand value
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        /// <typeparam name="T">The primal operand type</typeparam>
        [MethodImpl(Inline), Left]
        public static byte left(byte a, byte b)
            => a;

        /// <summary>
        /// Returns the left operand value
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        /// <typeparam name="T">The primal operand type</typeparam>
        [MethodImpl(Inline), Left]
        public static short left(short a, short b)
            => a;

        /// <summary>
        /// Returns the left operand value
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        /// <typeparam name="T">The primal operand type</typeparam>
        [MethodImpl(Inline), Left]
        public static ushort left(ushort a, ushort b)
            => a;

        /// <summary>
        /// Returns the left operand value
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        /// <typeparam name="T">The primal operand type</typeparam>
        [MethodImpl(Inline), Left]
        public static int left(int a, int b)
            => a;

        /// <summary>
        /// Returns the left operand value
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        /// <typeparam name="T">The primal operand type</typeparam>
        [MethodImpl(Inline), Left]
        public static uint left(uint a, uint b)
            => a;

        /// <summary>
        /// Returns the left operand value
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        /// <typeparam name="T">The primal operand type</typeparam>
        [MethodImpl(Inline), Left]
        public static long left(long a, long b)
            => a;

        /// <summary>
        /// Returns the left operand value
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        /// <typeparam name="T">The primal operand type</typeparam>
        [MethodImpl(Inline), Left]
        public static ulong left(ulong a, ulong b)
            => a;

    }
}