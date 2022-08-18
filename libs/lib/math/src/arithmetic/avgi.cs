//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class math
    {
        /// <summary>
        /// Takes the average of the operands, rounding toward infinity
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        /// <remarks>Algorithm adapted from Arndt, Matters Computational</remarks>
        [MethodImpl(Inline), Avgi]
        public static byte avgi(byte a, byte b)
            => (byte)((a | b) - ((a ^ b) >> 1));

        /// <summary>
        /// Takes the average of the operands, rounding toward infinity
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        /// <remarks>Algorithm adapted from Arndt, Matters Computational</remarks>
        [MethodImpl(Inline), Avgi]
        public static ushort avgi(ushort a, ushort b)
            => (ushort)((a | b) - ((a ^ b) >> 1));

        /// <summary>
        /// Takes the average of the operands, rounding toward infinity
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        /// <remarks>Algorithm adapted from Arndt, Matters Computational</remarks>
        [MethodImpl(Inline), Avgi]
        public static uint avgi(uint a, uint b)
            => (a | b) - ((a ^ b) >> 1);

        /// <summary>
        /// Takes the average of the operands, rounding toward infinity
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        /// <remarks>Algorithm adapted from Arndt, Matters Computational</remarks>
        [MethodImpl(Inline), Avgi]
        public static ulong avgi(ulong a, ulong b)
            => (a | b) - ((a ^ b) >> 1);
    }
}