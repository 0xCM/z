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
    using static core;

    partial struct cpu
    {
        /// <summary>
        /// Promotes the offset scalar to a vector and applies the register-based right shift operator
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The offset amount</param>
        [MethodImpl(Inline), Op]
        public static Vector128<sbyte> vsrlr(Vector128<sbyte> src, sbyte count)
            => vsrl(src, vscalar(w128,count));

        /// <summary>
        /// Promotes the offset scalar to a vector and applies the register-based right shift operator
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The offset amount</param>
        [MethodImpl(Inline), Op]
        public static Vector128<byte> vsrlr(Vector128<byte> src, byte count)
            => vsrl(src, vscalar(w128,count));

        /// <summary>
        /// Promotes the offset scalar to a vector and applies the register-based right shift operator
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The offset amount</param>
        [MethodImpl(Inline), Op]
        public static Vector128<short> vsrlr(Vector128<short> src, short count)
            => vsrl(src, vscalar(w128,count));

        /// <summary>
        /// Promotes the offset scalar to a vector and applies the register-based right shift operator
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The offset amount</param>
        [MethodImpl(Inline), Op]
        public static Vector128<ushort> vsrlr(Vector128<ushort> src, ushort count)
            => vsrl(src, vscalar(w128,count));

        /// <summary>
        /// Promotes the offset scalar to a vector and applies the register-based right shift operator
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The offset amount</param>
        [MethodImpl(Inline), Op]
        public static Vector128<int> vsrlr(Vector128<int> src, int count)
            => vsrl(src, vscalar(w128,count));

        /// <summary>
        /// Promotes the offset scalar to a vector and applies the register-based right shift operator
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The offset amount</param>
        [MethodImpl(Inline), Op]
        public static Vector128<uint> vsrlr(Vector128<uint> src, uint count)
            => vsrl(src, vscalar(w128,count));

        /// <summary>
        /// Promotes the offset scalar to a vector and applies the register-based right shift operator
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The offset amount</param>
        [MethodImpl(Inline), Op]
        public static Vector128<long> vsrlr(Vector128<long> src, long count)
            => vsrl(src, vscalar(w128,count));

        /// <summary>
        /// Promotes the offset scalar to a vector and applies the register-based right shift operator
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The offset amount</param>
        [MethodImpl(Inline), Op]
        public static Vector128<ulong> vsrlr(Vector128<ulong> src, ulong count)
            => vsrl(src, vscalar(w128,count));

        /// <summary>
        /// Promotes the offset scalar to a vector and applies the register-based right shift operator
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The offset amount</param>
        [MethodImpl(Inline), Op]
        public static Vector256<sbyte> vsrlr(Vector256<sbyte> src, sbyte count)
            => vsrl(src, vscalar(w128,count));

        /// <summary>
        /// Promotes the offset scalar to a vector and applies the register-based right shift operator
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The offset amount</param>
        [MethodImpl(Inline), Op]
        public static Vector256<byte> vsrlr(Vector256<byte> src, byte count)
            => vsrl(src, vscalar(w128,count));

        /// <summary>
        /// Promotes the offset scalar to a vector and applies the register-based right shift operator
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The offset amount</param>
        [MethodImpl(Inline), Op]
        public static Vector256<short> vsrlr(Vector256<short> src, short count)
            => vsrl(src, vscalar(w128,count));

        /// <summary>
        /// Promotes the offset scalar to a vector and applies the register-based right shift operator
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The offset amount</param>
        [MethodImpl(Inline), Op]
        public static Vector256<ushort> vsrlr(Vector256<ushort> src, ushort count)
            => vsrl(src, vscalar(w128,count));

        /// <summary>
        /// Promotes the offset scalar to a vector and applies the register-based right shift operator
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The offset amount</param>
        [MethodImpl(Inline), Op]
        public static Vector256<int> vsrlr(Vector256<int> src, int count)
            => vsrl(src, vscalar(w128,count));

        /// <summary>
        /// Promotes the offset scalar to a vector and applies the register-based right shift operator
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The offset amount</param>
        [MethodImpl(Inline), Op]
        public static Vector256<uint> vsrlr(Vector256<uint> src, uint count)
            => vsrl(src, vscalar(w128,count));

        /// <summary>
        /// Promotes the offset scalar to a vector and applies the register-based right shift operator
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The offset amount</param>
        [MethodImpl(Inline), Op]
        public static Vector256<long> vsrlr(Vector256<long> src, long count)
            => vsrl(src, vscalar(w128,count));

        /// <summary>
        /// Promotes the offset scalar to a vector and applies the register-based right shift operator
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The offset amount</param>
        [MethodImpl(Inline), Op]
        public static Vector256<ulong> vsrlr(Vector256<ulong> src, ulong count)
            => vsrl(src, vscalar(w128,count));
    }
}