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
        /// 4x32 -> 4x64u
        /// movzx(src[i]) -> dst[i], i = 0,..,3
        /// __m256i _mm256_cvtepu32_epi64(__m128i a)
        /// VPMOVZXDQ ymm, xmm
        /// VPMOVZXDQ_YMMqq_XMMdq
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The target vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<ulong> vpmovzxdq(Vector128<uint> src, out Vector256<ulong> dst)
            => dst = v64u(ConvertToVector256Int64(src));
    }
}