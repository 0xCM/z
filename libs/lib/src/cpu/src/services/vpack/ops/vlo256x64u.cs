//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.Intrinsics.X86.Avx2;
    using static cpu;

    partial struct vpack
    {
        /// <summary>
        /// __m256i _mm256_cvtepu16_epi64 (__m128i a)
        /// VPMOVZXWQ ymm, xmm
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The target vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<ulong> vlo256x64u(Vector128<ushort> src)
            => v64u(ConvertToVector256Int64(src));

        /// <summary>
        /// __m256i _mm256_cvtepi32_epi64 (__m128i a)
        /// VPMOVSXDQ ymm, xmm/m128
        /// 4x32u -> 4x64u
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The target vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<ulong> vlo256x64u(Vector256<uint> src)
            => v64u(ConvertToVector256Int64(vlo(src)));
    }
}