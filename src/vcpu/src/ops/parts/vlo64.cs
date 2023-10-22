//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class vcpu
{
    /// <summary>
    /// __int64 _mm_cvtsi128_si64 (__m128i a)
    /// MOVQ reg/m64, xmm
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="wDst">The target width</param>
    [MethodImpl(Inline), Op]
    public static long vlo64i(Vector128<long> src)
        => ConvertToInt64(src);

    /// <summary>
    /// __int64 _mm_cvtsi128_si64 (__m128i a)
    /// MOVQ reg/m64, xmm
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="wDst">The target width</param>
    [MethodImpl(Inline), Op]
    public static ulong vlo64u(Vector128<ulong> src)
        => ConvertToUInt64(src);

    /// <summary>
    /// __int64 _mm_cvtss_si64 (__m128 a) CVTSS2SI r64, xmm/m32
    /// src[0..31] -> r64
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="wDst">The target width</param>
    [MethodImpl(Inline), Op]
    public static long vlo64i(Vector128<float> src)
        => ConvertToInt64(src);

    /// <summary>
    ///  __int64 _mm_cvtsd_si64 (__m128d a) CVTSD2SI r64, xmm/m64
    /// src[0..63] -> r64
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="wDst">The target width</param>
    [MethodImpl(Inline), Op]
    public static long vlo64i(Vector128<double> src)
        => ConvertToInt64(src);
}
