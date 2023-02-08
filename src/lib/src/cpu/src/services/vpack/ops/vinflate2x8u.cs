//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.Intrinsics.X86.Sse41;
    using static sys;
    using static vcpu;

    partial struct vpack
    {
        /// <summary>
        /// PMOVZXBQ xmm, m16
        /// VPMOVZXBQ xmm1, xmm2/m16 |  VEX.128.66.0F38.WIG 32 /r
        /// 2x8u -> 2x64i
        /// Projects two unsigned 8-bit integers onto 2 signed 64-bit integers
        /// </summary>
        /// <param name="src">The input component source</param>
        /// <param name="n">The source component count</param>
        /// <param name="w">The target component width</param>
        /// <param name="i">Signals a sign extension</param>
        [MethodImpl(Inline), Op(inflate)]
        public static unsafe Vector128<long> vinflate2x8u(in byte src, out Vector128<long> dst)
            => dst = ConvertToVector128Int64(gptr(src));

        /// <summary>
        /// PMOVZXBQ xmm, m16
        /// 2x8u -> 2x64u
        /// Projects 2 unsigned 8-bit values onto 2 unsigned 64-bit integers
        /// </summary>
        /// <param name="src">The input component source</param>
        /// <param name="n">The source component count</param>
        /// <param name="dst">The target component width</param>
        [MethodImpl(Inline), Op(inflate)]
        public static unsafe Vector128<ulong> vinflate2x8u(in byte src, out Vector128<ulong> dst)
            => dst = v64u(ConvertToVector128Int64(gptr(src)));
    }
}