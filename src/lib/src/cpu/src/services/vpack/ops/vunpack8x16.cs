//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.Intrinsics.X86.Avx2;
    using static sys;

    partial struct vpack
    {
        /// <summary>
        /// VPMOVZXBW ymm, m128
        /// 16x8u -> 16x16i
        /// Projects 16 8-bit unsigned integers onto 16 signed 16-bit integers
        /// </summary>
        /// <param name="src">The input component source</param>
        /// <param name="n">The source component count</param>
        /// <param name="w">The target component width</param>
        /// <param name="i">Signals a sign extension</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector256<short> vunpack8x16(in sbyte src)
            => ConvertToVector256Int16(gptr(src));

        /// <summary>
        /// VPMOVZXBW ymm, m128
        /// 16x8u -> 16x16u
        /// Projects 16 unsigned 8-bit integers onto 16 unsigned 16-bit integers
        /// </summary>
        /// <param name="src">The input component source</param>
        /// <param name="dst">The target component width</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector256<ushort> vunpack8x16(in byte src)
            => vcpu.v16u(ConvertToVector256Int16(gptr(src)));
    }
}