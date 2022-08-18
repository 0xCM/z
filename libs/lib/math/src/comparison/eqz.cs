//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static LimitValues;

    partial class math
    {
        /// <summary>
        /// Defines the operator eqz(a,b) := a == b ? Min : Zero
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [MethodImpl(Inline), Eqz]
        public static sbyte eqz(sbyte a, sbyte b)
            => (sbyte)eqz((uint)a, (uint)b);

        /// <summary>
        /// Defines the operator eqz(a,b) := a == b ? Min : Zero
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [MethodImpl(Inline), Eqz]
        public static byte eqz(byte a, byte b)
            => (byte)eqz((uint)a, (uint)b);

        /// <summary>
        /// Defines the operator eqz(a,b) := a == b ? Min : Zero
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [MethodImpl(Inline), Eqz]
        public static short eqz(short a, short b)
            => (sbyte)eqz((uint)a, (uint)b);

        /// <summary>
        /// Defines the operator eqz(a,b) := a == b ? Min : Zero
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [MethodImpl(Inline), Eqz]
        public static ushort eqz(ushort a, ushort b)
            => (ushort)eqz((uint)a, (uint)b);

        /// <summary>
        /// Defines the operator eqz(a,b) := a == b ? Min : Zero
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [MethodImpl(Inline), Eqz]
        public static int eqz(int a, int b)
            => (int)eqz((uint)a, (uint)b);

        /// <summary>
        /// Defines the operator eqz(a,b) := a == b ? Min : Zero
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [MethodImpl(Inline), Eqz]
        public static uint eqz(uint a, uint b)
            => mul(eqb(a,b), Max32u);

        /// <summary>
        /// Defines the operator eqz(a,b) := a == b ? Min : Zero
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [MethodImpl(Inline), Eqz]
        public static long eqz(long a, long b)
            => (long)eqz((ulong)a, (ulong)b);

        /// <summary>
        /// Defines the operator eqz(a,b) := a == b ? Min : Zero
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [MethodImpl(Inline), Eqz]
        public static ulong eqz(ulong a, ulong b)
            => mul(eqb(a,b), Max64u);
    }
}