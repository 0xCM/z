//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class vcpu 
    {
        // /// <summary>
        // /// Promotes the offset scalar to a vector and applies the register-based right shift operator
        // /// </summary>
        // /// <param name="src">The source vector</param>
        // /// <param name="count">The offset amount</param>
        // [MethodImpl(Inline), Op]
        // public static Vector128<sbyte> vsllr(Vector128<sbyte> src, sbyte count)
        //     => vsll(src, vscalar(w128,count));

        // /// <summary>
        // /// Promotes the offset scalar to a vector and applies the register-based right shift operator
        // /// </summary>
        // /// <param name="src">The source vector</param>
        // /// <param name="count">The offset amount</param>
        // [MethodImpl(Inline), Op]
        // public static Vector128<byte> vsllr(Vector128<byte> src, byte count)
        //     => vsll(src, vscalar(w128,count));

        /// <summary>
        /// Promotes the offset scalar to a vector and applies the register-based right shift operator
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The offset amount</param>
        [MethodImpl(Inline), Op]
        public static Vector128<short> vsllr(Vector128<short> src, short count)
            => vsll(src, vscalar(w128,count));

        /// <summary>
        /// Promotes the offset scalar to a vector and applies the register-based right shift operator
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The offset amount</param>
        [MethodImpl(Inline), Op]
        public static Vector128<ushort> vsllr(Vector128<ushort> src, ushort count)
            => vsll(src, vscalar(w128,count));

        /// <summary>
        /// Promotes the offset scalar to a vector and applies the register-based right shift operator
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The offset amount</param>
        [MethodImpl(Inline), Op]
        public static Vector128<int> vsllr(Vector128<int> src, int count)
            => vsll(src, vscalar(w128,count));

        /// <summary>
        /// Promotes the offset scalar to a vector and applies the register-based right shift operator
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The offset amount</param>
        [MethodImpl(Inline), Op]
        public static Vector128<uint> vsllr(Vector128<uint> src, uint count)
            => vsll(src, vscalar(w128,count));

        /// <summary>
        /// Promotes the offset scalar to a vector and applies the register-based right shift operator
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The offset amount</param>
        [MethodImpl(Inline), Op]
        public static Vector128<long> vsllr(Vector128<long> src, long count)
            => vsll(src, vscalar(w128,count));

        /// <summary>
        /// Promotes the offset scalar to a vector and applies the register-based right shift operator
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The offset amount</param>
        [MethodImpl(Inline), Op]
        public static Vector128<ulong> vsllr(Vector128<ulong> src, ulong count)
            => vsll(src, vscalar(w128, count));

        // /// <summary>
        // /// Promotes the offset scalar to a vector and applies the register-based right shift operator
        // /// </summary>
        // /// <param name="src">The source vector</param>
        // /// <param name="count">The offset amount</param>
        // [MethodImpl(Inline), Op]
        // public static Vector256<sbyte> vsllr(Vector256<sbyte> src, sbyte count)
        //     => vsll(src, vscalar(w128, count));

        // /// <summary>
        // /// Promotes the offset scalar to a vector and applies the register-based right shift operator
        // /// </summary>
        // /// <param name="src">The source vector</param>
        // /// <param name="count">The offset amount</param>
        // [MethodImpl(Inline), Op]
        // public static Vector256<byte> vsllr(Vector256<byte> src, byte count)
        //     => vsll(src, vscalar(w128, count));

        /// <summary>
        /// Promotes the offset scalar to a vector and applies the register-based right shift operator
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The offset amount</param>
        [MethodImpl(Inline), Op]
        public static Vector256<short> vsllr(Vector256<short> src, short count)
            => vsll(src, vscalar(w128, count));

        /// <summary>
        /// Promotes the offset scalar to a vector and applies the register-based right shift operator
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The offset amount</param>
        [MethodImpl(Inline), Op]
        public static Vector256<ushort> vsllr(Vector256<ushort> src, ushort count)
            => vsll(src, vscalar(w128, count));

        /// <summary>
        /// Promotes the offset scalar to a vector and applies the register-based right shift operator
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The offset amount</param>
        [MethodImpl(Inline), Op]
        public static Vector256<int> vsllr(Vector256<int> src, int count)
            => vsll(src, vscalar(w128, count));

        /// <summary>
        /// Promotes the offset scalar to a vector and applies the register-based right shift operator
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The offset amount</param>
        [MethodImpl(Inline), Op]
        public static Vector256<uint> vsllr(Vector256<uint> src, uint count)
            => vsll(src, vscalar(w128, count));

        /// <summary>
        /// Promotes the offset scalar to a vector and applies the register-based right shift operator
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The offset amount</param>
        [MethodImpl(Inline), Op]
        public static Vector256<long> vsllr(Vector256<long> src, long count)
            => vsll(src, vscalar(w128, count));

        /// <summary>
        /// Promotes the offset scalar to a vector and applies the register-based right shift operator
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The offset amount</param>
        [MethodImpl(Inline), Op]
        public static Vector256<ulong> vsllr(Vector256<ulong> src, ulong count)
            => vsll(src, vscalar(w128, count));
    }
}