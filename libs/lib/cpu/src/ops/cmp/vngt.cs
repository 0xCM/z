//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.Intrinsics.X86.Sse;
    using static System.Runtime.Intrinsics.X86.Sse2;

    partial struct cpu
    {
        /// <summary>
        /// __m128 _mm_cmpngt_ps (__m128 a, __m128 b) CMPPS xmm, xmm/m128, imm8(2)
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<float> vngt(Vector128<float> x, Vector128<float> y)
            => CompareNotGreaterThan(x, y);

        /// <summary>
        /// __m128d _mm_cmpngt_pd (__m128d a, __m128d b) CMPPD xmm, xmm/m128, imm8(2)
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<double> vngt(Vector128<double> x, Vector128<double> y)
            => CompareNotGreaterThan(x, y);
    }
}