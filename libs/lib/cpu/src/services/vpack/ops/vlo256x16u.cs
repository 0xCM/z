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
        /// __m256i _mm256_cvtepu8_epi16 (__m128i a)
        /// VPMOVZXBW ymm, xmm
        /// 16x8u -> 16x16u
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The target vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<ushort> vlo256x16u(Vector256<byte> src)
            => v16u(ConvertToVector256Int16(vlo(src)));
    }
}