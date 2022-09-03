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
        /// Computes z[i] := x[i] << s[i] for i = 0..15
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="counts">The offset vector</param>
        [MethodImpl(Inline), Sllv]
        public static Vector128<sbyte> vsllv(Vector128<sbyte> src, Vector128<sbyte> counts)
        {
            var x = vpack.vinflate256x16i(src);
            var y = vpack.vinflate256x16i(counts);
            return vpack.vpack128x8i(vsllv(x,y));
        }

        /// <summary>
        /// Computes z[i] := x[i] << s[i] for i = 0..15
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="counts">The offset vector</param>
        [MethodImpl(Inline), Sllv]
        public static Vector128<byte> vsllv(Vector128<byte> src, Vector128<byte> counts)
        {
            var x = vpack.vinflate256x16u(src);
            var y = vpack.vinflate256x16u(counts);
            return vpack.vpack128x8u(vsllv(x,y));
        }

        /// <summary>
        /// Computes z[i] := x[i] >> s[i] for i = 0..7
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="counts">The offset vector</param>
        [MethodImpl(Inline), Sllv]
        public static Vector128<short> vsllv(Vector128<short> src, Vector128<short> counts)
        {
            var a = vpack.vinflate256x32i(src);
            var b = v32u(vpack.vinflate256x32i(counts));
            var x = ShiftLeftLogicalVariable(a,b);
            return vpack.vpack128x16i(x);
        }

        /// <summary>
        /// Computes z[i] := x[i] << s[i] for i = 0..7
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="counts">The offset vector</param>
        [MethodImpl(Inline), Sllv]
        public static Vector128<ushort> vsllv(Vector128<ushort> src, Vector128<ushort> counts)
        {
            var a = vpack.vinflate256x32u(src);
            var b = vpack.vinflate256x32u(counts);
            var c = ShiftLeftLogicalVariable(a,b);
            return vpack.vpack128x16u(c);
        }

        /// <summary>
        /// __m128i _mm_sllv_epi32 (__m128i a, __m128i count) VPSLLVD xmm, ymm, xmm/m128
        /// Computes z[i] := x[i] << s[i] for i = 0..3
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="counts">The offset vector</param>
        [MethodImpl(Inline), Sllv]
        public static Vector128<int> vsllv(Vector128<int> src, Vector128<int> counts)
            => ShiftLeftLogicalVariable(src, v32u(counts));

        /// <summary>
        /// __m128i _mm_sllv_epi32 (__m128i a, __m128i count) VPSLLVD xmm, ymm, xmm/m128
        /// Computes z[i] := x[i] << s[i] for i = 0..3
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="counts">The offset vector</param>
        [MethodImpl(Inline), Sllv]
        public static Vector128<uint> vsllv(Vector128<uint> src, Vector128<uint> counts)
            => ShiftLeftLogicalVariable(src, counts);

        /// <summary>
        ///  __m128i _mm_sllv_epi64 (__m128i a, __m128i count) VPSLLVQ xmm, ymm, xmm/m128
        /// Computes z[i] := x[i] << s[i] for i = 0,1
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="counts">The offset vector</param>
        [MethodImpl(Inline), Sllv]
        public static Vector128<long> vsllv(Vector128<long> src, Vector128<long> counts)
            => ShiftLeftLogicalVariable(src, v64u(counts));

        /// <summary>
        /// __m128i _mm_sllv_epi64 (__m128i a, __m128i count) VPSLLVQ xmm, ymm, xmm/m128
        /// Computes z[i] := x[i] << s[i] for i = 0,1
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="counts">The offset vector</param>
        [MethodImpl(Inline), Sllv]
        public static Vector128<ulong> vsllv(Vector128<ulong> src, Vector128<ulong> counts)
            => ShiftLeftLogicalVariable(src, counts);

        /// <summary>
        /// Computes z[i] := x[i] >> s[i] for i = 0..31
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="counts">The offset vector</param>
        [MethodImpl(Inline), Sllv]
        public static Vector256<sbyte> vsllv(Vector256<sbyte> src, Vector256<sbyte> counts)
        {
            (var x0, var x1) = vpack.vinflate512x16i(src);
            (var s0, var s1) = vpack.vinflate512x16i(counts);
            return vpack.vpack256x8i(vsllv(x0,s0), vsllv(x1,s1));
        }

        /// <summary>
        /// Computes z[i] := x[i] >> s[i] for i = 0..31
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="counts">The offset vector</param>
        [MethodImpl(Inline), Sllv]
        public static Vector256<byte> vsllv(Vector256<byte> src, Vector256<byte> counts)
        {
            (var x0, var x1) = vpack.vinflate512x16u(src);
            (var s0, var s1) = vpack.vinflate512x16u(counts);
            return vpack.vpack256x8u(vsllv(x0,s0),vsllv(x1,s1));
        }

        /// <summary>
        /// Computes z[i] := x[i] << s[i] for i = 0..15
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="counts">The offset vector</param>
        [MethodImpl(Inline), Sllv]
        public static Vector256<short> vsllv(Vector256<short> src, Vector256<short> counts)
        {
            (var x0, var x1) = vpack.vinflate512x32i(src);
            (var s0, var s1) = vpack.vinflate512x32i(counts);
            return vpack.vpack256x16i(vsllv(x0,s0),vsllv(x1,s1));
        }

        /// <summary>
        /// Computes z[i] := x[i] << s[i] for i = 0..15
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="counts">The offset vector</param>
        [MethodImpl(Inline), Sllv]
        public static Vector256<ushort> vsllv(Vector256<ushort> src, Vector256<ushort> counts)
        {
            (var x0, var x1) = vpack.vinflate512x32u(src);
            (var s0, var s1) = vpack.vinflate512x32u(counts);
            return vpack.vpack256x16u(vsllv(x0,s0), vsllv(x1,s1));
        }

        /// <summary>
        /// __m256i _mm256_sllv_epi32 (__m256i a, __m256i count) VPSLLVD ymm, ymm, ymm/m256
        /// Computes z[i] := x[i] << s[i] for i = 0...7
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="counts">The offset vector</param>
        [MethodImpl(Inline), Sllv]
        public static Vector256<int> vsllv(Vector256<int> src, Vector256<int> counts)
            => ShiftLeftLogicalVariable(src, v32u(counts));

        /// <summary>
        ///  __m256i _mm256_sllv_epi32 (__m256i a, __m256i count) VPSLLVD ymm, ymm, ymm/m256
        /// Computes z[i] := x[i] << s[i] for i = 0...7
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="counts">The offset vector</param>
        [MethodImpl(Inline), Sllv]
        public static Vector256<uint> vsllv(Vector256<uint> src, Vector256<uint> counts)
            => ShiftLeftLogicalVariable(src, counts);

        /// <summary>
        ///  __m256i _mm256_sllv_epi64 (__m256i a, __m256i count) VPSLLVQ ymm, ymm, ymm/m256
        /// Computes z[i] := x[i] << s[i] for i = 0...3
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="counts">The offset vector</param>
        [MethodImpl(Inline), Sllv]
        public static Vector256<long> vsllv(Vector256<long> src, Vector256<long> counts)
            => ShiftLeftLogicalVariable(src, v64u(counts));

        /// <summary>
        /// __m256i _mm256_sllv_epi64 (__m256i a, __m256i count) VPSLLVQ ymm, ymm, ymm/m256
        /// Computes z[i] := x[i] << s[i] for i = 0...3
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="counts">The offset vector</param>
        [MethodImpl(Inline), Sllv]
        public static Vector256<ulong> vsllv(Vector256<ulong> src, Vector256<ulong> counts)
            => ShiftLeftLogicalVariable(src, counts);
    }
}