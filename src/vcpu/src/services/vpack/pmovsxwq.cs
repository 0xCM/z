//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial struct vpack
{
    /// <summary>
    /// PMOVSXWQ xmm, m32
    /// 2x16i -> 2x64u
    /// Projects 2 16-bit signed integers onto 2 64-bit signed integers
    /// </summary>
    /// <param name="pSrc">The input component source</param>
    /// <param name="n">The source component count</param>
    /// <param name="w">The target component width</param>
    [MethodImpl(Inline), Op]
    public static unsafe Vector128<long> pmovsxwq(W128 w, short* pSrc)
        => ConvertToVector128Int64(pSrc);

    /// <summary>
    /// __m128i _mm_cvtepi16_epi64 (__m128i a)
    /// PMOVSXWQ xmm, xmm/m32
    /// </summary>
    /// <param name="src"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static unsafe Vector128<long> pmovsxwq(W128 w,  Vector128<short> src)
        => ConvertToVector128Int64(src);
}