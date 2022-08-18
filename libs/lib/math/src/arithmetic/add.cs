//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class math
    {
        /// <summary>
        /// Computes the arithmetic sum of the source operands
        /// </summary>
        /// <param name="a">The first operand</param>
        /// <param name="b">The second operand</param>
        [MethodImpl(Inline), Add]
        public static sbyte add(sbyte a, sbyte b)
            => (sbyte)(a + b);

        /// <summary>
        /// Computes the arithmetic sum of the source operands
        /// </summary>
        /// <param name="a">The first operand</param>
        /// <param name="b">The second operand</param>
        [MethodImpl(Inline), Add]
        public static byte add(byte a, byte b)
            => (byte)(a + b);

        /// <summary>
        /// Computes the arithmetic sum of the source operands
        /// </summary>
        /// <param name="a">The first operand</param>
        /// <param name="b">The second operand</param>
        [MethodImpl(Inline), Add]
        public static short add(short a, short b)
            => (short)(a + b);

        /// <summary>
        /// Computes the arithmetic sum of the source operands
        /// </summary>
        /// <param name="a">The first operand</param>
        /// <param name="b">The second operand</param>
        [MethodImpl(Inline), Add]
        public static ushort add(ushort a, ushort b)
            => (ushort)(a + b);

        /// <summary>
        /// Computes the arithmetic sum of the source operands
        /// </summary>
        /// <param name="a">The first operand</param>
        /// <param name="b">The second operand</param>
        [MethodImpl(Inline), Add]
        public static int add(int a, int b)
            => a + b;

        /// <summary>
        /// Computes the arithmetic sum of the source operands
        /// </summary>
        /// <param name="a">The first operand</param>
        /// <param name="b">The second operand</param>
        [MethodImpl(Inline), Add]
        public static uint add(uint a, uint b)
            => a + b;

        /// <summary>
        /// Computes the arithmetic sum of the source operands
        /// </summary>
        /// <param name="a">The first operand</param>
        /// <param name="b">The second operand</param>
        [MethodImpl(Inline), Add]
        public static long add(long a, long b)
            => a + b;

        /// <summary>
        /// Computes the arithmetic sum of the source operands
        /// </summary>
        /// <param name="a">The first operand</param>
        /// <param name="b">The second operand</param>
        [MethodImpl(Inline), Add]
        public static ulong add(ulong a, ulong b)
            => a + b;

        /// <summary>
        /// Computes the arithmetic sum of the source operands
        /// </summary>
        /// <param name="a">The first operand</param>
        /// <param name="b">The second operand</param>
        [MethodImpl(Inline), Add]
        public static float add(float a, float b)
            => a + b;

        /// <summary>
        /// Computes the arithmetic sum of the source operands
        /// </summary>
        /// <param name="a">The first operand</param>
        /// <param name="b">The second operand</param>
        [MethodImpl(Inline), Add]
        public static double add(double a, double b)
            => a + b;
    }
}