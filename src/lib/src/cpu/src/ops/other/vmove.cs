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
    using static System.Runtime.Intrinsics.X86.Sse2;
    using static System.Runtime.Intrinsics.X86.Sse2.X64;
    using static Root;
    using static core;

    partial struct cpu
    {
        /// <summary>
        /// src[3] -> r/m16
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="w">The target register width</param>
        /// <param name="i">The source component index</param>
        /// <param name="j">THe target component index</param>
        [MethodImpl(Inline), Op]
        public static ushort vmove(Vector128<ushort> src, W16 w, N3 i, N0 j)
            => vlo16u(vpermlo4x16(src,Perm4L.DBCA));

        /// <summary>
        /// src[2] -> r/m16
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="w">The target register width</param>
        /// <param name="i">The source component index</param>
        /// <param name="j">THe target component index</param>
        [MethodImpl(Inline), Op]
        public static ushort vmove(Vector128<ushort> src, W16 w, N2 i, N0 j)
            => vlo16u(vpermlo4x16(src,Perm4L.CBDA));

        /// <summary>
        /// src[1] -> r/m16
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="w">The target register width</param>
        /// <param name="i">The source component index</param>
        /// <param name="j">THe target component index</param>
        [MethodImpl(Inline), Op]
        public static ushort vmove(Vector128<ushort> src, W16 w, N1 i, N0 j)
            => vlo16u(vpermlo4x16(src,Perm4L.BCDA));

        /// <summary>
        /// src[0..31] -> dst[0..64]
        /// __m128d _mm_cvtss_sd (__m128d a, __m128 b) CVTSS2SD xmm, xmm/m32
        /// Overwrites the lower half of the target vector with the value obtained by converting the
        /// least component of the source vector to a 64-bit integer
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The target vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<ulong> vmove(Vector128<uint> src, Vector128<ulong> dst)
            => v64u(ConvertScalarToVector128Double(v64f(dst),v32f(src)));

        /// <summary>
        /// src[0..31] -> dst[0..64]
        /// __m128d _mm_cvtss_sd (__m128d a, __m128 b) CVTSS2SD xmm, xmm/m32
        /// Overwrites the lower half of the target vector with the value obtained by converting the least component of the source vector to a 64-bit integer
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The target vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<long> vmove(Vector128<int> src, Vector128<long> dst)
            => v64i(ConvertScalarToVector128Double(v64f(dst),v32f(src)));

        /// <summary>
        /// VPMOVZXWD ymm, m128
        /// 16x16u ->16x32u
        /// Projects 16 unsigned 16-bit integers onto 16 unsigned 32-bit integers
        /// </summary>
        /// <param name="src">The input component source</param>
        /// <param name="n">The source component count</param>
        /// <param name="w">The target component width</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector512<uint> vmove16x32u(in ushort src)
            => (v32u(ConvertToVector256Int32(gptr(src))),
                v32u(ConvertToVector256Int32(gptr(src, 8))));
    }
}