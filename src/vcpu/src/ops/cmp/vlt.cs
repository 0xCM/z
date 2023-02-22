//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.Intrinsics.X86;

    using static System.Runtime.Intrinsics.X86.Sse;
    using static System.Runtime.Intrinsics.X86.Sse2;
    using static System.Runtime.Intrinsics.X86.Avx;
    using static System.Runtime.Intrinsics.X86.Avx2;
    using static BitMaskLiterals;

    partial class vcpu
    {
        /// <summary>
        /// __m128i _mm_cmplt_epi8 (__m128i a, __m128i b)PCMPGTB xmm, xmm/m128
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Lt]
        public static Vector128<sbyte> vlt(Vector128<sbyte> x, Vector128<sbyte> y)
            => CompareLessThan(x,y);

        /// <summary>
        /// __m128i _mm_cmplt_epi8 (__m128i a, __m128i b)PCMPGTB xmm, xmm/m128
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Lt]
        public static Vector128<byte> vlt(Vector128<byte> x, Vector128<byte> y)
        {
            var mask = vbroadcast(w128, SignMask8);
            var mx = v8i(vxor(x,mask));
            var my = v8i(vxor(y,mask));
            return v8u(CompareLessThan(mx,my));
        }

        /// <summary>
        /// __m128i _mm_cmplt_epi16 (__m128i a, __m128i b)PCMPGTW xmm, xmm/m128
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Lt]
        public static Vector128<short> vlt(Vector128<short> x, Vector128<short> y)
            => CompareLessThan(x,y);

        /// <summary>
        /// __m128i _mm_cmplt_epi16 (__m128i a, __m128i b)PCMPGTW xmm, xmm/m128
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Lt]
        public static Vector128<ushort> vlt(Vector128<ushort> x, Vector128<ushort> y)
        {
            var mask = vbroadcast(w128, SignMask16);
            var mx = v16i(vxor(x,mask));
            var my = v16i(vxor(y,mask));
            return v16u(CompareLessThan(mx,my));
        }

        /// <summary>
        /// __m128i _mm_vcmplt_epi32 (__m128i a, __m128i b)PCMPGTD xmm, xmm/m128
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Lt]
        public static Vector128<int> vlt(Vector128<int> x, Vector128<int> y)
            => CompareGreaterThan(y,x);

        /// <summary>
        /// __m128i _mm_vcmplt_epi32 (__m128i a, __m128i b)PCMPGTD xmm, xmm/m128
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Lt]
        public static Vector128<uint> vlt(Vector128<uint> x, Vector128<uint> y)
        {
            var mask = vbroadcast(w128, SignMask32);
            return v32u(CompareLessThan(v32i(vxor(x,mask)), v32i(vxor(y,mask))));
        }

        /// <summary>
        /// __m256i _mm256_cmpgt_epi64 (__m256i a, __m256i b) VPCMPGTQ ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Lt]
        public static Vector128<long> vlt(Vector128<long> x, Vector128<long> y)
        {
            var a = vconcat(x,y);
            var b = vswaphl(a);
            return vlo(vlt(a,b));
        }

        /// <summary>
        /// __m256i _mm256_cmpgt_epi64 (__m256i a, __m256i b) VPCMPGTQ ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Lt]
        public static Vector128<ulong> vlt(Vector128<ulong> x, Vector128<ulong> y)
        {
            var a = vconcat(x,y);
            var b = vswaphl(a);
            return vlo(vlt(a,b));
        }

        /// <summary>
        ///  __m256i _mm256_cmpgt_epi8 (__m256i a, __m256i b) VPCMPGTB ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Lt]
        public static Vector256<sbyte> vlt(Vector256<sbyte> x, Vector256<sbyte> y)
            => CompareGreaterThan(y,x);

        /// <summary>
        ///  __m256i _mm256_cmpgt_epi8 (__m256i a, __m256i b) VPCMPGTB ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Lt]
        public static Vector256<byte> vlt(Vector256<byte> x, Vector256<byte> y)
        {
            var mask = vbroadcast(n256, SignMask8);
            return v8u(vlt(v8i(vxor(x,mask)), v8i(vxor(y,mask))));
        }

        /// <summary>
        /// __m256i _mm256_cmpgt_epi16 (__m256i a, __m256i b) VPCMPGTW ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Lt]
        public static Vector256<short> vlt(Vector256<short> x, Vector256<short> y)
            => CompareGreaterThan(y,x);

        /// <summary>
        /// __m256i _mm256_cmpgt_epi16 (__m256i a, __m256i b) VPCMPGTW ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Lt]
        public static Vector256<ushort> vlt(Vector256<ushort> x, Vector256<ushort> y)
        {
            var mask = vbroadcast(n256, SignMask16);
            return v16u(vlt(v16i(vxor(x,mask)), v16i(vxor(y,mask))));
        }

        /// <summary>
        /// __m256i _mm256_cmpgt_epi32 (__m256i a, __m256i b) VPCMPGTD ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Lt]
        public static Vector256<int> vlt(Vector256<int> x, Vector256<int> y)
            => CompareGreaterThan(y,x);

        /// <summary>
        /// __m256i _mm256_cmpgt_epi32 (__m256i a, __m256i b) VPCMPGTD ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Lt]
        public static Vector256<uint> vlt(Vector256<uint> x, Vector256<uint> y)
        {
            var mask = vbroadcast(n256, SignMask32);
            return v32u(vlt(v32i(vxor(x,mask)), v32i(vxor(y,mask))));
        }

        /// <summary>
        /// __m256i _mm256_cmpgt_epi64 (__m256i a, __m256i b) VPCMPGTQ ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Lt]
        public static Vector256<long> vlt(Vector256<long> x, Vector256<long> y)
            => CompareGreaterThan(y,x);

        /// <summary>
        /// __m256i _mm256_cmpgt_epi64 (__m256i a, __m256i b) VPCMPGTQ ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Lt]
        public static Vector256<ulong> vlt(Vector256<ulong> x, Vector256<ulong> y)
        {
            var mask = vbroadcast(n256, SignMask64);
            return v64u(vlt(v64i(vxor(x,mask)),v64i(vxor(y,mask))));
        }

        /// <summary>
        ///  __m128 _mm_cmplt_ps (__m128 a, __m128 b) CMPPS xmm, xmm/m128, imm8(1)
        /// </summary>
        /// <param name="lhs">The left vector</param>
        /// <param name="rhs">The right vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<float> vlt(Vector128<float> lhs, Vector128<float> rhs)
            => CompareLessThan(lhs, rhs);

        /// <summary>
        /// __m128d _mm_cmplt_pd (__m128d a, __m128d b) CMPPD xmm, xmm/m128, imm8(1)
        /// </summary>
        /// <param name="lhs">The left vector</param>
        /// <param name="rhs">The right vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<double> vlt(Vector128<double> lhs, Vector128<double> rhs)
            => CompareLessThan(lhs, rhs);

        /// <summary>
        /// __m256 _mm256_cmp_ps (__m256 a, __m256 b, const int imm8) VCMPPS ymm, ymm, ymm/m256, imm8
        /// </summary>
        /// <param name="lhs">The left vector</param>
        /// <param name="rhs">The right vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<float> vlt(Vector256<float> lhs, Vector256<float> rhs)
            => Compare(lhs, rhs, FloatComparisonMode.OrderedLessThanNonSignaling);

        /// <summary>
        /// __m256d _mm256_cmp_pd (__m256d a, __m256d b, const int imm8) VCMPPD ymm, ymm, ymm/m256, imm8
        /// </summary>
        /// <param name="lhs">The left vector</param>
        /// <param name="rhs">The right vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<double> vlt(Vector256<double> lhs, Vector256<double> rhs)
            => Compare(lhs, rhs,FloatComparisonMode.OrderedLessThanNonSignaling);
    }
}