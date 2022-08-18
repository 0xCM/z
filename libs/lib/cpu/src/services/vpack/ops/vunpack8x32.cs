//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.Intrinsics.X86.Avx;
    using static System.Runtime.Intrinsics.X86.Avx2;
    using static core;
    using static cpu;

    partial struct vpack
    {
        /// <summary>
        /// VPMOVZXBD ymm, m64
        /// 8x8u -> 8x32u
        /// Zero extends 8 8-bit integers to 8 32-bit integers in ymm1
        /// </summary>
        /// <param name="src">The source reference</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector256<uint> vunpack8x32(in byte src)
            => v32u(ConvertToVector256Int32(gptr(src)));

        /// <summary>
        /// __m256i _mm256_cvtepi16_epi32 (__m128i a) VPMOVSXWD ymm, xmm/m128
        /// 8x16i -> 8x32i
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="w">The target vector width</param>
        /// <param name="t">A target component type representative</param>
        [MethodImpl(Inline), Op]
        public static Vector256<int> vunpack8x32(Vector128<short> src)
            => ConvertToVector256Int32(src);

        /// <summary>
        /// Projects 8 8-bit source segments onto 8 32-bit unsigned integers
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static Vector256<uint> vunpack8x32(ulong src)
            =>  v32u(ConvertToVector256Int32(v8u(vscalar(w128,src))));
    }
}