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
        /// Shifts the entire 128-bit vector leftwards at bit-level resolution
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The number of bits the shift leftward</param>
        /// <remarks>Taken from http://programming.sirrida.de</remarks>
        [MethodImpl(Inline), Sllx]
        public static Vector128<ulong> vsllx(Vector128<ulong> src, [Imm] byte count)
        {
            if(count >= 64)
                return vsll(vbsll(src, 8), (byte)(count - 64));
            else
                return vor(vsll(src, count), vsrl(vbsll(src, 8), (byte)(64 - count)));
        }

        [MethodImpl(Inline), Sllx]
        public static Vector128<byte> vsllx(Vector128<byte> src, [Imm] byte count)
            => v8u(vsllx(v64u(src), count));

        [MethodImpl(Inline), Sllx]
        public static Vector128<ushort> vsllx(Vector128<ushort> src, [Imm] byte count)
            => v16u(vsllx(v64u(src), count));

        [MethodImpl(Inline), Sllx]
        public static Vector128<uint> vsllx(Vector128<uint> src, [Imm] byte count)
            => v32u(vsllx(v64u(src), count));

        /// <summary>
        /// Shifts each 128-bit lane leftwards at bit-level resolution
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The number of bits the shift leftward</param>
        /// <remarks>Taken from http://programming.sirrida.de</remarks>
        [MethodImpl(Inline), Sllx]
        public static Vector256<ulong> vsllx(Vector256<ulong> src, [Imm] byte count)
        {
            if(count >= 64)
                return vsll(vbsll(src, 8), (byte)(count - 64));
            else
                return vor(vsll(src, count), vsrl(vbsll(src, 8), (byte)(64 - count)));
        }

        [MethodImpl(Inline), Sllx]
        public static Vector256<byte> vsllx(Vector256<byte> src, [Imm] byte count)
            => v8u(vsllx(v64u(src), count));

        [MethodImpl(Inline), Sllx]
        public static Vector256<ushort> vsllx(Vector256<ushort> src, [Imm] byte count)
            => v16u(vsllx(v64u(src), count));

        [MethodImpl(Inline), Sllx]
        public static Vector256<uint> vsllx(Vector256<uint> src, [Imm] byte count)
            => v32u(vsllx(v64u(src), count));
    }
}