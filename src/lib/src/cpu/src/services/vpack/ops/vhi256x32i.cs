//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.Intrinsics.X86.Avx;
    using static System.Runtime.Intrinsics.X86.Avx2;
    using static vcpu;

    partial struct vpack
    {
        /// <summary>
        /// __m256i _mm256_cvtepi8_epi32 (__m128i a)
        /// VPMOVSXBD ymm, xmm/m128
        /// 8x8i -> 8x32i
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="w">The target width selector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<int> vhi256x32i(Vector128<sbyte> src)
            => ConvertToVector256Int32(vshi(src));

        /// <summary>
        /// __m256i _mm256_cvtepi16_epi32 (__m128i a)
        /// VPMOVSXWD ymm, xmm/m128
        /// 8x16i -> 8x32i
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="w">The target width selector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<int> vhi256x32i(Vector256<short> src)
            => ConvertToVector256Int32(vhi(src));
    }
}