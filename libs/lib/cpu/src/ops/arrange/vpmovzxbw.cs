//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.Intrinsics.X86.Avx2;

    partial struct cpu
    {
        /// <summary>
        /// 16x8u -> 16x16u
        /// movzx(src[i]) -> dst[i], i = 0,..,15
        /// __m256i _mm256_cvtepu8_epi16(__m128i a)
        /// VPMOVZXBW ymm, xmm
        /// VPMOVZXBW_YMMqq_XMMdq
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The target vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<ushort> vpmovzxbw(Vector128<byte> src, out Vector256<ushort> dst)
            => dst = v16u(ConvertToVector256Int16(src));
    }
}