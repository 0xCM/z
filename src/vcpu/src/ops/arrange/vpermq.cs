//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class vcpu
{
    /// <summary>
    /// __m256i _mm256_permute4x64_epi64 (__m256i a, const int imm8)
    /// VPERMQ ymm, ymm/m256, imm8
    /// Permutes vector content across lanes at 64-bit granularity
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <param name="spec">The control byte</param>
    [MethodImpl(Inline), Asm(ApiAsmClass.VPERMQ)]
    public static Vector256<ulong> vpermq(Vector256<ulong> x, [Imm] Perm4L spec)
        => Permute4x64(x, (byte)spec);

    /// <summary>
    /// __m256i _mm256_permute4x64_epi64 (__m256i a, const int imm8)
    /// VPERMQ ymm, ymm/m256, imm8
    /// Permutes vector content across lanes at 64-bit granularity
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <param name="spec">The control byte</param>
    [MethodImpl(Inline), Asm(ApiAsmClass.VPERMQ)]
    public static Vector256<long> vpermq(Vector256<long> x, [Imm] Perm4L spec)
        => Permute4x64(x, (byte)spec);

    /// <summary>
    /// __m512i _mm512_permute4x64_epi64 (__m512i a, const int imm8)
    /// VPERMQ zmm1 {k1}{z}, zmm2/m512/m64bcst, imm8
    /// </summary>
    /// <param name="x"></param>
    /// <param name="spec"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<long> vpermq(Vector512<long> x, [Imm] Perm4L spec)
        => Permute4x64(x, (byte)spec);

    /// <summary>
    /// __m512i _mm512_permute4x64_epi64 (__m512i a, const int imm8)
    /// VPERMQ zmm1 {k1}{z}, zmm2/m512/m64bcst, imm8
    /// </summary>
    /// <param name="x"></param>
    /// <param name="spec"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<ulong> vpermq(Vector512<ulong> x, [Imm] Perm4L spec)
        => Permute4x64(x, (byte)spec);
     
    /// <summary>
    /// __m256i _mm256_permute4x64_epi64 (__m256i a, __m256i b)
    /// VPERMQ ymm1 {k1}{z}, ymm2, ymm3/m256/m64bcst
    /// </summary>
    /// <param name="a"></param>
    /// <param name="spec"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector256<long> vpermq(Vector256<long> a, Vector256<long> spec)
        => PermuteVar4x64(a, spec);

    /// <summary>
    /// __m256i _mm256_permute4x64_epi64 (__m256i a, __m256i b)
    /// VPERMQ ymm1 {k1}{z}, ymm2, ymm3/m256/m64bcst
    /// </summary>
    /// <param name="a"></param>
    /// <param name="spec"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector256<ulong> vpermq(Vector256<ulong> a, Vector256<ulong> spec)
        => PermuteVar4x64(a, spec);

    /// <summary>
    /// __m512i _mm512_permutevar8x64_epi64 (__m512i a, __m512i b)
    /// VPERMQ zmm1 {k1}{z}, zmm2, zmm3/m512/m64bcst
    /// </summary>
    /// <param name="a"></param>
    /// <param name="spec"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<long> vpermq(Vector512<long> a, Vector512<long> spec)
        => PermuteVar8x64(a, spec);

    /// <summary>
    /// __m512i _mm512_permutevar8x64_epi64 (__m512i a, __m512i b)
    /// VPERMQ zmm1 {k1}{z}, zmm2, zmm3/m512/m64bcst
    /// </summary>
    /// <param name="a"></param>
    /// <param name="spec"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<ulong> vpermq(Vector512<ulong> a, Vector512<ulong> spec)
        => PermuteVar8x64(a, spec);
}
