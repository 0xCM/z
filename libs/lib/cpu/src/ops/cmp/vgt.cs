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

    partial struct cpu
    {
        /// <summary>
        /// __m128i _mm_cmpgt_epi8 (__m128i a, __m128i b) PCMPGTB xmm, xmm/m128
        /// Determines whether component values the left vector are larger than the
        /// corresponding components the right vector. When a left value is larger
        /// than a right value, the corresponding component the result vector
        /// will have all bits enabled; otherwise, all bits the component are disabled
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Gt]
        public static Vector128<sbyte> vgt(Vector128<sbyte> x, Vector128<sbyte> y)
            => CompareGreaterThan(x,y);

        /// <summary>
        /// __m128i _mm_cmpgt_epi8 (__m128i a, __m128i b) PCMPGTB xmm, xmm/m128
        /// Determines whether component values the left vector are larger than the
        /// corresponding components the right vector. When a left value is larger
        /// than a right value, the corresponding component the result vector
        /// will have all bits enabled; otherwise, all bits the component are disabled
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Gt]
        public static Vector128<byte> vgt(Vector128<byte> x, Vector128<byte> y)
        {
            var mask = vbroadcast(n128,CmpMask8u);
            var mx = vxor(x,mask).AsSByte();
            var my = vxor(y,mask).AsSByte();
            return CompareGreaterThan(mx,my).AsByte();
        }

        /// <summary>
        /// Determines whether component values the left vector are larger than the
        /// corresponding components the right vector. When a left value is larger
        /// than a right value, the corresponding component the result vector
        /// will have all bits enabled; otherwise, all bits the component are disabled
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Gt]
        public static Vector128<short> vgt(Vector128<short> x, Vector128<short> y)
            => CompareGreaterThan(x,y);

        /// <summary>
        /// Determines whether component values the left vector are larger than the
        /// corresponding components the right vector. When a left value is larger
        /// than a right value, the corresponding component the result vector
        /// will have all bits enabled; otherwise, all bits the component are disabled
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Gt]
        public static Vector128<ushort> vgt(Vector128<ushort> x, Vector128<ushort> y)
        {
            var mask = vbroadcast(n128,CmpMask16u);
            var mx = vxor(x,mask).AsInt16();
            var my = vxor(y,mask).AsInt16();
            return CompareGreaterThan(mx,my).AsUInt16();
        }

        /// <summary>
        /// Determines whether component values the left vector are larger than the
        /// corresponding components the right vector. When a left value is larger
        /// than a right value, the corresponding component the result vector
        /// will have all bits enabled; otherwise, all bits the component are disabled
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Gt]
        public static Vector128<int> vgt(Vector128<int> x, Vector128<int> y)
            => CompareGreaterThan(x,y);

        /// <summary>
        /// Determines whether component values the left vector are larger than the
        /// corresponding components the right vector. When a left value is larger
        /// than a right value, the corresponding component the result vector
        /// will have all bits enabled; otherwise, all bits the component are disabled
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Gt]
        public static Vector128<uint> vgt(Vector128<uint> x, Vector128<uint> y)
        {
            var mask = vbroadcast(n128, CmpMask32u);
            var mx = vxor(x,mask).AsInt32();
            var my = vxor(y,mask).AsInt32();
            return CompareGreaterThan(mx,my).AsUInt32();
        }

        /// <summary>
        /// Determines whether component values the left vector are larger than the
        /// corresponding components the right vector. When a left value is larger
        /// than a right value, the corresponding component the result vector
        /// will have all bits enabled; otherwise, all bits the component are disabled
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Gt]
        public static Vector128<long> vgt(Vector128<long> x, Vector128<long> y)
        {
            var a = vinsert(x,default, LaneIndex.L0);
            var b = vinsert(y,default, LaneIndex.L0);
            return vlo(vgt(a,b));
        }

        /// <summary>
        /// Determines whether component values the left vector are larger than the
        /// corresponding components the right vector. When a left value is larger
        /// than a right value, the corresponding component the result vector
        /// will have all bits enabled; otherwise, all bits the component are disabled
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline),Gt]
        public static Vector128<ulong> vgt(Vector128<ulong> x, Vector128<ulong> y)
        {
            var mask = vbroadcast(n128, CmpMask64u);
            var mx = v64i(vxor(x,mask));
            var my = v64i(vxor(y,mask));
            return v64u(vgt(mx,my));
        }

        /// <summary>
        /// __m256i _mm256_cmpgt_epi8 (__m256i a, __m256i b) VPCMPGTB ymm, ymm, ymm/m256
        /// Determines whether component values the left vector are larger than the
        /// corresponding components the right vector. When a left value is larger
        /// than a right value, the corresponding component the result vector
        /// will have all bits enabled; otherwise, all bits the component are disabled
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Gt]
        public static Vector256<sbyte> vgt(Vector256<sbyte> x, Vector256<sbyte> y)
            => CompareGreaterThan(x,y);

        /// <summary>
        /// __m256i _mm256_cmpgt_epi8 (__m256i a, __m256i b) VPCMPGTB ymm, ymm, ymm/m256
        /// Determines whether component values the left vector are larger than the
        /// corresponding components the right vector. When a left value is larger
        /// than a right value, the corresponding component the result vector
        /// will have all bits enabled; otherwise, all bits the component are disabled
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Gt]
        public static Vector256<byte> vgt(Vector256<byte> x, Vector256<byte> y)
        {
            var mask = vbroadcast(n256, CmpMask8u);
            var mx = vxor(x,mask).AsSByte();
            var my = vxor(y,mask).AsSByte();
            return CompareGreaterThan(mx,my).AsByte();
        }

        /// <summary>
        /// Determines whether component values the left vector are larger than the
        /// corresponding components the right vector. When a left value is larger
        /// than a right value, the corresponding component the result vector
        /// will have all bits enabled; otherwise, all bits the component are disabled
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Gt]
        public static Vector256<short> vgt(Vector256<short> x, Vector256<short> y)
            => CompareGreaterThan(x,y);

        /// <summary>
        /// Determines whether component values the left vector are larger than the
        /// corresponding components the right vector. When a left value is larger
        /// than a right value, the corresponding component the result vector
        /// will have all bits enabled; otherwise, all bits the component are disabled
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Gt]
        public static Vector256<ushort> vgt(Vector256<ushort> x, Vector256<ushort> y)
        {
            var mask = vbroadcast(n256,CmpMask16u);
            var mx = vxor(x,mask).AsInt16();
            var my = vxor(y,mask).AsInt16();
            return CompareGreaterThan(mx,my).AsUInt16();
        }

        /// <summary>
        /// __m256i _mm256_cmpgt_epi32 (__m256i a, __m256i b) VPCMPGTD ymm, ymm, ymm/m256
        /// Determines whether component values the left vector are larger than the
        /// corresponding components the right vector. When a left value is larger
        /// than a right value, the corresponding component the result vector
        /// will have all bits enabled; otherwise, all bits the component are disabled
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Gt]
        public static Vector256<int> vgt(Vector256<int> x, Vector256<int> y)
            => CompareGreaterThan(x,y);

        /// <summary>
        /// __m256i _mm256_cmpgt_epi32 (__m256i a, __m256i b) VPCMPGTD ymm, ymm, ymm/m256
        /// Determines whether component values the left vector are larger than the
        /// corresponding components the right vector. When a left value is larger
        /// than a right value, the corresponding component the result vector
        /// will have all bits enabled; otherwise, all bits the component are disabled
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Gt]
        public static Vector256<uint> vgt(Vector256<uint> x, Vector256<uint> y)
        {
            var mask = gcpu.vbroadcast<uint>(n256, CmpMask32u);
            var mx = vxor(x, mask).AsInt32();
            var my = vxor(y, mask).AsInt32();
            return CompareGreaterThan(mx,my).AsUInt32();
        }

        /// <summary>
        ///  __m256i _mm256_cmpgt_epi64 (__m256i a, __m256i b) VPCMPGTQ ymm, ymm, ymm/m256
        /// Determines whether component values the left vector are larger than the
        /// corresponding components the right vector. When a left value is larger
        /// than a right value, the corresponding component the result vector
        /// will have all bits enabled; otherwise, all bits the component are disabled
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Gt]
        public static Vector256<long> vgt(Vector256<long> x, Vector256<long> y)
            => CompareGreaterThan(x,y);

        /// <summary>
        ///  __m256i _mm256_cmpgt_epi64 (__m256i a, __m256i b) VPCMPGTQ ymm, ymm, ymm/m256
        /// Determines whether component values the left vector are larger than the
        /// corresponding components the right vector. When a left value is larger
        /// than a right value, the corresponding component the result vector
        /// will have all bits enabled; otherwise, all bits the component are disabled
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Gt]
        public static Vector256<ulong> vgt(Vector256<ulong> x, Vector256<ulong> y)
        {
            var mask = vbroadcast(n256, CmpMask64u);
            return v64u(CompareGreaterThan(v64i(vxor(x,mask)), v64i(vxor(y,mask))));
        }

        /// <summary>
        /// __m128 _mm_cmpgt_ps (__m128 a, __m128 b) CMPPS xmm, xmm/m128, imm8(6)
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<float> vgt(Vector128<float> x, Vector128<float> y)
            => CompareGreaterThan(x, y);

        /// <summary>
        /// __m128d _mm_cmpgt_pd (__m128d a, __m128d b) CMPPD xmm, xmm/m128, imm8(6)
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<double> vgt(Vector128<double> x, Vector128<double> y)
            => CompareGreaterThan(x, y);

        /// <summary>
        /// __m256 _mm256_cmp_ps (__m256 a, __m256 b, const int imm8) VCMPPS ymm, ymm, ymm/m256, imm8
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<float> vgt(Vector256<float> x, Vector256<float> y)
            => Compare(x, y, FloatComparisonMode.OrderedGreaterThanNonSignaling);

        /// <summary>
        /// __m256d _mm256_cmp_pd (__m256d a, __m256d b, const int imm8) VCMPPD ymm, ymm,ymm/m256, imm8
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<double> vgt(Vector256<double> x, Vector256<double> y)
            => Compare(x, y, FloatComparisonMode.OrderedGreaterThanNonSignaling);

        /// <summary>
        /// __m128 _mm_cmpge_ps (__m128 a, __m128 b) CMPPS xmm, xmm/m128, imm8(5)
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<float> vgteq(Vector128<float> x, Vector128<float> y)
            => CompareGreaterThanOrEqual(x, y);

        /// <summary>
        /// __m128d _mm_cmpge_pd (__m128d a, __m128d b) CMPPD xmm, xmm/m128, imm8(5)
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<double> vgteq(Vector128<double> x, Vector128<double> y)
            => CompareGreaterThanOrEqual(x, y);

        /// <summary>
        /// __m256 _mm256_cmp_ps (__m256 a, __m256 b, const int imm8) VCMPPS ymm, ymm, ymm/m256, imm8
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<float> vgteq(Vector256<float> x, Vector256<float> y)
            => Compare(x, y, FloatComparisonMode.OrderedGreaterThanOrEqualNonSignaling);

        /// <summary>
        /// __m256d _mm256_cmp_pd (__m256d a, __m256d b, const int imm8) VCMPPD ymm, ymm,ymm/m256, imm8
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<double> vgteq(Vector256<double> x, Vector256<double> y)
            => Compare(x, y, FloatComparisonMode.OrderedGreaterThanOrEqualNonSignaling);

        const byte CmpMask8u = 0x80;

        const ushort CmpMask16u = 0x8000;

        const uint CmpMask32u = 0x80000000u;

        const ulong CmpMask64u = 0x8000000000000000ul;
    }
}