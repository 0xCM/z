//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.Intrinsics.X86.Sse41;
    using static sys;

    partial struct vpack
    {
        /// <summary>
        /// PMOVSXWQ xmm, m32
        /// 2x16i -> 2x64u
        /// Projects 2 16-bit signed integers onto 2 64-bit signed integers
        /// </summary>
        /// <param name="src">The input component source</param>
        /// <param name="n">The source component count</param>
        /// <param name="w">The target component width</param>
        [MethodImpl(Inline), Op(inflate)]
        public static unsafe Vector128<long> vinflate2x16i(in short src, out Vector128<long> dst)
            => dst = ConvertToVector128Int64(gptr(src));

        /// <summary>
        /// PMOVZXWQ xmm, m32
        /// Projects 2 unsigned 16-bit integers onto 2 signed 64-bit integers
        /// </summary>
        /// <param name="src">The input component source</param>
        /// <param name="n">The source component count</param>
        /// <param name="w">The target component width</param>
        /// <param name="i">Signals a sign extension</param>
        [MethodImpl(Inline), Op(inflate)]
        public static unsafe Vector128<long> vinflate2x16i(in ushort src, out Vector128<long> dst)
            => dst = ConvertToVector128Int64(gptr(src));
    }
}