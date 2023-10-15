//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static System.Runtime.Intrinsics.X86.Avx2;

partial class vcpu
{
    /// <summary>
    /// 8x16u -> 8x32u
    /// movzx(src[i]) -> dst[i], i = 0,..,7
    /// __m256i _mm256_cvtepu16_epi32(__m128i a)
    /// VPMOVZXWD ymm, xmm
    /// VPMOVZXWD_YMMqq_XMMdq
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<uint> vpmovzxwd(Vector128<ushort> src, out Vector256<uint> dst)
        => dst = v32u(ConvertToVector256Int32(src));
}
