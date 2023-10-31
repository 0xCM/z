//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static vcpu;

partial struct vpack
{
    /// <summary>
    /// PMOVSXBW xmm, m64
    /// </summary>
    /// <returns></returns>
    [MethodImpl(Inline)]
    public static unsafe Vector128<short> pmovsxbw(W128 w, sbyte* pSrc)
        => ConvertToVector128Int16(pSrc);

    /// <summary>
    /// __m128i _mm_cvtepi8_epi16 (__m128i a)
    /// PMOVSXBW xmm, xmm/m64
    /// 8x8i -> 8x16i
    /// movsx(src[i]) -> dst[i], i = 0,.., 7
    /// </summary>
    /// <param name="src">The source vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<short> pmovsxbw(W128 w, N0 n, Vector128<sbyte> src)
        => ConvertToVector128Int16(vslo(src));

    /// <summary>
    /// __m128i _mm_cvtepi8_epi16 (__m128i a)
    /// PMOVSXBW xmm, xmm/m64
    /// 8x8i -> 8x16i
    /// movsx(src[i]) -> dst[i], i = 0,.., 7
    /// </summary>
    /// <param name="src">The source vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<short> pmovsxbw(W128 w, N1 n, Vector128<sbyte> src)
        => ConvertToVector128Int16(vshi(src));

}