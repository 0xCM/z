//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class math
    {
        /// <summary>
        /// Defines a binary operator that returns 1 if the operands are equal 0 otherwise
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [MethodImpl(Inline), EqB]
        public static sbyte eqb(sbyte a, sbyte b)
            => i8(eq(a,b));

        /// <summary>
        /// Defines a binary operator that returns 1 if the operands are equal 0 otherwise
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [MethodImpl(Inline), EqB]
        public static byte eqb(byte a, byte b)
            => u8(eq(a,b));

        /// <summary>
        /// Defines a binary operator that returns 1 if the operands are equal 0 otherwise
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [MethodImpl(Inline), EqB]
        public static short eqb(short a, short b)
            => i16(eq(a,b));

        /// <summary>
        /// Defines a binary operator that returns 1 if the operands are equal 0 otherwise
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [MethodImpl(Inline), EqB]
        public static ushort eqb(ushort a, ushort b)
            => u16(eq(a,b));

        /// <summary>
        /// Defines a binary operator that returns 1 if the operands are equal 0 otherwise
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [MethodImpl(Inline), EqB]
        public static int eqb(int a, int b)
            => i32(eq(a,b));

        /// <summary>
        /// Defines a binary operator that returns 1 if the operands are equal 0 otherwise
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [MethodImpl(Inline), EqB]
        public static uint eqb(uint a, uint b)
            => u32(eq(a,b));

        /// <summary>
        /// Defines a binary operator that returns 1 if the operands are equal 0 otherwise
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [MethodImpl(Inline), EqB]
        public static long eqb(long a, long b)
            => i64(eq(a,b));

        /// <summary>
        /// Defines a binary operator that returns 1 if the operands are equal 0 otherwise
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [MethodImpl(Inline), EqB]
        public static ulong eqb(ulong a, ulong b)
            => u64(eq(a,b));
    }
}