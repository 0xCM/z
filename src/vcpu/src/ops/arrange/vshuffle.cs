//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class vcpu
{
    /// <summary>
    /// __m128d _mm_shuffle_pd (__m128d a, __m128d b, int immediate) SHUFPD xmm, xmm/m128, imm8
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <param name="spec"></param>
    [MethodImpl(Inline), Op]
    public static Vector128<uint> vshuffle(Vector128<uint> x, Vector128<uint> y, [Imm] BitState spec)
        => v32u(Shuffle(v32f(x), v32f(y), (byte)spec));

    /// <summary>
    /// __m128d _mm_shuffle_pd (__m128d a, __m128d b, int immediate) SHUFPD xmm, xmm/m128, imm8
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <param name="spec"></param>
    [MethodImpl(Inline), Op]
    public static Vector128<ulong> vshuffle(Vector128<ulong> x, Vector128<ulong> y, [Imm] BitState spec)
        => v64u(Shuffle(v64f(x), v64f(y), (byte)spec));

    /// <summary>
    /// __m512i _mm512_shuffle_epi32 (__m512i a, const int imm8)
    ///   VPSHUFD zmm1 {k1}{z}, zmm2/m512/m32bcst, imm8
    /// </summary>
    [MethodImpl(Inline), Op]
    public static Vector512<uint> vshuffle(Vector512<uint> src, [Imm] _MM_PERM_ENUM spec)
        => Shuffle(src, (byte)spec);

    [MethodImpl(Inline), Op]
    public static Vector512<uint> vshuffle4x128(Vector512<uint> a, Vector512<uint> b, [Imm] byte spec)
        => Shuffle4x128(a, b, spec);
}
