//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.Intrinsics.X86.Avx2;

    partial class vcpu
    {
        /// <summary>
        /// 4x8u -> 4x64u
        /// movzx(src[i]) -> dst[i], i = 0,..,3
        /// __m256i _mm256_cvtepu8_epi64(__m128i a)
        /// VPMOVZXBQ ymm, xmm
        /// VPMOVZXBQ_YMMqq_XMMd
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The target vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<ulong> vpmovzxbq(Vector128<byte> src, out Vector256<ulong> dst)
            => dst = v64u(ConvertToVector256Int64(src));

        /// <summary>
        /// 4x8u -> 4x64u
        /// movzx(src[i]) -> dst[i], i = 0,..,3
        /// __m256i _mm256_cvtepu8_epi64(__m128i a)
        /// VPMOVZXBQ ymm, xmm
        /// VPMOVZXBQ_YMMqq_XMMd
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The target vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<ulong> vpmovzxbq(uint src, out Vector256<ulong> dst)
            => dst = v64u(ConvertToVector256Int64(vload(w128, sys.bytes(src))));
    }
}