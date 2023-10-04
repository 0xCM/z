//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

[ApiHost, Free]
public unsafe class Sse41
{
    /// <summary>
    /// PMOVSXBW xmm, m64
    /// </summary>
    /// <returns></returns>
    [MethodImpl(Inline)]
    public static Vector128<short> pmovsxbw(sbyte* pSrc)
        => ConvertToVector128Int16(pSrc);

    /// <summary>
    /// PMOVZXBW xmm, m64
    /// </summary>
    /// <returns></returns>
    [MethodImpl(Inline)]
    public static Vector128<short> pmovzxbw(byte* pSrc)
        => ConvertToVector128Int16(pSrc);

    /// <summary>
    /// Zero extend packed unsigned 8-bit integers in "a" to packed 16-bit integers, and store the results in "dst"
    /// </summary>
    /// <intrinsic>_mm_cvtepu8_epi16</intrinsic>
    /// <form>PMOVZXBW_XMMdq_XMMq</form>
    /// <instruction>pmovzxbw xmm, xmm</instruction>
    /// <param name="a"></param>
    [MethodImpl(Inline)]
    public static Vector128<short> _mm_cvtepu8_epi16(Vector128<byte> a)
        => ConvertToVector128Int16(a);

    /// <summary>
    /// Sign extend packed 8-bit integers in "a" to packed 16-bit integers, and store the results in "dst".
    /// </summary>
    /// <intrinsic>_mm_cvtepi8_epi16</intrinsic>
    /// <form>PMOVSXBW_XMMdq_XMMq</form>
    /// <instruction>pmovsxbw xmm, xmm</instruction>
    /// <param name="a"></param>
    [MethodImpl(Inline)]
    public static Vector128<short> _mm_cvtepi8_epi16(Vector128<sbyte> a)
        => ConvertToVector128Int16(a);
}
