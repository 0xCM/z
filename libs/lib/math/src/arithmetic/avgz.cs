//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class math
    {
        /// <summary>
        /// Computes the average of the operands, rounding toward zero
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        /// <remarks>Algorithm adapted from Arndt, Matters Computational</remarks>
        [MethodImpl(Inline), Avgz]
        public static byte avgz(byte a, byte b)
            => (byte)((a & b) + ((a ^ b) >> 1));

        /// <summary>
        /// Takes the average of the operands, rounding toward zero
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        /// <remarks>Algorithm adapted from Arndt, Matters Computational</remarks>
        [MethodImpl(Inline), Avgz]
        public static ushort avgz(ushort a, ushort b)
            => (ushort)((a & b) + ((a ^ b) >> 1));

        /// <summary>
        /// Takes the average of the operands, rounding toward zero
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        /// <remarks>Algorithm adapted from Arndt, Matters Computational</remarks>
        [MethodImpl(Inline), Avgz]
        public static uint avgz(uint a, uint b)
            => (a & b) + ((a ^ b) >> 1);

        /// <summary>
        /// Takes the average of the operands, rounding toward zero
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        /// <remarks>Algorithm adapted from Arndt, Matters Computational</remarks>
        [MethodImpl(Inline), Avgz]
        public static ulong avgz(ulong a, ulong b)
            => (a & b) + ((a ^ b) >> 1);
    }
}