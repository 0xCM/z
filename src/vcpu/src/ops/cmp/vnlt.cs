//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.Intrinsics.X86.Sse;
    using static System.Runtime.Intrinsics.X86.Sse2;

    partial class vcpu
    {
        /// <summary>
        ///  __m128d _mm_cmpnlt_pd (__m128d a, __m128d b) CMPPD xmm, xmm/m128, imm8(5)
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<double> vnlt(Vector128<double> x, Vector128<double> y)
            => CompareNotLessThan(x, y);

        /// <summary>
        /// __m128 _mm_cmpnlt_ps (__m128 a, __m128 b) CMPPS xmm, xmm/m128, imm8(5)
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<float> vnlt(Vector128<float> x, Vector128<float> y)
            => CompareNotLessThan(x, y);
    }
}