//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class math
    {
        /// <summary>
        /// Computes the nonnegative distance between two numbers
        /// </summary>
        /// <param name="a">The first number</param>
        /// <param name="b">The second number</param>
        [MethodImpl(Inline), Dist]
        public static ulong dist(byte a, byte b)
            => a >= b ? (ulong)(a - b) : (ulong)(b - a);

        /// <summary>
        /// Computes the nonnegative distance between two numbers
        /// </summary>
        /// <param name="a">The first number</param>
        /// <param name="b">The second number</param>
        [MethodImpl(Inline), Dist]
        public static ulong dist(sbyte a, sbyte b)
            => a >= b ? (ulong)(a - b) : (ulong)(b - a);

        /// <summary>
        /// Computes the nonnegative distance between two numbers
        /// </summary>
        /// <param name="a">The first number</param>
        /// <param name="b">The second number</param>
        [MethodImpl(Inline), Dist]
        public static ulong dist(short a, short b)
            => a >= b ? (ulong)(a - b) : (ulong)(b - a);

        /// <summary>
        /// Computes the nonnegative distance between two numbers
        /// </summary>
        /// <param name="a">The first number</param>
        /// <param name="b">The second number</param>
        [MethodImpl(Inline), Dist]
        public static ulong dist(ushort a, ushort b)
            => a >= b ? (ulong)(a - b) : (ulong)(b - a);

        /// <summary>
        /// Computes the nonnegative distance between two numbers
        /// </summary>
        /// <param name="a">The first number</param>
        /// <param name="b">The second number</param>
        [MethodImpl(Inline), Dist]
        public static ulong dist(int a, int b)
            => a >= b ? (ulong)(a - b) : (ulong)(b - a);

        /// <summary>
        /// Computes the nonnegative distance between two numbers
        /// </summary>
        /// <param name="a">The first number</param>
        /// <param name="b">The second number</param>
        [MethodImpl(Inline), Dist]
        public static ulong dist(uint a, uint b)
            => a >= b ? (ulong)(a - b) : (ulong)(b - a);

        /// <summary>
        /// Computes the nonnegative distance between two numbers
        /// </summary>
        /// <param name="a">The first number</param>
        /// <param name="b">The second number</param>
        [MethodImpl(Inline), Dist]
        public static ulong dist(long a, long b)
            => a >= b ? (ulong)(a - b) : (ulong)(b - a);

        /// <summary>
        /// Computes the nonnegative distance between two numbers
        /// </summary>
        /// <param name="a">The first number</param>
        /// <param name="b">The second number</param>
        [MethodImpl(Inline), Dist]
        public static ulong dist(ulong a, ulong b)
            => a >= b ? a - b : b - a;
    }
}