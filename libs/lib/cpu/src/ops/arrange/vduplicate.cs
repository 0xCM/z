//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Intrinsics;

    using static System.Runtime.Intrinsics.X86.Avx;
    using static System.Runtime.Intrinsics.X86.Avx2;
    using static System.Runtime.Intrinsics.X86.Sse3;
    using static Root;
    using static core;

    partial struct cpu
    {
        [MethodImpl(Inline), Op]
        public static Vector256<byte> vduplicate(N0 parity, W32 w, Vector256<byte> src)
            => v8u(vdup32(parity, v32f(src)));

        [MethodImpl(Inline), Op]
        public static Vector256<byte> vduplicate(N1 parity, W32 w, Vector256<byte> src)
            => v8u(vdup32(parity, v32f(src)));

        [MethodImpl(Inline), Op]
        public static Vector512<byte> vduplicate(Vector256<byte> lo, Vector256<byte> hi)
            => (vduplicate(n0, w32, lo), vduplicate(n0, w32, hi));

        // [0,1,2, ... ,E,F] -> [0,1, 0,1, ..., C,D, C,D]
        [MethodImpl(Inline), Op]
        public static Vector256<ushort> vduplicate(N0 parity, W32 w, Vector256<ushort> src)
            => v16u(vdup32(parity, v32f(src)));

        // [0,1,2, ... ,E,F] -> [2,3, 2,3, ...,  E,F, E,F]
        [MethodImpl(Inline), Op]
        public static Vector256<ushort> vduplicate(N1 parity, W32 w, Vector256<ushort> src)
            => v16u(vdup32(parity, v32f(src)));

        // [0 1 2 3 4 5 6 7] -> [0 0 2 2 4 4 6 6]
        [MethodImpl(Inline), Op]
        public static Vector256<uint> vduplicate(N0 parity, W32 w, Vector256<uint> src)
            => v32u(vdup32(parity, v32f(src)));

        // [0 1 2 3 4 5 6 7] -> [1 1 3 3 5 5 7 7]
        [MethodImpl(Inline), Op]
        public static Vector256<uint> vduplicate(N1 parity, W32 w, Vector256<uint> src)
            => v32u(vdup32(parity, v32f(src)));

        // [0 1 2 3] -> [0 0 2 2]
        [MethodImpl(Inline), Op]
        public static Vector256<ulong> vduplicate(N0 parity, W64 w, Vector256<ulong> src)
            => v64u(vdup64(parity, v64f(src)));

        // [0 1 2 3] -> [1 1 3 3]
        [MethodImpl(Inline), Op]
        public static Vector256<ulong> vduplicate(N1 parity, W64 w, Vector256<ulong> src)
            => v64u(vdup64(parity, v64f(src)));

        /// <summary>
        /// __m128d _mm_loaddup_pd (double const* mem_addr) MOVDDUP xmm, m64
        /// </summary>
        /// <param name="w">The width selector</param>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector128<double> vdup64(in double src)
            => LoadAndDuplicateToVector128(gptr(src));

        /// <summary>
        /// __m256 _mm256_moveldup_ps (__m256 a) VMOVSLDUP ymm, ymm/m256
        /// </summary>
        /// <param name="even"></param>
        /// <param name="src"></param>
        [MethodImpl(Inline), Op]
        public static Vector256<float> vdup32(N0 even, Vector256<float> src)
            => DuplicateEvenIndexed(src);

        /// <summary>
        /// __m256 _mm256_movehdup_ps (__m256 a) VMOVSHDUP ymm, ymm/m256
        /// </summary>
        /// <param name="odd"></param>
        /// <param name="src"></param>
        [MethodImpl(Inline), Op]
        public static Vector256<float> vdup32(N1 odd, Vector256<float> src)
            => DuplicateOddIndexed(src);

        /// <summary>
        /// __m256d _mm256_movedup_pd (__m256d a) VMOVDDUP ymm, ymm/m256
        /// </summary>
        /// <param name="even"></param>
        /// <param name="src"></param>
        [MethodImpl(Inline), Op]
        public static Vector256<double> vdup64(N0 even, Vector256<double> src)
            => DuplicateEvenIndexed(src);

        [MethodImpl(Inline), Op]
        public static Vector256<double> vdup64(N1 odd, Vector256<double> src)
            => DuplicateEvenIndexed(ShiftRightLogical(src.AsUInt64(),64).AsDouble());
    }
}