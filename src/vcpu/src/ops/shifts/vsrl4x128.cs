//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class vcpu 
{
    /// <summary>
    /// __m512i _mm512_bsrli_epi128 (__m512i a, const int imm8)
    /// VPSRLDQ zmm1, zmm2/m128, imm8
    /// Shifts each 128-bit lane of the source vector rightwards with byte-level resolution
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <param name="count">The number of bytes to shift</param>
    [MethodImpl(Inline), Op]
    public static Vector512<sbyte> vsrl4x128(Vector512<sbyte> x, [Imm] byte count)
        => ShiftRightLogical128BitLane(x, (byte)count);

    /// <summary>
    /// __m512i _mm512_bsrli_epi128 (__m512i a, const int imm8)
    /// VPSRLDQ zmm1, zmm2/m128, imm8
    /// Shifts each 128-bit lane of the source vector rightwards with byte-level resolution
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <param name="count">The number of bytes to shift</param>
    [MethodImpl(Inline), Op]
    public static Vector512<byte> vsrl4x128(Vector512<byte> x, [Imm] byte count)
        => ShiftRightLogical128BitLane(x, (byte)count);

    /// <summary>
    /// __m512i _mm512_bsrli_epi128 (__m512i a, const int imm8)
    /// VPSRLDQ zmm1, zmm2/m128, imm8
    /// Shifts each 128-bit lane of the source vector rightwards with byte-level resolution
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <param name="count">The number of bytes to shift</param>
    [MethodImpl(Inline), Op]
    public static Vector512<short> vsrl4x128(Vector512<short> x, [Imm] byte count)
        => v16i(ShiftRightLogical128BitLane(v8u(x), (byte)count));

    /// <summary>
    /// __m512i _mm512_bsrli_epi128 (__m512i a, const int imm8)
    /// VPSRLDQ zmm1, zmm2/m128, imm8
    /// Shifts each 128-bit lane of the source vector rightwards with byte-level resolution
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <param name="count">The number of bytes to shift</param>
    [MethodImpl(Inline), Op]
    public static Vector512<ushort> vsrl4x128(Vector512<ushort> x, [Imm] byte count)
        => v16u(ShiftRightLogical128BitLane(v8u(x), (byte)count));

    /// <summary>
    /// __m512i _mm512_bsrli_epi128 (__m512i a, const int imm8)
    /// VPSRLDQ zmm1, zmm2/m128, imm8
    /// Shifts each 128-bit lane of the source vector rightwards with byte-level resolution
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <param name="count">The number of bytes to shift</param>
    [MethodImpl(Inline), Op]
    public static Vector512<int> vsrl4x128(Vector512<int> x, [Imm] byte count)
        => v32i(ShiftRightLogical128BitLane(v8u(x), (byte)count));

    /// <summary>
    /// __m512i _mm512_bsrli_epi128 (__m512i a, const int imm8)
    /// VPSRLDQ zmm1, zmm2/m128, imm8
    /// Shifts each 128-bit lane of the source vector rightwards with byte-level resolution
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <param name="count">The number of bytes to shift</param>
    [MethodImpl(Inline), Op]
    public static Vector512<uint> vsrl4x128(Vector512<uint> x, [Imm] byte count)
        => v32u(ShiftRightLogical128BitLane(v8u(x), (byte)count));

    /// <summary>
    /// __m512i _mm512_bsrli_epi128 (__m512i a, const int imm8)
    /// VPSRLDQ zmm1, zmm2/m128, imm8
    /// Shifts each 128-bit lane of the source vector rightwards with byte-level resolution
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <param name="count">The number of bytes to shift</param>
    [MethodImpl(Inline), Op]
    public static Vector512<long> vsrl4x128(Vector512<long> x, [Imm] byte count)
        => v64i(ShiftRightLogical128BitLane(v8u(x), (byte)count));

    /// <summary>
    /// __m512i _mm512_bsrli_epi128 (__m512i a, const int imm8)
    /// VPSRLDQ zmm1, zmm2/m128, imm8
    /// Shifts each 128-bit lane of the source vector rightwards with byte-level resolution
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <param name="count">The number of bytes to shift</param>
    [MethodImpl(Inline), Op]
    public static Vector512<ulong> vsrl4x128(Vector512<ulong> x, [Imm] byte count)
        => v64u(ShiftRightLogical128BitLane(v8u(x), (byte)count));
}