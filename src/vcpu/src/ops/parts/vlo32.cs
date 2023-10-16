//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class vcpu
{
    /// <summary>
    /// int _mm_cvtsi128_si32 (__m128i a)
    /// MOVD reg/m32, xmm
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="wDst">The target width</param>
    [MethodImpl(Inline), Op]
    public static int vlo32i(Vector128<int> src)
        => ConvertToInt32(src);

    /// <summary>
    /// int _mm_cvtsi128_si32 (__m128i a)
    /// MOVD reg/m32, xmm
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="wDst">The target width</param>
    [MethodImpl(Inline), Op]
    public static uint vlo32u(Vector128<uint> src)
        => ConvertToUInt32(src);
}
