//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Intrinsics;

    using static Root;

    partial struct cpu
    {
        /// <summary>
        /// Computes x^(x >> count)
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="count">The amount by which to count each component</param>
        [MethodImpl(Inline), XorSr]
        public static Vector128<byte> vxorsr(Vector128<byte> x, [Imm] byte count)
            => vxor(x, vsrl(x,count));

        /// <summary>
        /// Computes x^(x >> count)
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="count">The amount by which to count each component</param>
        [MethodImpl(Inline), XorSr]
        public static Vector128<ushort> vxorsr(Vector128<ushort> x, [Imm] byte count)
            => vxor(x, vsrl(x,count));

        /// <summary>
        /// Computes x^(x >> count)
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="count">The amount by which to count each component</param>
        [MethodImpl(Inline), XorSr]
        public static Vector128<uint> vxorsr(Vector128<uint> x, [Imm] byte count)
            => vxor(x, vsrl(x,count));

        /// <summary>
        /// Computes x^(x >> count)
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="count">The amount by which to count each component</param>
        [MethodImpl(Inline), XorSr]
        public static Vector128<ulong> vxorsr(Vector128<ulong> x, [Imm] byte count)
            => vxor(x, vsrl(x,count));

        /// <summary>
        /// Computes x^(x >> count)
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="count">The amount by which to count each component</param>
        [MethodImpl(Inline), XorSr]
        public static Vector256<byte> vxorsr(Vector256<byte> x, [Imm] byte count)
            => vxor(x, vsrl(x,count));

        /// <summary>
        /// Computes x^(x >> count)
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="count">The amount by which to count each component</param>
        [MethodImpl(Inline), XorSr]
        public static Vector256<ushort> vxorsr(Vector256<ushort> x, [Imm] byte count)
            => vxor(x, vsrl(x,count));

        /// <summary>
        /// Computes x^(x >> count)
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="count">The amount by which to count each component</param>
        [MethodImpl(Inline), XorSr]
        public static Vector256<uint> vxorsr(Vector256<uint> x, [Imm] byte count)
            => vxor(x, vsrl(x,count));

        /// <summary>
        /// Computes x^(x >> count)
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="count">The amount by which to count each component</param>
        [MethodImpl(Inline), XorSr]
        public static Vector256<ulong> vxorsr(Vector256<ulong> x, [Imm] byte count)
            => vxor(x, vsrl(x,count));

        /// <summary>
        /// Computes x^(x >> counts)
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="count">Specifies the count count for each corresponding component</param>
        [MethodImpl(Inline), XorSr]
        public static Vector128<uint> vxorsrv(Vector128<uint> x, Vector128<uint> counts)
            => vxor(x, vsrlv(x,counts));

        /// <summary>
        /// Computes x^(x >> counts)
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="counts">Specifies the count count for each corresponding component</param>
        [MethodImpl(Inline), XorSr]
        public static Vector128<ulong> vxorsrv(Vector128<ulong> x, Vector128<ulong> counts)
            => vxor(x, vsrlv(x, counts));

        /// <summary>
        /// Computes x^(x >> counts)
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="counts">Specifies the count count for each corresponding component</param>
        [MethodImpl(Inline), XorSr]
        public static Vector256<uint> vxorsrv(Vector256<uint> x, Vector256<uint> counts)
            => vxor(x, vsrlv(x, counts));

        /// <summary>
        /// Computes x^(x >> counts)
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="counts">Specifies the count count for each corresponding component</param>
        [MethodImpl(Inline), XorSr]
        public static Vector256<ulong> vxorsrv(Vector256<ulong> x, Vector256<ulong> counts)
            => vxor(x, vsrlv(x, counts));
    }
}