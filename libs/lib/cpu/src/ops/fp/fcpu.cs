//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Intrinsics;
    using System.Runtime.Intrinsics.X86;

    using static System.Runtime.Intrinsics.X86.Sse;
    using static System.Runtime.Intrinsics.X86.Fma;
    using static System.Runtime.Intrinsics.X86.Sse41;
    using static System.Runtime.Intrinsics.X86.Avx;
    using static System.Runtime.Intrinsics.X86.Sse2;
    using static System.Runtime.Intrinsics.X86.Sse3;
    using static System.Runtime.Intrinsics.X86.Ssse3;
    using static Root;

    [ApiHost]
    public readonly struct fcpu
    {
        /// <summary>
        /// __m128 _mm_rcp_ps (__m128 a) RCPPS xmm, xmm/m128
        /// </summary>
        /// <param name="x">The source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<float> vrcp(Vector128<float> x)
            => Reciprocal(x);

        /// <summary>
        /// __m256 _mm256_rcp_ps (__m256 a) VRCPPS ymm, ymm/m256
        /// </summary>
        /// <param name="x">The source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<float> vrcp(Vector256<float> x)
            => Reciprocal(x);

        /// <summary>
        /// dst = x*y + z
        /// __m128 _mm_fmadd_ps (__m128 a, __m128 b, __m128 c) VFMADDPS xmm, xmm, xmm/m128
        /// </summary>
        /// <param name="a">The first operand</param>
        /// <param name="b">The second operand</param>
        /// <param name="c">The third operand</param>
        [MethodImpl(Inline), Op]
        public static Vector128<float> vfmadd(Vector128<float> a, Vector128<float> b, Vector128<float> c)
            => MultiplyAdd(a, b, c);

        /// <summary>
        /// dst = x*y + z
        ///  __m128d _mm_fmadd_pd (__m128d a, __m128d b, __m128d c) VFMADDPD xmm, xmm, xmm/m128
        /// </summary>
        /// <param name="a">The first operand</param>
        /// <param name="b">The second operand</param>
        /// <param name="c">The third operand</param>
        [MethodImpl(Inline), Op]
        public static Vector128<double> vfmadd(Vector128<double> a, Vector128<double> b, Vector128<double> c)
            => MultiplyAdd(a, b, c);

        /// <summary>
        /// __m256 _mm256_fmadd_ps (__m256 a, __m256 b, __m256 c) VFMADDPS ymm, ymm, ymm/m256
        /// dst = a*b + c
        /// </summary>
        /// <param name="x">The first operand</param>
        /// <param name="y">The second operand</param>
        /// <param name="z">The third operand</param>
        [MethodImpl(Inline), Op]
        public static Vector256<float> vfmadd(Vector256<float> x, Vector256<float> y, Vector256<float> z)
            => MultiplyAdd(x,y,z);

        /// <summary>
        /// __m256d _mm256_fmadd_pd (__m256d a, __m256d b, __m256d c) VFMADDPS ymm, ymm, ymm/m256
        /// dst = a*b + c
        /// </summary>
        /// <param name="x">The first operand</param>
        /// <param name="y">The second operand</param>
        /// <param name="z">The third operand</param>
        [MethodImpl(Inline), Op]
        public static Vector256<double> vfmadd(Vector256<double> x, Vector256<double> y, Vector256<double> z)
            => MultiplyAdd(x,y,z);

        /// <summary>
        /// __m128d _mm_ceil_sd (__m128d a) ROUNDSD xmm, xmm/m128, imm8(10)
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<float> vceil(Vector128<float> src)
            => Ceiling(src);

        /// <summary>
        /// __m128d _mm_ceil_pd (__m128d a) ROUNDPD xmm, xmm/m128, imm8(10)
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<double> vceil(Vector128<double> src)
            => Ceiling(src);

        /// <summary>
        /// __m256 _mm256_ceil_ps (__m256 a) VROUNDPS ymm, ymm/m256, imm8(10)
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<float> vceil(Vector256<float> src)
            => Ceiling(src);

        /// <summary>
        /// __m256 _mm256_ceil_pd (__m256 a) VROUNDPS ymm, ymm/m256, imm8(10)
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<double> vceil(Vector256<double> src)
            => Ceiling(src);

        /// <summary>
        /// __m128 _mm_floor_ps (__m128 a) ROUNDPS xmm, xmm/m128, imm8(9)
        /// </summary>
        /// <param name="x">The source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<float> vfloor(Vector128<float> x)
            => Floor(x);

        /// <summary>
        /// __m128 _mm_floor_ps (__m128 a) ROUNDPS xmm, xmm/m128, imm8(9)
        /// </summary>
        /// <param name="x">The source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<double> vfloor(Vector128<double> x)
            => Floor(x);

        /// <summary>
        /// __m256 _mm256_floor_ps (__m256 a) VROUNDPS ymm, ymm/m256, imm8(9)
        /// </summary>
        /// <param name="x">The source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<float> vfloor(Vector256<float> x)
            => Floor(x);

        /// <summary>
        ///  __m256d _mm256_floor_pd (__m256d a) VROUNDPS ymm, ymm/m256, imm8(9)
        /// </summary>
        /// <param name="x">The source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<double> vfloor(Vector256<double> x)
            => Floor(x);

        /// <summary>
        /// __m128 _mm_cvtepi32_ps (__m128i a) CVTDQ2PS xmm, xmm/m128
        /// Converts an integer source vector to a floating-point target vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="w">The target width</param>
        /// <param name="t">A target type representative</param>
        [MethodImpl(Inline), Op]
        public static Vector128<float> vconvert128x32f(Vector128<int> src)
            => ConvertToVector128Single(src);

        /// <summary>
        /// __m128 _mm_cvtpd_ps (__m128d a) CVTPD2PS xmm, xmm/m128
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="w">The target width</param>
        /// <param name="t">A target type representative</param>
        [MethodImpl(Inline), Op]
        public static Vector128<float> vconvert128x32f(Vector128<double> src)
            => ConvertToVector128Single(src);

        /// <summary>
        /// __m128 _mm256_cvtpd_ps (__m256d a) VCVTPD2PS xmm, ymm/m256
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="w">The target width</param>
        /// <param name="t">A target type representative</param>
        [MethodImpl(Inline), Op]
        public static Vector128<float> vconvert128x32f(Vector256<double> src)
            => ConvertToVector128Single(src);

        /// <summary>
        /// __m128i _mm_cvttps_epi32 (__m128 a) CVTTPS2DQ xmm, xmm/m128
        /// Converts a floating-point source vector to an 32-bit integer target vector with a loss of precision
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="w">The target width</param>
        /// <param name="t">A target type representative</param>
        [MethodImpl(Inline), Op]
        public static Vector128<int> vconvert128x32i(Vector128<float> src)
            => ConvertToVector128Int32(src);

        /// <summary>
        ///  __m128i _mm256_cvtpd_epi32 (__m256d a) VCVTPD2DQ xmm, ymm/m256
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="w">The target width</param>
        /// <param name="t">A target type representative</param>
        [MethodImpl(Inline), Op]
        public static Vector128<int> vconvert128x32i(Vector256<double> src)
            => ConvertToVector128Int32(src);

        /// <summary>
        ///  __m128i _mm_cvttpd_epi32 (__m128d a) CVTTPD2DQ xmm, xmm/m128
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="w">The target width</param>
        /// <param name="t">A target type representative</param>
        [MethodImpl(Inline), Op]
        public static Vector128<int> vconvert128x32i(Vector128<double> src)
            => ConvertToVector128Int32(src);

        /// <summary>
        /// __m256 _mm256_cvtepi32_ps (__m256i a) VCVTDQ2PS ymm, ymm/m256
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="w">The target width</param>
        /// <param name="t">A target type representative</param>
        [MethodImpl(Inline), Op]
        public static Vector256<float> vconvert256x32f(Vector256<int> src)
            => ConvertToVector256Single(src);

        /// <summary>
        /// __m256i _mm256_cvtps_epi32 (__m256 a) VCVTPS2DQ ymm, ymm/m256
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="w">The target width</param>
        /// <param name="t">A target type representative</param>
        [MethodImpl(Inline), Op]
        public static Vector256<int> vconvert256x32i(Vector256<float> src)
            =>  ConvertToVector256Int32(src);

        /// <summary>
        /// __m256d _mm256_cvtepi32_pd (__m128i a) VCVTDQ2PD ymm, xmm/m128
        /// 4x32i -> 4x64f
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The target vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<double> vconvert256x64f(Vector128<int> src)
            => ConvertToVector256Double(src);


        /// <summary>
        /// __m128 _mm_div_ps (__m128 a, __m128 b)DIVPS xmm, xmm/m128
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<float> vdiv(Vector128<float> x, Vector128<float> y)
            => Divide(x, y);

        /// <summary>
        ///  __m128d _mm_div_pd (__m128d a, __m128d b)DIVPD xmm, xmm/m128
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<double> vdiv(Vector128<double> x, Vector128<double> y)
            => Divide(x, y);

        /// <summary>
        /// __m256 _mm256_div_ps (__m256 a, __m256 b)VDIVPS ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<float> vdiv(Vector256<float> x, Vector256<float> y)
            => Divide(x, y);

        /// <summary>
        /// __m256d _mm256_div_pd (__m256d a, __m256d b)VDIVPD ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<double> vdiv(Vector256<double> x, Vector256<double> y)
            => Divide(x, y);

        /// <summary>
        /// __m128 _mm_sqrt_ps (__m128 a) SQRTPS xmm, xmm/m128
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<float> vsqrt(Vector128<float> src)
            => Sqrt(src);

        /// <summary>
        /// __m128d _mm_sqrt_pd (__m128d a) SQRTPD xmm, xmm/m128
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<double> vsqrt(Vector128<double> src)
            => Sqrt(src);

        /// <summary>
        /// __m256 _mm256_sqrt_ps (__m256 a) VSQRTPS ymm, ymm/m256
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<float> vsqrt(Vector256<float> src)
            => Sqrt(src);

        /// <summary>
        /// __m256d _mm256_sqrt_pd (__m256d a) VSQRTPD ymm, ymm/m256
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<double> vsqrt(Vector256<double> src)
            => Sqrt(src);

        /// <summary>
        /// __m128 _mm_rsqrt_ps (__m128 a) RSQRTPS xmm, xmm/m128
        /// </summary>
        /// <param name="src"></param>
        [MethodImpl(Inline), Op]
        public static Vector128<float> vrsqrt(Vector128<float> src)
            => ReciprocalSqrt(src);

        /// <summary>
        /// Computes the bitwise XOR between operands
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Op]
        public static Vector128<float> vxor1(Vector128<float> x)
            => Xor(x, CompareEqual(default(Vector128<float>), default(Vector128<float>)));

        /// <summary>
        /// Computes the bitwise XOR between operands
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Op]
        public static Vector128<double> vxor1(Vector128<double> x)
            => Xor(x, CompareEqual(default(Vector128<double>), default(Vector128<double>)));

        /// <summary>
        /// Computes the bitwise XOR between operands
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Op]
        public static Vector256<float> vxor1(Vector256<float> x)
            => Xor(x, Compare(default(Vector256<float>), default(Vector256<float>), FloatComparisonMode.OrderedEqualNonSignaling));

        /// <summary>
        /// Computes the bitwise XOR between operands
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Op]
        public static Vector256<double> vxor1(Vector256<double> x)
            => Xor(x, Compare(default(Vector256<double>), default(Vector256<double>), FloatComparisonMode.OrderedEqualNonSignaling));

        /// <summary>
        /// __m128 _mm_fnmadd_ps (__m128 a, __m128 b, __m128 c) VFNMADDPS xmm, xmm, xmm/m128
        /// dst = -(x*y + c)
        /// </summary>
        /// <param name="x">The first operand</param>
        /// <param name="y">The second operand</param>
        /// <param name="z">The third operand</param>
        [MethodImpl(Inline), Op]
        public static Vector128<float> vfman(Vector128<float> x, Vector128<float> y, Vector128<float> z)
            => MultiplyAddNegated(x,y,z);

        /// <summary>
        /// __m128d _mm_fnmadd_pd (__m128d a, __m128d b, __m128d c) VFNMADDPD xmm, xmm, xmm/m128
        /// dst = -(x*y + z)
        /// </summary>
        /// <param name="x">The first operand</param>
        /// <param name="y">The second operand</param>
        /// <param name="z">The third operand</param>
        [MethodImpl(Inline), Op]
        public static Vector128<double> vfman(Vector128<double> x, Vector128<double> y, Vector128<double> z)
            => MultiplyAddNegated(x,y,z);

        /// <summary>
        /// __m256 _mm256_fnmadd_ps (__m256 a, __m256 b, __m256 c) VFNMADDPS ymm, ymm, ymm/m256
        /// dst = -(x*y + z)
        /// </summary>
        /// <param name="x">The first operand</param>
        /// <param name="y">The second operand</param>
        /// <param name="z">The third operand</param>
        [MethodImpl(Inline), Op]
        public static Vector256<float> vfman(Vector256<float> x, Vector256<float> y, Vector256<float> z)
            => MultiplyAddNegated(x,y,z);

        /// <summary>
        /// __m256d _mm256_fnmadd_pd (__m256d a, __m256d b, __m256d c) VFNMADDPD ymm, ymm,ymm/m256
        /// dst = -(x*y + z)
        /// </summary>
        /// <param name="x">The first operand</param>
        /// <param name="y">The second operand</param>
        /// <param name="z">The third operand</param>
        [MethodImpl(Inline), Op]
        public static Vector256<double> vfman(Vector256<double> x, Vector256<double> y, Vector256<double> z)
            => MultiplyAddNegated(x,y,z);

        /// <summary>
        /// __m128 _mm_fmaddsub_ps (__m128 a, __m128 b, __m128 c) VFMADDSUBPS xmm, xmm, xmm/m128
        /// dst = x*y - z
        /// </summary>
        /// <param name="x">The first operand</param>
        /// <param name="y">The second operand</param>
        /// <param name="z">The third operand</param>
        [MethodImpl(Inline), Op]
        public static Vector128<float> vfmas(Vector128<float> x, Vector128<float> y, Vector128<float> z)
            => MultiplyAddSubtract(x,y,z);

        /// <summary>
        /// __m128d _mm_fmaddsub_pd (__m128d a, __m128d b, __m128d c) VFMADDSUBPD xmm, xmm, xmm/m128
        /// dst[i] = x[i]*y[i] + z (i is even?)
        /// dst[i] = x[i]*y[i] - z (i is odd?)
        /// </summary>
        /// <param name="x">The first operand</param>
        /// <param name="y">The second operand</param>
        /// <param name="z">The third operand</param>
        [MethodImpl(Inline), Op]
        public static Vector128<double> vfmas(Vector128<double> x, Vector128<double> y, Vector128<double> z)
            => MultiplyAddSubtract(x,y,z);

        /// <summary>
        /// __m256 _mm256_fmaddsub_ps (__m256 a, __m256 b, __m256 c) VFMADDSUBPS ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="x">The first operand</param>
        /// <param name="y">The second operand</param>
        /// <param name="z">The third operand</param>
        [MethodImpl(Inline), Op]
        public static Vector256<float> vfmas(Vector256<float> x, Vector256<float> y, Vector256<float> z)
            => MultiplyAddSubtract(x,y,z);

        /// <summary>
        /// __m256d _mm256_fmaddsub_pd (__m256d a, __m256d b, __m256d c) VFMADDSUBPD ymm, ymm, ymm/m256
        /// dst[i] = x[i]*y[i] + z (i is even?)
        /// dst[i] = x[i]*y[i] - z (i is odd?)
        /// </summary>
        /// <param name="x">The first operand</param>
        /// <param name="y">The second operand</param>
        /// <param name="z">The third operand</param>
        [MethodImpl(Inline), Op]
        public static Vector256<double> vfmas(Vector256<double> x, Vector256<double> y, Vector256<double> z)
           => MultiplyAddSubtract(x,y,z);

        /// <summary>
        /// _mm_round_ps:
        /// Round to nearest integer
        /// </summary>
        /// <param name="x">The source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<float> vround(Vector128<float> x)
            => RoundToNearestInteger(x);

        /// <summary>
        /// _mm_round_pd:
        /// Round to nearest integer
        /// </summary>
        /// <param name="x">The source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<double> vround(Vector128<double> x)
            => RoundToNearestInteger(x);

        /// <summary>
        /// _mm_round_ss:
        /// Round towards zero
        /// </summary>
        /// <param name="x">The source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<float> vroundz(Vector128<float> x)
            => RoundToZero(x);

        /// <summary>
        /// _mm_round_sd:
        /// Round towards zero
        /// </summary>
        /// <param name="x">The source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<double> vroundz(Vector128<double> x)
            => RoundToZero(x);

        /// <summary>
        /// _mm256_round_ps:
        /// Round to nearest integer
        /// </summary>
        /// <param name="x">The source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<float> vround(Vector256<float> x)
            => RoundToNearestInteger(x);

        /// <summary>
        /// __m256d _mm256_round_pd (__m256d a, _MM_FROUND_TO_NEAREST_INT | _MM_FROUND_NO_EXC) VROUNDPD ymm, ymm/m256, imm8(8)
        /// Round to nearest integer
        /// </summary>
        /// <param name="x">The source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<double> vround(Vector256<double> x)
            => RoundToNearestInteger(x);

        /// <summary>
        /// __m256 _mm256_round_ps (__m256 a, _MM_FROUND_TO_ZERO | _MM_FROUND_NO_EXC)VROUNDPS ymm, ymm/m256, imm8(11)
        /// Round towards zero
        /// </summary>
        /// <param name="x">The source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<float> vroundz(Vector256<float> x)
            => RoundToZero(x);

        /// <summary>
        /// __m256d _mm256_round_pd (__m256d a, _MM_FROUND_TO_ZERO | _MM_FROUND_NO_EXC) VROUNDPD ymm, ymm/m256, imm8(11)
        /// Round towards zero
        /// </summary>
        /// <param name="x">The source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<double> vroundz(Vector256<double> x)
            => RoundToZero(x);

        /// <summary>
        /// __m128 _mm_mul_ps (__m128 a, __m128 b) MULPS xmm, xmm/m128
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Mul]
        public static Vector128<float> vmul(Vector128<float> x,Vector128<float> y)
            => Multiply(x, y);

        /// <summary>
        /// __m128d _mm_mul_pd (__m128d a, __m128d b) MULPD xmm, xmm/m128
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Mul]
        public static Vector128<double> vmul(Vector128<double> x,Vector128<double> y)
            => Multiply(x, y);

        /// <summary>
        /// __m256 _mm256_mul_ps (__m256 a, __m256 b) VMULPS ymm, ymm, ymm/m256
        /// Multiplies corresponding components and returns the result
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Mul]
        public static Vector256<float> vmul(Vector256<float> x,Vector256<float> y)
            => Multiply(x, y);

        /// <summary>
        /// __m256d _mm256_mul_pd (__m256d a, __m256d b) VMULPD ymm, ymm, ymm/m256
        /// Multiplies corresponding components and returns the result
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Mul]
        public static Vector256<double> vmul(Vector256<double> x, Vector256<double> y)
            => Multiply(x, y);

        /// <summary>
        /// __m128 _mm_movehl_ps (__m128 a, __m128 b) MOVHLPS xmm, xmm
        /// z[0] = x[3]
        /// z[1] = y[3]
        /// z[2] = x[0]
        /// z[3] = y[0]
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        [MethodImpl(Inline), Op]
        public static Vector128<float> vmovehl(Vector128<float> x, Vector128<float> y)
            => MoveHighToLow(x,y);

        /// <summary>
        /// __m128 _mm_movelh_ps (__m128 a, __m128 b) MOVLHPS xmm, xmm
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        [MethodImpl(Inline), Op]
        public static Vector128<float> vmovelh(Vector128<float> x, Vector128<float> y)
            => MoveLowToHigh(x,y);

        /// <summary>
        /// __m128 _mm_dp_ps (__m128 a, __m128 b, const int imm8) DPPS xmm, xmm/m128, imm8
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        [MethodImpl(Inline), Op]
        public static Vector128<float> vdot(Vector128<float> x, Vector128<float> y, byte? control = null)
            => DotProduct(x, y, control ?? 0xFF);

        /// <summary>
        /// __m128d _mm_dp_pd (__m128d a, __m128d b, const int imm8) DPPD xmm, xmm/m128, imm8
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        [MethodImpl(Inline), Op]
        public static Vector128<double> vdot(Vector128<double> x, Vector128<double> y, byte? control = null)
            => DotProduct(x, y, control ?? 0xFF);

        /// <summary>
        /// __m256 _mm256_dp_ps (__m256 a, __m256 b, const int imm8) VDPPS ymm, ymm, ymm/m256,
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        [MethodImpl(Inline), Op]
        public static Vector256<float> vdot(Vector256<float> x, Vector256<float> y, byte? control = null)
            => DotProduct(x, y, control ?? 0xFF);

        /// <summary>
        /// __m128 _mm_hadd_ps (__m128 a, __m128 b) HADDPS xmm, xmm/m128
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<float> vhadd(Vector128<float> x, Vector128<float> y)
            => HorizontalAdd(x, y);

        /// <summary>
        ///  __m128d _mm_hadd_pd (__m128d a, __m128d b) HADDPD xmm, xmm/m128
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<double> vhadd(Vector128<double> x, Vector128<double> y)
            => HorizontalAdd(x, y);

        /// <summary>
        /// __m256 _mm256_hadd_ps (__m256 a, __m256 b) VHADDPS ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="a">The left vector</param>
        /// <param name="b">The right vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<float> vhadd(Vector256<float> a, Vector256<float> b)
            => HorizontalAdd(a, b);

        /// <summary>
        /// __m256d _mm256_hadd_pd (__m256d a, __m256d b) VHADDPD ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<double> vhadd(Vector256<double> x, Vector256<double> y)
            => HorizontalAdd(x, y);

        /// <summary>
        /// __m128 _mm_hsub_ps (__m128 a, __m128 b)
        /// HSUBPS xmm, xmm/m128
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<float> vhsub(Vector128<float> x, Vector128<float> y)
            => HorizontalSubtract(x, y);

        /// <summary>
        /// __m128d _mm_hsub_pd (__m128d a, __m128d b)
        /// HSUBPD xmm, xmm/m128
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<double> vhsub(Vector128<double> x, Vector128<double> y)
            => HorizontalSubtract(x, y);

        /// <summary>
        /// __m256 _mm256_hsub_ps (__m256 a, __m256 b) VHSUBPS ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<float> vhsub(Vector256<float> x, Vector256<float> y)
            => HorizontalSubtract(x, y);

        /// <summary>
        /// __m256d _mm256_hsub_pd (__m256d a, __m256d b) VHSUBPD ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<double> vhsub(Vector256<double> x, Vector256<double> y)
            => HorizontalSubtract(x, y);
    }
}