//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.Intrinsics.X86.Avx;
    using static System.Runtime.Intrinsics.X86.Avx2;
    using static sys;
    using static vcpu;

    partial struct vpack
    {
        /// <summary>
        /// VPMOVZXBD ymm, m64
        /// 8x8u -> 8x32u
        /// Zero extends 8 8-bit integers to 8 32-bit integers in ymm1
        /// </summary>
        /// <param name="src">The source reference</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector256<uint> vinflate8x256x32u(in byte src)
            => v32u(ConvertToVector256Int32(gptr(src)));

        [MethodImpl(Inline), Op]
        public static void vinflate8x256x32u(in byte src, int step, ref uint dst)
            => vstore(vinflate8x256x32u(skip(src, step*8)), ref seek(dst, step*8));

        [MethodImpl(Inline), Op]
        public static void vinflate8x256x32u(in byte src, int srcStep, ref uint dst, int dstStep)
            => vstore(vinflate8x256x32u(skip(src, srcStep*8)), ref seek(dst, dstStep*8));
    }
}