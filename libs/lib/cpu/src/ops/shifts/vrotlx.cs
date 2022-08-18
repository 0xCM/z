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
        /// Rotates the full 128 bits of a vector leftward a bit-level resolution
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The number of bits to rotate</param>
        [MethodImpl(Inline), Op]
        public static Vector128<ulong> vrotlx(Vector128<ulong> src, [Imm] byte count)
            => vor(vsllx(src, count), vsrlx(src, (byte)(128 - count)));

        /// <summary>
        /// Rotates each 128 lane leftward a bit-level resolution
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The number of bits to rotate</param>
        [MethodImpl(Inline), Op]
        public static Vector256<ulong> vrotlx(Vector256<ulong> src, [Imm] byte count)
            => vor(vsllx(src, count), vsrlx(src, (byte)(128 - count)));

        /// <summary>
        /// Rotates the full 128-bit vector content leftward by 8 bits
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The count selector</param>
        [MethodImpl(Inline), Rotrx]
        public static Vector128<byte> vrotlx(Vector128<byte> src, N8 count)
            => vshuf16x8(src, vrotl(w128, count));

        /// <summary>
        /// Rotates the full 128-bit vector content leftward by 16 bits
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The count selector</param>
        [MethodImpl(Inline), Rotrx]
        public static Vector128<byte> vrotlx(Vector128<byte> src, N16 count)
            => vshuf16x8(src, vrotl(w128, count));

        /// <summary>
        /// Rotates the full 128-bit vector content leftward by 24 bits
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The count selector</param>
        [MethodImpl(Inline), Rotrx]
        public static Vector128<byte> vrotlx(Vector128<byte> src, N24 count)
            => vshuf16x8(src, vrotl(w128, count));

        /// <summary>
        /// Rotates the full 128-bit vector content leftward by 32 bits
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The count selector</param>
        [MethodImpl(Inline), Rotrx]
        public static Vector128<byte> vrotlx(Vector128<byte> src, N32 count)
            => vshuf16x8(src, vrotl(w128, count));
    }
}