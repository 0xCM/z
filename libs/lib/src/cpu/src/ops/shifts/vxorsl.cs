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
        /// Computes x^(x << count)
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="count">Specifies the count count for each corresponding component</param>
        [MethodImpl(Inline), XorSl]
        public static Vector128<byte> vxorsl(Vector128<byte> x, [Imm] byte count)
            => vxor(x, vsll(x,count));

        /// <summary>
        /// Computes x^(x << count)
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="count">Specifies the count count for each corresponding component</param>
        [MethodImpl(Inline), XorSl]
        public static Vector128<ushort> vxorsl(Vector128<ushort> x, [Imm] byte count)
            => vxor(x, vsll(x,count));

        /// <summary>
        /// Computes x^(x << count)
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="count">Specifies the count count for each corresponding component</param>
        [MethodImpl(Inline), XorSl]
        public static Vector128<uint> vxorsl(Vector128<uint> x, [Imm] byte count)
            => vxor(x, vsll(x,count));

        /// <summary>
        /// Computes x^(x << count)
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="count">Specifies the count count for each corresponding component</param>
        [MethodImpl(Inline), XorSl]
        public static Vector128<ulong> vxorsl(Vector128<ulong> x, [Imm] byte count)
            => vxor(x, vsll(x,count));

        /// <summary>
        /// Computes x^(x << count)
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="count">Specifies the count count for each corresponding component</param>
        [MethodImpl(Inline), XorSl]
        public static Vector256<byte> vxorsl(Vector256<byte> x, [Imm] byte count)
            => vxor(x, vsll(x,count));

        /// <summary>
        /// Computes x^(x << count)
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="count">Specifies the count count for each corresponding component</param>
        [MethodImpl(Inline), XorSl]
        public static Vector256<ushort> vxorsl(Vector256<ushort> x, [Imm] byte count)
            => vxor(x, vsll(x,count));

        /// <summary>
        /// Computes x^(x << count)
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="count">Specifies the count count for each corresponding component</param>
        [MethodImpl(Inline), XorSl]
        public static Vector256<uint> vxorsl(Vector256<uint> x, [Imm] byte count)
            => vxor(x, vsll(x,count));

        /// <summary>
        /// Computes x^(x << count)
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="count">Specifies the count count for each corresponding component</param>
        [MethodImpl(Inline), XorSl]
        public static Vector256<ulong> vxorsl(Vector256<ulong> x, [Imm] byte count)
            => vxor(x, vsll(x,count));

        /// <summary>
        /// Computes x[i]^(x[i] << count[i])
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="counts">Specifies the count count for each corresponding component</param>
        [MethodImpl(Inline), XorSl]
        public static Vector128<uint> vxorslv(Vector128<uint> x, Vector128<uint> counts)
            => vxor(x, vsllv(x,counts));

        /// <summary>
        /// Computes x[i]^(x[i] << count[i])
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="counts">Specifies the count count for each corresponding component</param>
        [MethodImpl(Inline), XorSl]
        public static Vector128<ulong> vxorslv(Vector128<ulong> x, Vector128<ulong> counts)
            => vxor(x, vsllv(x,counts));

        /// <summary>
        /// Computes x[i]^(x[i] << count[i])
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="counts">Specifies the count count for each corresponding component</param>
        [MethodImpl(Inline), XorSl]
        public static Vector256<uint> vxorslv(Vector256<uint> x, Vector256<uint> counts)
            => vxor(x, vsllv(x,counts));

        /// <summary>
        /// Computes x[i]^(x[i] << count[i])
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="counts">Specifies the count count for each corresponding component</param>
        [MethodImpl(Inline), XorSl]
        public static Vector256<ulong> vxorslv(Vector256<ulong> x, Vector256<ulong> counts)
            => vxor(x, vsllv(x,counts));
    }
}