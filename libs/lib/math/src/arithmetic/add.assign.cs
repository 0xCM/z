//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class math
    {
        /// <summary>
        /// Computes the compound assignment a += b
        /// </summary>
        /// <param name="a">The first operand </param>
        /// <param name="b">The second operand</param>
        [MethodImpl(Inline), AddAssign]
        public static sbyte add(ref sbyte a, sbyte b)
            => a = add(a, b);

        /// <summary>
        /// Computes the compound assignment a += b
        /// </summary>
        /// <param name="a">The first operand </param>
        /// <param name="b">The second operand</param>
        [MethodImpl(Inline), AddAssign]
        public static byte add(ref byte a, byte b)
            => a = add(a, b);

        /// <summary>
        /// Computes the compound assignment a += b
        /// </summary>
        /// <param name="a">The first operand </param>
        /// <param name="b">The second operand</param>
        [MethodImpl(Inline), AddAssign]
        public static short add(ref short a, short b)
            => a = add(a, b);

        /// <summary>
        /// Computes the compound assignment a += b
        /// </summary>
        /// <param name="a">The first operand </param>
        /// <param name="b">The second operand</param>
        [MethodImpl(Inline), AddAssign]
        public static ushort add(ref ushort a, ushort b)
            => a = add(a, b);

        /// <summary>
        /// Computes the compound assignment a += b
        /// </summary>
        /// <param name="a">The first operand </param>
        /// <param name="b">The second operand</param>
        [MethodImpl(Inline), AddAssign]
        public static int add(ref int a, int b)
            => a = add(a, b);

        /// <summary>
        /// Computes the compound assignment a += b
        /// </summary>
        /// <param name="a">The first operand </param>
        /// <param name="b">The second operand</param>
        [MethodImpl(Inline), AddAssign]
        public static uint add(ref uint a, uint b)
            => a = add(a, b);

        /// <summary>
        /// Computes the compound assignment a += b
        /// </summary>
        /// <param name="a">The first operand </param>
        /// <param name="b">The second operand</param>
        [MethodImpl(Inline), AddAssign]
        public static long add(ref long a, long b)
            => a = add(a, b);

        /// <summary>
        /// Computes the compound assignment a += b
        /// </summary>
        /// <param name="a">The first operand </param>
        /// <param name="b">The second operand</param>
        [MethodImpl(Inline), AddAssign]
        public static ulong add(ref ulong a, ulong b)
            => a = add(a, b);

        /// <summary>
        /// Computes the compound assignment a += b
        /// </summary>
        /// <param name="a">The first operand </param>
        /// <param name="b">The second operand</param>
        [MethodImpl(Inline), AddAssign]
        public static float add(ref float a, float b)
            => a = add(a, b);

        /// <summary>
        /// Computes the compound assignment a += b
        /// </summary>
        /// <param name="a">The first operand </param>
        /// <param name="b">The second operand</param>
        [MethodImpl(Inline), AddAssign]
        public static double add(ref double a, double b)
            => a = add(a, b);
    }
}