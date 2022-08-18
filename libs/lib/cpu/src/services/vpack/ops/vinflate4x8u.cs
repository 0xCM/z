//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Intrinsics;

    using static System.Runtime.Intrinsics.X86.Sse41;
    using static System.Runtime.Intrinsics.X86.Avx;
    using static System.Runtime.Intrinsics.X86.Sse2;
    using static System.Runtime.Intrinsics.X86.Avx2;
    using static Root;
    using static core;
    using static cpu;

    partial struct vpack
    {
        /// <summary>
        /// PMOVZXBD xmm, m32
        /// 4x8u -> 4x32u
        /// Projects 4 unsigned 8-bit values onto 4 unsigned 32-bit values
        /// </summary>
        /// <param name="src">The input component source</param>
        /// <param name="n">The source component count</param>
        /// <param name="dst">The target component width</param>
        [MethodImpl(Inline), Op(inflate)]
        public static unsafe Vector128<uint> vinflate4x8u(in byte src, out Vector128<uint> dst)
            => dst = v32u(ConvertToVector128Int32(gptr(src)));

        /// <summary>
        /// PMOVZXBD xmm, m32
        /// 4x8u -> 4x32i
        /// Projects four unsigned 8-bit integers onto 4 signed 32-bit integers
        /// </summary>
        /// <param name="src">The input component source</param>
        /// <param name="n">The source component count</param>
        /// <param name="w">The target component width</param>
        /// <param name="i">Signals a sign extension</param>
        [MethodImpl(Inline), Op(inflate)]
        public static unsafe Vector128<int> vinflate4x8u(in byte src, out Vector128<int> dst)
            => dst = ConvertToVector128Int32(gptr(src));

        /// <summary>
        /// VPMOVZXBQ ymm, m32
        /// 4x8u -> 4x64i
        /// Projects four unsigned 8-bit integers onto 4 signed 64-bit integers
        /// </summary>
        /// <param name="src">The input component source</param>
        /// <param name="n">The source component count</param>
        /// <param name="w">The target component width</param>
        /// <param name="i">Signals a sign extension</param>
        [MethodImpl(Inline), Op(inflate)]
        public static unsafe Vector256<long> vinflate4x8u(in byte src, out Vector256<long> dst)
            => dst = ConvertToVector256Int64(gptr(src));
    }
}