//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.Intrinsics.X86.Avx;
    using static System.Runtime.Intrinsics.X86.Avx2;
    using static System.Runtime.Intrinsics.X86.Sse41;

    partial class vcpu
    {
        /// <summary>
        /// __m128i _mm_blendv_epi8 (__m128i a, __m128i b, __m128i mask) PBLENDVB xmm, xmm/m128, xmm
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <param name="spec">The blend specification</param>
        [MethodImpl(Inline), Op]
        public static Vector128<byte> vblendv(Vector128<byte> x, Vector128<byte> y, Vector128<byte> spec)
            =>  BlendVariable(x, y, spec);

        /// <summary>
        /// __m128i _mm_blendv_epi8 (__m128i a, __m128i b, __m128i mask) PBLENDVB xmm, xmm/m128, xmm
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <param name="spec">The blend specification</param>
        [MethodImpl(Inline), Op]
        public static Vector128<sbyte> vblendv(Vector128<sbyte> x, Vector128<sbyte> y, Vector128<sbyte> spec)
            => BlendVariable(x, y, spec);

        /// <summary>
        /// __m128i _mm_blendv_epi8 (__m128i a, __m128i b, __m128i mask) PBLENDVB xmm, xmm/m128, xmm
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <param name="spec">The blend specification</param>
        [MethodImpl(Inline), Op]
        public static Vector128<sbyte> vblendv(Vector128<sbyte> x, Vector128<sbyte> y, Vector128<byte> spec)
            => BlendVariable(x, y, v8i(spec));

        /// <summary>
        /// __m128i _mm_blendv_epi8 (__m128i a, __m128i b, __m128i mask)PBLENDVB xmm, xmm/m128,xmm
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <param name="spec">The blend specification</param>
        [MethodImpl(Inline), Op]
        public static Vector128<short> vblendv(Vector128<short> x, Vector128<short> y, Vector128<short> spec)
            => BlendVariable(x,y,spec);

        /// <summary>
        /// __m128i _mm_blendv_epi8 (__m128i a, __m128i b, __m128i mask) PBLENDVB xmm, xmm/m128, xmm
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <param name="spec">The blend specification</param>
        [MethodImpl(Inline), Op]
        public static Vector128<short> vblendv(Vector128<short> x, Vector128<short> y, Vector128<byte> spec)
            => BlendVariable(x, y, v16i(spec));

        /// <summary>
        /// __m128i _mm_blendv_epi8 (__m128i a, __m128i b, __m128i mask) PBLENDVB xmm, xmm/m128, xmm
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <param name="spec">The blend specification</param>
        [MethodImpl(Inline), Op]
        public static Vector128<ushort> vblendv(Vector128<ushort> x, Vector128<ushort> y, Vector128<byte> spec)
            => BlendVariable(x, y, v16u(spec));

        /// <summary>
        /// __m128i _mm_blendv_epi8 (__m128i a, __m128i b, __m128i mask) PBLENDVB xmm, xmm/m128, xmm
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <param name="spec">The blend specification</param>
        [MethodImpl(Inline), Op]
        public static Vector128<int> vblendv(Vector128<int> x, Vector128<int> y, Vector128<byte> spec)
            => BlendVariable(x, y, v32i(spec));

        /// <summary>
        /// __m128i _mm_blendv_epi8 (__m128i a, __m128i b, __m128i mask) PBLENDVB xmm, xmm/m128, xmm
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <param name="spec">The blend specification</param>
        [MethodImpl(Inline), Op]
        public static Vector128<uint> vblendv(Vector128<uint> x, Vector128<uint> y, Vector128<byte> spec)
            => BlendVariable(x, y, v32u(spec));


        /// <summary>
        /// __m128i _mm_blendv_epi8 (__m128i a, __m128i b, __m128i mask) PBLENDVB xmm, xmm/m128,xmm
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <param name="spec">The blend specification</param>
        [MethodImpl(Inline), Op]
        public static Vector128<ushort> vblendv(Vector128<ushort> x, Vector128<ushort> y, Vector128<ushort> spec)
            => BlendVariable(x,y,spec);

        /// <summary>
        /// __m128i _mm_blendv_epi8 (__m128i a, __m128i b, __m128i mask) PBLENDVB xmm, xmm/m128,xmm
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <param name="spec">The blend specification</param>
        [MethodImpl(Inline), Op]
        public static Vector128<int> vblendv(Vector128<int> x, Vector128<int> y, Vector128<int> spec)
            => BlendVariable(x,y,spec);

        /// <summary>
        /// __m128i _mm_blendv_epi8 (__m128i a, __m128i b, __m128i mask) PBLENDVB xmm, xmm/m128,xmm
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <param name="spec">The blend specification</param>
        [MethodImpl(Inline), Op]
        public static Vector128<uint> vblendv(Vector128<uint> x, Vector128<uint> y, Vector128<uint> spec)
            => BlendVariable(x,y,spec);

        /// <summary>
        /// __m128i _mm_blendv_epi8 (__m128i a, __m128i b, __m128i mask) PBLENDVB xmm, xmm/m128,xmm
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <param name="spec">The blend specification</param>
        [MethodImpl(Inline), Op]
        public static Vector128<long> vblendv(Vector128<long> x, Vector128<long> y, Vector128<long> spec)
            => BlendVariable(x,y,spec);

        /// <summary>
        /// __m128i _mm_blendv_epi8 (__m128i a, __m128i b, __m128i mask) PBLENDVB xmm, xmm/m128,xmm
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <param name="spec">The blend specification</param>
        [MethodImpl(Inline), Op]
        public static Vector128<ulong> vblendv(Vector128<ulong> x, Vector128<ulong> y, Vector128<ulong> spec)
            => BlendVariable(x,y,spec);

        /// <summary>
        /// __m128 _mm_blendv_ps (__m128 a, __m128 b, __m128 mask) BLENDVPS xmm, xmm/m128,xmm0
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <param name="spec">The blend specification</param>
        [MethodImpl(Inline), Op]
        public static Vector128<float> vblendv(Vector128<float> x, Vector128<float> y, Vector128<float> spec)
            => BlendVariable(x,y,spec);

        /// <summary>
        /// _m128d _mm_blendv_pd (__m128d a, __m128d b, __m128d mask) BLENDVPD xmm, xmm/m128, xmm0
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <param name="spec">The blend specification</param>
        [MethodImpl(Inline), Op]
        public static Vector128<double> vblendv(Vector128<double> x, Vector128<double> y, Vector128<double> spec)
            => BlendVariable(x,y,spec);

        /// <summary>
        /// __m128 _mm_blendv_ps (__m128 a, __m128 b, __m128 mask) BLENDVPS xmm, xmm/m128,xmm0
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <param name="spec">The blend specification</param>
        [MethodImpl(Inline), Op]
        public static Vector128<float> vblend4x32(Vector128<float> x, Vector128<float> y, Vector128<float> spec)
            =>  BlendVariable(x, y, spec);

        /// <summary>
        /// __m128d _mm_blendv_pd (__m128d a, __m128d b, __m128d mask) BLENDVPD xmm, xmm/m128,xmm0
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <param name="spec">The blend specification</param>
        [MethodImpl(Inline), Op]
        public static Vector128<double> vblend2x64(Vector128<double> x, Vector128<double> y, Vector128<double> spec)
            =>  BlendVariable(x, y, spec);

        /// <summary>
        /// __m256 _mm256_blendv_ps (__m256 a, __m256 b, __m256 mask) VBLENDVPS ymm, ymm, ymm/m256, ymm
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <param name="spec">The blend specification</param>
        [MethodImpl(Inline), Op]
        public static Vector256<float> vblend8x32(Vector256<float> x, Vector256<float> y, Vector256<float> spec)
            => BlendVariable(x, y, spec);

        /// <summary>
        /// __m256 _mm256_blendv_ps (__m256 a, __m256 b, __m256 mask) VBLENDVPS ymm, ymm, ymm/m256, ymm
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <param name="spec">The blend specification</param>
        [MethodImpl(Inline), Op]
        public static Vector256<double> vblend4x64(Vector256<double> x, Vector256<double> y, Vector256<double> spec)
            => BlendVariable(x, y, spec);

        /// <summary>
        /// __m128i _mm_blendv_epi8 (__m128i a, __m128i b, __m128i mask) PBLENDVB xmm, xmm/m128, xmm
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <param name="spec">The blend specification</param>
        [MethodImpl(Inline), Op]
        public static Vector256<byte> vblendv(Vector256<byte> x, Vector256<byte> y, Vector256<byte> spec)
            =>  BlendVariable(x, y, spec);

        /// <summary>
        /// __m128i _mm_blendv_epi8 (__m128i a, __m128i b, __m128i mask)PBLENDVB xmm, xmm/m128, xmm
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <param name="spec">The blend specification</param>
        [MethodImpl(Inline), Op]
        public static Vector256<sbyte> vblendv(Vector256<sbyte> x, Vector256<sbyte> y, Vector256<sbyte> spec)
            => BlendVariable(x, y, spec);

        /// <summary>
        /// __m256i _mm256_blendv_epi8 (__m256i a, __m256i b, __m256i mask) VPBLENDVB ymm, ymm, ymm/m256, ymm
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <param name="spec">The blend specification</param>
        [MethodImpl(Inline), Op]
        public static Vector256<short> vblendv(Vector256<short> x, Vector256<short> y, Vector256<short> spec)
            => BlendVariable(x,y,spec);

        /// <summary>
        /// __m256i _mm256_blendv_epi8 (__m256i a, __m256i b, __m256i mask)VPBLENDVB ymm, ymm, ymm/m256, ymm
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <param name="spec">The blend specification</param>
        [MethodImpl(Inline), Op]
        public static Vector256<ushort> vblendv(Vector256<ushort> x, Vector256<ushort> y, Vector256<ushort> spec)
            => BlendVariable(x,y,spec);

        /// <summary>
        /// __m256i _mm256_blendv_epi8 (__m256i a, __m256i b, __m256i mask)VPBLENDVB ymm, ymm, ymm/m256, ymm
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <param name="spec">The blend specification</param>
        [MethodImpl(Inline), Op]
        public static Vector256<int> vblendv(Vector256<int> x, Vector256<int> y, Vector256<int> spec)
            => BlendVariable(x,y,spec);

        /// <summary>
        /// __m256i _mm256_blendv_epi8 (__m256i a, __m256i b, __m256i mask)VPBLENDVB ymm, ymm, ymm/m256, ymm
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <param name="spec">The blend specification</param>
        [MethodImpl(Inline), Op]
        public static Vector256<uint> vblendv(Vector256<uint> x, Vector256<uint> y, Vector256<uint> spec)
            => BlendVariable(x,y,spec);

        /// <summary>
        /// __m256i _mm256_blendv_epi8 (__m256i a, __m256i b, __m256i mask)VPBLENDVB ymm, ymm, ymm/m256, ymm
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <param name="spec">The blend specification</param>
        [MethodImpl(Inline), Op]
        public static Vector256<long> vblendv(Vector256<long> x, Vector256<long> y, Vector256<long> spec)
            => BlendVariable(x,y,spec);

        /// <summary>
        /// __m256i _mm256_blendv_epi8 (__m256i a, __m256i b, __m256i mask) VPBLENDVB ymm, ymm, ymm/m256, ymm
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <param name="spec">The blend specification</param>
        [MethodImpl(Inline), Op]
        public static Vector256<ulong> vblendv(Vector256<ulong> x, Vector256<ulong> y, Vector256<ulong> spec)
            => BlendVariable(x,y,spec);

        /// <summary>
        /// __m256 _mm256_blendv_ps (__m256 a, __m256 b, __m256 mask) VBLENDVPS ymm, ymm, ymm/m256, ymm
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <param name="spec">The blend specification</param>
        [MethodImpl(Inline), Op]
        public static Vector256<float> vblendv(Vector256<float> x, Vector256<float> y, Vector256<float> spec)
            => BlendVariable(x,y,spec);

        /// <summary>
        /// __m256d _mm256_blendv_pd (__m256d a, __m256d b, __m256d mask) VBLENDVPD ymm, ymm,ymm/m256, ymm
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <param name="spec">The blend specification</param>
        [MethodImpl(Inline), Op]
        public static Vector256<double> vblendv(Vector256<double> x, Vector256<double> y, Vector256<double> spec)
            => BlendVariable(x,y,spec);

        /// <summary>
        /// __m128i _mm_blendv_epi8 (__m128i a, __m128i b, __m128i mask) PBLENDVB xmm, xmm/m128, xmm
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <param name="spec">The blend specification</param>
        [MethodImpl(Inline), Op]
        public static Vector128<long> vblendv(Vector128<long> x, Vector128<long> y, Vector128<byte> spec)
            => BlendVariable(x, y, v64i(spec));

        /// <summary>
        /// __m128i _mm_blendv_epi8 (__m128i a, __m128i b, __m128i mask) PBLENDVB xmm, xmm/m128, xmm
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <param name="spec">The blend specification</param>
        [MethodImpl(Inline), Op]
        public static Vector128<ulong> vblendv(Vector128<ulong> x, Vector128<ulong> y, Vector128<byte> spec)
            => BlendVariable(x, y, v64u(spec));

        /// <summary>
        /// __m256i _mm256_blendv_epi8 (__m256i a, __m256i b, __m256i mask) VPBLENDVB ymm,ymm, ymm/m256, ymm
        /// Forms a vector z[i] = testbit(spec[i],7) ? x[i] : y[i] where i = 0,...31
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <param name="spec">The blend specification</param>
        /// <remarks>https://www.felixcloutier.com/x86/pblendvb</remarks>
        [MethodImpl(Inline), Op]
        public static Vector256<sbyte> vblendv(Vector256<sbyte> x, Vector256<sbyte> y, Vector256<byte> spec)
            => BlendVariable(x, y, v8i(spec));

        /// <summary>
        /// __m256i _mm256_blendv_epi8 (__m256i a, __m256i b, __m256i mask) VPBLENDVB ymm,ymm, ymm/m256, ymm
        /// Forms a vector z[i] = testbit(spec[i],7) ? x[i] : y[i] where i = 0,...31
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <param name="spec">The blend specification</param>
        /// <remarks>https://www.felixcloutier.com/x86/pblendvb</remarks>
        [MethodImpl(Inline), Op]
        public static Vector256<short> vblendv(Vector256<short> x, Vector256<short> y, Vector256<byte> spec)
            => BlendVariable(x, y, v16i(spec));

        /// <summary>
        /// __m256i _mm256_blendv_epi8 (__m256i a, __m256i b, __m256i mask) VPBLENDVB ymm,ymm, ymm/m256, ymm
        /// Forms a vector z[i] = testbit(spec[i],7) ? x[i] : y[i] where i = 0,...31
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <param name="spec">The blend specification</param>
        /// <remarks>https://www.felixcloutier.com/x86/pblendvb</remarks>
        [MethodImpl(Inline), Op]
        public static Vector256<ushort> vblendv(Vector256<ushort> x, Vector256<ushort> y, Vector256<byte> spec)
            => BlendVariable(x, y, v16u(spec));

        /// <summary>
        /// __m256i _mm256_blendv_epi8 (__m256i a, __m256i b, __m256i mask) VPBLENDVB ymm,ymm, ymm/m256, ymm
        /// Forms a vector z[i] = testbit(spec[i],7) ? x[i] : y[i] where i = 0,...31
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <param name="spec">The blend specification</param>
        /// <remarks>https://www.felixcloutier.com/x86/pblendvb</remarks>
        [MethodImpl(Inline), Op]
        public static Vector256<int> vblendv(Vector256<int> x, Vector256<int> y, Vector256<byte> spec)
            => BlendVariable(x, y, v32i(spec));

        /// <summary>
        /// __m256i _mm256_blendv_epi8 (__m256i a, __m256i b, __m256i mask) VPBLENDVB ymm,ymm, ymm/m256, ymm
        /// Forms a vector z[i] = testbit(spec[i],7) ? x[i] : y[i] where i = 0,...31
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <param name="spec">The blend specification</param>
        /// <remarks>https://www.felixcloutier.com/x86/pblendvb</remarks>
        [MethodImpl(Inline), Op]
        public static Vector256<uint> vblendv(Vector256<uint> x, Vector256<uint> y, Vector256<byte> spec)
            => BlendVariable(x, y, v32u(spec));

        /// <summary>
        /// __m256i _mm256_blendv_epi8 (__m256i a, __m256i b, __m256i mask) VPBLENDVB ymm,ymm, ymm/m256, ymm
        /// Forms a vector z[i] = testbit(spec[i],7) ? x[i] : y[i] where i = 0,...31
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <param name="spec">The blend specification</param>
        /// <remarks>https://www.felixcloutier.com/x86/pblendvb</remarks>
        [MethodImpl(Inline), Op]
        public static Vector256<long> vblendv(Vector256<long> x, Vector256<long> y, Vector256<byte> spec)
            => BlendVariable(x, y, v64i(spec));

        /// <summary>
        /// __m256i _mm256_blendv_epi8 (__m256i a, __m256i b, __m256i mask) VPBLENDVB ymm,ymm, ymm/m256, ymm
        /// Forms a vector z[i] = testbit(spec[i],7) ? x[i] : y[i] where i = 0,...31
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <param name="spec">The blend specification</param>
        /// <remarks>https://www.felixcloutier.com/x86/pblendvb</remarks>
        [MethodImpl(Inline), Op]
        public static Vector256<ulong> vblendv(Vector256<ulong> x, Vector256<ulong> y, Vector256<byte> spec)
            => BlendVariable(x, y, v64u(spec));
    }
}