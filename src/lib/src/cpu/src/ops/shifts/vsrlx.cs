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
        /// Shifts the entire 128-bit vector rightwards at bit-level resolution
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The number of bits to shift rightward</param>
        /// <remarks>Taken from http://programming.sirrida.de</remarks>
        [MethodImpl(Inline), Srlx]
        public static Vector128<ulong> vsrlx(Vector128<ulong> src, [Imm] byte count)
        {
            if(count >= 64)
                return vsrl(vbsrl(src, 8), (byte)(count - 64));
            else
                return vor(vsrl(src, count), vsll(vbsrl(src, 8), (byte)(64 - count)));
        }

        [MethodImpl(Inline), Srlx]
        public static Vector128<byte> vsrlx(Vector128<byte> src, [Imm] byte count)
            => v8u(vsrlx(v64u(src), count));

        [MethodImpl(Inline), Srlx]
        public static Vector128<ushort> vsrlx(Vector128<ushort> src, [Imm] byte count)
            => v16u(vsrlx(v64u(src), count));

        [MethodImpl(Inline), Srlx]
        public static Vector128<uint> vsrlx(Vector128<uint> src, [Imm] byte count)
            => v32u(vsrlx(v64u(src), count));

        /// <summary>
        /// Shifts each 128-bit lane rightwards at bit-level resolution
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The number of bits to shift rightward</param>
        /// <remarks>Taken from http://programming.sirrida.de</remarks>
        [MethodImpl(Inline), Srlx]
        public static Vector256<ulong> vsrlx(Vector256<ulong> src, [Imm] byte count)
        {
            if(count >= 64)
                return vsrl(vbsrl(src, 8), (byte)(count - 64));
            else
                return vor(vsrl(src, count), vsll(vbsrl(src, 8), (byte)(64 - count)));
        }

        [MethodImpl(Inline), Srlx]
        public static Vector256<byte> vsrlx(Vector256<byte> src, [Imm] byte count)
            => v8u(vsrlx(v64u(src), count));

        [MethodImpl(Inline), Srlx]
        public static Vector256<ushort> vsrlx(Vector256<ushort> src, [Imm] byte count)
            => v16u(vsrlx(v64u(src), count));

        [MethodImpl(Inline), Srlx]
        public static Vector256<uint> vsrlx(Vector256<uint> src, [Imm] byte count)
            => v32u(vsrlx(v64u(src), count));
    }
}