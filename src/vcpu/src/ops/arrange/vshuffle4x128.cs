//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class vcpu
{
    /// <summary>
    /// __m512i _mm512_shuffle_epi32 (__m512i a, const int imm8)
    /// VPSHUFD zmm1 {k1}{z}, zmm2/m512/m32bcst, imm8
    /// Shuffle 32-bit integers in a within 128-bit lanes using the control in imm8, and store the results in dst.
    /// </summary>
    [MethodImpl(Inline), Op]
    public static Vector512<int> vshuffle4x128(Vector512<int> src, [Imm] Perm4x4 spec)
        => Shuffle(src, (byte)spec);

    /// <summary>
    /// __m512i _mm512_shuffle_i32x4 (__m512i a, __m512i b, const int imm8)
    /// VSHUFI32x4 zmm1 {k1}{z}, zmm2, zmm3/m512/m32bcst, imm8
    /// Shuffle 128-bits (composed of 4 32-bit integers) selected by "imm8" from "a" and "b", and store the results in "dst".
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <param name="spec"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<uint> vshuffle4x128(Vector512<uint> a, Vector512<uint> b, [Imm] byte spec)
        => Shuffle4x128(a, b, spec);

    /// <summary>
    /// __m512i _mm512_shuffle_i64x2 (__m512i a, __m512i b, const int imm8)
    /// VSHUFI64x2 zmm1 {k1}{z}, zmm2, zmm3/m512/m64bcst, imm8
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <param name="spec"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<ulong> vshuffle4x128(Vector512<ulong> a, Vector512<ulong> b, [Imm] byte spec)
        => Shuffle4x128(a, b, spec);   
}