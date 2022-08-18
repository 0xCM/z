//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct vpack
    {
        /// <summary>
        /// __m256i _mm256_cvtepi16_epi32 (__m128i a) VPMOVSXWD ymm, xmm/m128
        /// 8x16i -> 8x32i
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="w">The target vector width</param>
        /// <param name="t">A target component type representative</param>
        [MethodImpl(Inline), Op(inflate)]
        public static Vector256<int> vinflate8x16i(Vector128<short> src, out Vector256<int> dst)
            => dst = vunpack8x32(src);
    }
}