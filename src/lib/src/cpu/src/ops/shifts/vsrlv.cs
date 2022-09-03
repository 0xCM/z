//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Intrinsics;

    using static System.Runtime.Intrinsics.X86.Avx2;
    using static Root;

    partial struct cpu
    {
        /// <summary>
        /// __m256i _mm256_srlv_epi32 (__m256i a, __m256i count) VPSRLVD ymm, ymm, ymm/m256
        /// Computes z[i] := x[i] >> offsets[i] for i = 0...7
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="counts">The offset vector</param>
        [MethodImpl(Inline), Srlv]
        public static Vector256<int> vsrlv(Vector256<int> x, Vector256<int> counts)
            => ShiftRightLogicalVariable(x, v32u(counts));

        /// <summary>
        /// __m256i _mm256_srlv_epi32 (__m256i a, __m256i count) VPSRLVD ymm, ymm, ymm/m256
        /// Computes z[i] := x[i] >> offsets[i] for i = 0...7
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="counts">The offset vector</param>
        [MethodImpl(Inline), Srlv]
        public static Vector256<uint> vsrlv(Vector256<uint> x, Vector256<uint> counts)
            => ShiftRightLogicalVariable(x, counts);

        /// <summary>
        /// __m256i _mm256_srlv_epi64 (__m256i a, __m256i count) VPSRLVQ ymm, ymm, ymm/m256
        /// Computes z[i] := x[i] >> offsets[i] for i = 0...3
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="counts">The offset vector</param>
        [MethodImpl(Inline), Srlv]
        public static Vector256<long> vsrlv(Vector256<long> x, Vector256<long> counts)
            => ShiftRightLogicalVariable(x, v64u(counts));

        /// <summary>
        ///  __m256i _mm256_srlv_epi64 (__m256i a, __m256i count) VPSRLVQ ymm, ymm, ymm/m256
        /// Computes z[i] := x[i] >> offsets[i] for i = 0...3
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="counts">The offset vector</param>
        [MethodImpl(Inline), Srlv]
        public static Vector256<ulong> vsrlv(Vector256<ulong> x, Vector256<ulong> counts)
            => ShiftRightLogicalVariable(x, counts);

        /// <summary>
        /// Computes z[i] := x[i] >> s[i] for i = 0..15
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="counts">The offset vector</param>
        [MethodImpl(Inline), Srlv]
        public static Vector128<sbyte> vsrlv(Vector128<sbyte> src, Vector128<sbyte> counts)
        {
            var x = vpack.vinflate256x16i(src);
            var y = vpack.vinflate256x16i(counts);
            return vpack.vpack128x8i(vsrlv(x,y));
        }

        /// <summary>
        /// Computes z[i] := x[i] >> s[i] for i = 0..15
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="counts">The offset vector</param>
        [MethodImpl(Inline), Srlv]
        public static Vector128<byte> vsrlv(Vector128<byte> src, Vector128<byte> counts)
        {
            var x = vpack.vinflate256x16u(src);
            var y = vpack.vinflate256x16u(counts);
            return vpack.vpack128x8u(vsrlv(x,y));
        }

        /// <summary>
        /// Computes z[i] := x[i] >> s[i] for i = 0..7
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="counts">The offset vector</param>
        [MethodImpl(Inline), Srlv]
        public static Vector128<short> vsrlv(Vector128<short> src, Vector128<short> counts)
        {
            var x = vpack.vinflate256x32i(src);
            var y = v32u(vpack.vinflate256x32i(counts));
            return vpack.vpack128x16i(ShiftRightLogicalVariable(x,y));
        }

        /// <summary>
        /// Computes z[i] := x[i] >> s[i] for i = 0..7
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="counts">The offset vector</param>
        [MethodImpl(Inline), Srlv]
        public static Vector128<ushort> vsrlv(Vector128<ushort> src, Vector128<ushort> counts)
        {
            var x = vpack.vinflate256x32u(src);
            var y = vpack.vinflate256x32u(counts);
            return vpack.vpack128x16u(ShiftRightLogicalVariable(x,y));
        }

        /// <summary>
        ///  __m128i _mm_srlv_epi32 (__m128i a, __m128i count) VPSRLVD xmm, xmm, xmm/m128
        /// Computes z[i] := x[i] >> offsets[i] for i = 0...3
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="counts">The offset vector</param>
        [MethodImpl(Inline), Srlv]
        public static Vector128<int> vsrlv(Vector128<int> x, Vector128<int> counts)
            => ShiftRightLogicalVariable(x, v32u(counts));

        /// <summary>
        /// __m128i _mm_srlv_epi32 (__m128i a, __m128i count) VPSRLVD xmm, xmm, xmm/m128
        /// Computes z[i] := x[i] >> offsets[i] for i = 0...3
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="counts">The offsets offset vector</param>
        [MethodImpl(Inline), Srlv]
        public static Vector128<uint> vsrlv(Vector128<uint> x, Vector128<uint> counts)
            => ShiftRightLogicalVariable(x, counts);

        /// <summary>
        /// __m128i _mm_srlv_epi64 (__m128i a, __m128i count) VPSRLVQ xmm, xmm, xmm/m128
        /// Computes z[i] := x[i] >> offsets[i] for i = 0,1
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="counts">The offset vector</param>
        [MethodImpl(Inline), Srlv]
        public static Vector128<long> vsrlv(Vector128<long> x, Vector128<long> counts)
            => ShiftRightLogicalVariable(x, v64u(counts));

        /// <summary>
        /// __m128i _mm_srlv_epi64 (__m128i a, __m128i count) VPSRLVQ xmm, xmm, xmm/m128
        /// Computes z[i] := x[i] >> offsets[i] for i = 0,1
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="counts">The offset vector</param>
        [MethodImpl(Inline), Srlv]
        public static Vector128<ulong> vsrlv(Vector128<ulong> x, Vector128<ulong> counts)
            => ShiftRightLogicalVariable(x, counts);

        /// <summary>
        /// Computes z[i] := x[i] >> s[i] for i = 0..31
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="counts">The offset vector</param>
        [MethodImpl(Inline), Srlv]
        public static Vector256<sbyte> vsrlv(Vector256<sbyte> src, Vector256<sbyte> counts)
        {
            (var x0, var x1) = vpack.vinflate512x16i(src);
            (var s0, var s1) = vpack.vinflate512x16i(counts);
            return vpack.vpack256x8i(vsrlv(x0,s0), vsrlv(x1,s1));
        }

        /// <summary>
        /// Computes z[i] := x[i] >> s[i] for i = 0..31
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="counts">The offset vector</param>
        [MethodImpl(Inline), Srlv]
        public static Vector256<byte> vsrlv(Vector256<byte> src, Vector256<byte> counts)
        {
            (var x0, var x1) = vpack.vinflate512x16u(src);
            (var s0, var s1) = vpack.vinflate512x16u(counts);
            return vpack.vpack256x8u(vsrlv(x0,s0), vsrlv(x1,s1));
        }

        /// <summary>
        /// Computes z[i] := x[i] >> s[i] for i = 0..15
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="counts">The offset vector</param>
        [MethodImpl(Inline), Srlv]
        public static Vector256<short> vsrlv(Vector256<short> src, Vector256<short> counts)
        {
            (var x0, var x1) = vpack.vinflate512x32i(src);
            (var s0, var s1) = vpack.vinflate512x32i(counts);
            return vpack.vpack256x16i(vsrlv(x0,s0), vsrlv(x1,s1));
        }

        /// <summary>
        /// Computes z[i] := x[i] >> s[i] for i = 0..15
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="counts">The offset vector</param>
        [MethodImpl(Inline), Srlv]
        public static Vector256<ushort> vsrlv(Vector256<ushort> src, Vector256<ushort> counts)
        {
            (var x0, var x1) = vpack.vinflate512x32u(src);
            (var s0, var s1) = vpack.vinflate512x32u(counts);
            return vpack.vpack256x16u(vsrlv(x0,s0), vsrlv(x1,s1));
        }
    }
}