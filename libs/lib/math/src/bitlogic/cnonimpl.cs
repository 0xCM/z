//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static System.Runtime.Intrinsics.X86.Bmi1;
    using static System.Runtime.Intrinsics.X86.Bmi1.X64;

    partial class math
    {
        /// <summary>
        /// Computes the converse nonimplication c := a & ~b for operands a and b
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [MethodImpl(Inline), CNonImpl]
        public static byte cnonimpl(byte a, byte b)
            => (byte)AndNot((uint)b,(uint)a);

        /// <summary>
        /// Computes the converse nonimplication c := a & ~b for operands a and b
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [MethodImpl(Inline), CNonImpl]
        public static short cnonimpl(short a, short b)
            => (short)AndNot((uint)b,(uint)a);

        /// <summary>
        /// Computes the converse nonimplication c := a & ~b for operands a and b
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [MethodImpl(Inline), CNonImpl]
        public static ushort cnonimpl(ushort a, ushort b)
            => (ushort)AndNot((uint)b,(uint)a);

        /// <summary>
        /// Computes the converse nonimplication c := a & ~b for operands a and b
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [MethodImpl(Inline), CNonImpl]
        public static int cnonimpl(int a, int b)
            => (int)AndNot((uint)b,(uint)a);

        /// <summary>
        /// Computes the converse nonimplication c := a & ~b for operands a and b
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [MethodImpl(Inline), CNonImpl]
        public static uint cnonimpl(uint a, uint b)
            => AndNot(b,a);

        /// <summary>
        /// Computes the converse nonimplication c := a & ~b for operands a and b
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [MethodImpl(Inline), CNonImpl]
        public static long cnonimpl(long a, long b)
            => (long)AndNot((ulong)b,(ulong)a);

        /// <summary>
        /// Computes the converse nonimplication c := a & ~b for operands a and b
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [MethodImpl(Inline), CNonImpl]
        public static ulong cnonimpl(ulong a, ulong b)
            => AndNot(b,a);

    }
}