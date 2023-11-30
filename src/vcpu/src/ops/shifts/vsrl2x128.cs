//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class vcpu 
{
    /// <summary>
    /// __m256i _mm256_bsrli_epi128 (__m256i a, const int imm8) VPSRLDQ ymm, ymm, imm8
    /// Shifts the source vector rightwards with byte-level resolution
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <param name="count">The number of bytes to shift</param>
    [MethodImpl(Inline), Op]
    public static Vector256<sbyte> vsrl2x128(Vector256<sbyte> x, [Imm] byte count)
        => ShiftRightLogical128BitLane(x, count);

    /// <summary>
    /// __m256i _mm256_bsrli_epi128 (__m256i a, const int imm8) VPSRLDQ ymm, ymm, imm8
    /// Shifts the source vector rightwards with byte-level resolution
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <param name="count">The number of bytes to shift</param>
    [MethodImpl(Inline), Op]
    public static Vector256<byte> vsrl2x128(Vector256<byte> x, [Imm] byte count)
        => ShiftRightLogical128BitLane(x, (byte)count);

    /// <summary>
    /// __m256i _mm256_bsrli_epi128 (__m256i a, const int imm8) VPSRLDQ ymm, ymm, imm8
    /// Shifts the source vector rightwards with byte-level resolution
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <param name="count">The number of bytes to shift</param>
    [MethodImpl(Inline), Op]
    public static Vector256<short> vsrl2x128(Vector256<short> x, [Imm] byte count)
        => ShiftRightLogical128BitLane(x, (byte)count);

    /// <summary>
    /// __m256i _mm256_bsrli_epi128 (__m256i a, const int imm8) VPSRLDQ ymm, ymm, imm8
    /// Shifts the source vector rightwards with byte-level resolution
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <param name="count">The number of bytes to shift</param>
    [MethodImpl(Inline), Op]
    public static Vector256<ushort> vsrl2x128(Vector256<ushort> x, [Imm] byte count)
        => ShiftRightLogical128BitLane(x, (byte)count);

    /// <summary>
    /// __m256i _mm256_bsrli_epi128 (__m256i a, const int imm8) VPSRLDQ ymm, ymm, imm8
    /// Shifts the source vector rightwards with byte-level resolution
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <param name="count">The number of bytes to shift</param>
    [MethodImpl(Inline), Op]
    public static Vector256<int> vsrl2x128(Vector256<int> x, [Imm] byte count)
        => ShiftRightLogical128BitLane(x, (byte)count);

    /// <summary>
    /// __m256i _mm256_bsrli_epi128 (__m256i a, const int imm8) VPSRLDQ ymm, ymm, imm8
    /// Shifts the source vector rightwards with byte-level resolution
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <param name="count">The number of bytes to shift</param>
    [MethodImpl(Inline), Op]
    public static Vector256<uint> vsrl2x128(Vector256<uint> x, [Imm] byte count)
        => ShiftRightLogical128BitLane(x, (byte)count);

    /// <summary>
    /// __m256i _mm256_bsrli_epi128 (__m256i a, const int imm8) VPSRLDQ ymm, ymm, imm8
    /// Shifts the source vector rightwards with byte-level resolution
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <param name="count">The number of bytes to shift</param>
    [MethodImpl(Inline), Op]
    public static Vector256<long> vsrl2x128(Vector256<long> x, [Imm] byte count)
        => ShiftRightLogical128BitLane(x, (byte)count);

    /// <summary>
    /// __m256i _mm256_bsrli_epi128 (__m256i a, const int imm8) VPSRLDQ ymm, ymm, imm8
    /// Shifts the source vector rightwards with byte-level resolution
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <param name="count">The number of bytes to shift</param>
    [MethodImpl(Inline), Op]
    public static Vector256<ulong> vsrl2x128(Vector256<ulong> x, [Imm] byte count)
        => ShiftRightLogical128BitLane(x, (byte)count);

}