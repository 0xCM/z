//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class vcpu
    {
        /// <summary>
        /// Rotates each component the source vector rightwards by a constant count
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The magnitude of the rotation</param>
        [MethodImpl(Inline), Rotr]
        public static Vector128<byte> vrotr(Vector128<byte> src, [Imm] byte count)
            => vor(vsrl(src, count), vsll(src, (byte)(8 - count)));

        /// <summary>
        /// Rotates each component the source vector rightwards by a constant count
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The magnitude of the rotation</param>
        [MethodImpl(Inline), Rotr]
        public static Vector128<ushort> vrotr(Vector128<ushort> src, [Imm] byte count)
            => vor(vsrl(src, count), vsll(src, (byte)(16 - count)));

        /// <summary>
        /// Rotates each component the source vector rightwards by a constant count
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The magnitude of the rotation</param>
        [MethodImpl(Inline), Rotr]
        public static Vector128<uint> vrotr(Vector128<uint> src, [Imm] byte count)
            => vor(vsrl(src, count), vsll(src, (byte)(32 - count)));

        /// <summary>
        /// Rotates each component the source vector rightwards by a constant count
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The magnitude of the rotation</param>
        [MethodImpl(Inline), Rotr]
        public static Vector128<ulong> vrotr(Vector128<ulong> src, [Imm] byte count)
            => vor(vsrl(src, count), vsll(src, (byte)(64 - count)));

        /// <summary>
        /// Rotates each component the source vector rightwards by a specified count
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The magnitude of the rotation</param>
        [MethodImpl(Inline), Rotr]
        public static Vector256<byte> vrotr(Vector256<byte> src, [Imm] byte count)
            => vor(vsrl(src, count), vsll(src, (byte)(8 - count)));

        /// <summary>
        /// Rotates each component the source vector rightwards by a specified count
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The magnitude of the rotation</param>
        [MethodImpl(Inline), Rotr]
        public static Vector256<ushort> vrotr(Vector256<ushort> src, [Imm] byte count)
            => vor(vsrl(src, count), vsll(src, (byte)(16 - count)));

        /// <summary>
        /// Rotates each component the source vector rightwards by a constant count
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The magnitude of the rotation</param>
        [MethodImpl(Inline), Rotr]
        public static Vector256<uint> vrotr(Vector256<uint> src, [Imm] byte count)
            => vor(vsrl(src, count), vsll(src, (byte)(32 - count)));

        /// <summary>
        /// Rotates each component the source vector rightwards by a constant count
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The magnitude of the rotation</param>
        [MethodImpl(Inline), Rotr]
        public static Vector256<ulong> vrotr(Vector256<ulong> src, [Imm] byte count)
            => vor(vsrl(src, count), vsll(src, (byte)(64 - count)));
    }
}