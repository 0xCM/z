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
        /// 8x8u -> 8x32u
        /// movzx(src[i]) -> dst[i], i = 0,..,7
        /// __m256i _mm256_cvtepu8_epi32(__m128i a)
        /// VPMOVZXBD ymm, xmm
        /// VPMOVZXBD_YMMqq_XMMq
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The target vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<uint> vpmovzxbd(Vector128<byte> src, out Vector256<uint> dst)
            => dst = v32u(ConvertToVector256Int32(src));
    }
}