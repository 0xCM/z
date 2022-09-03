//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.Intrinsics.X86.Sse41;
    using static System.Runtime.Intrinsics.X86.Avx;
    using static System.Runtime.Intrinsics.X86.Avx2;
    using static cpu;

    partial struct vpack
    {
        /// <summary>
        /// __m128i _mm_cvtepi16_epi32 (__m128i a)
        /// PMOVSXWD xmm, xmm/m64
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The target vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<int> vlo128x32i(Vector128<short> src)
            => ConvertToVector128Int32(src);

        /// <summary>
        /// __m256i _mm256_cvtepi32_epi64 (__m128i a)
        /// VPMOVSXDQ ymm, xmm/m128
        /// 4x32i -> 4x64i
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The target vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<long> vlo256x64i(Vector256<int> src)
            => ConvertToVector256Int64(vlo(src));
    }
}