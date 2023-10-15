//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class vcpu
{
    /// <summary>
    /// __m256i _mm256_permute2x128_si256 (__m256i a, __m256i b, const int imm8) VPERM2I128 ymm, ymm, ymm/m256, imm8
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <param name="spec">The permutation spec</param>
    [MethodImpl(Inline), Op]
    public static Vector256<sbyte> vperm2x128(Vector256<sbyte> x, Vector256<sbyte> y, [Imm] Perm2x4 spec)
        => Permute2x128(x, y, (byte)spec);

    /// <summary>
    /// __m256i _mm256_permute2x128_si256 (__m256i a, __m256i b, const int imm8) VPERM2I128 ymm, ymm, ymm/m256, imm8
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <param name="spec">The permutation spec</param>
    [MethodImpl(Inline), Op]
    public static Vector256<byte> vperm2x128(Vector256<byte> x, Vector256<byte> y, [Imm] Perm2x4 spec)
        => Permute2x128(x, y, (byte)spec);

    /// <summary>
    /// __m256i _mm256_permute2x128_si256 (__m256i a, __m256i b, const int imm8) VPERM2I128 ymm, ymm, ymm/m256, imm8
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <param name="spec">The permutation spec</param>
    [MethodImpl(Inline), Op]
    public static Vector256<short> vperm2x128(Vector256<short> x, Vector256<short> y, [Imm] Perm2x4 spec)
        => Permute2x128(x, y, (byte)spec);

    /// <summary>
    /// __m256i _mm256_permute2x128_si256 (__m256i a, __m256i b, const int imm8) VPERM2I128 ymm, ymm, ymm/m256, imm8
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <param name="spec">The permutation spec</param>
    [MethodImpl(Inline), Op]
    public static Vector256<ushort> vperm2x128(Vector256<ushort> x, Vector256<ushort> y, [Imm] Perm2x4 spec)
        => Permute2x128(x, y, (byte)spec);

    /// <summary>
    /// __m256i _mm256_permute2x128_si256 (__m256i a, __m256i b, const int imm8) VPERM2I128 ymm, ymm, ymm/m256, imm8
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <param name="spec">The permutation spec</param>
    [MethodImpl(Inline), Op]
    public static Vector256<int> vperm2x128(Vector256<int> x, Vector256<int> y, [Imm] Perm2x4 spec)
        => Permute2x128(x, y, (byte)spec);

    /// <summary>
    /// __m256i _mm256_permute2x128_si256 (__m256i a, __m256i b, const int imm8) VPERM2I128 ymm, ymm, ymm/m256, imm8
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <param name="spec">The permutation spec</param>
    [MethodImpl(Inline), Op]
    public static Vector256<uint> vperm2x128(Vector256<uint> x, Vector256<uint> y, [Imm] Perm2x4 spec)
        => Permute2x128(x, y, (byte)spec);

    /// <summary>
    /// __m256i _mm256_permute2x128_si256 (__m256i a, __m256i b, const int imm8) VPERM2I128 ymm, ymm, ymm/m256, imm8
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <param name="spec">The permutation spec</param>
    [MethodImpl(Inline), Op]
    public static Vector256<long> vperm2x128(Vector256<long> x, Vector256<long> y, [Imm] Perm2x4 spec)
        => Permute2x128(x, y, (byte)spec);

    /// <summary>
    /// __m256i _mm256_permute2x128_si256 (__m256i a, __m256i b, const int imm8) VPERM2I128 ymm, ymm, ymm/m256, imm8
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <param name="spec">The permutation spec</param>
    [MethodImpl(Inline), Op]
    public static Vector256<ulong> vperm2x128(Vector256<ulong> x, Vector256<ulong> y, [Imm] Perm2x4 spec)
        => Permute2x128(x, y, (byte)spec);
}
