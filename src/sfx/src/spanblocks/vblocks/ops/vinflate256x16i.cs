//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.Intrinsics.X86.Avx2;
    using static sys;

    partial struct vblocks
    {
        /// <summary>
        /// VPMOVSXBW ymm, m128
        /// 16x8i -> 16x16i
        /// </summary>
        /// <param name="src">The memory source</param>
        [MethodImpl(Inline), Op(inflate)]
        public static unsafe Vector256<short> vinflate256x16i(SpanBlock128<sbyte> src, uint offset)
            => ConvertToVector256Int16(gptr(src[offset]));

        /// <summary>
        /// VPMOVZXBW ymm, m128
        /// 16x8u -> 16x16i
        /// </summary>
        /// <param name="src">The memory source</param>
        [MethodImpl(Inline), Op(inflate)]
        public static unsafe Vector256<short> vinflate256x16i(SpanBlock128<byte> src, uint offset)
            => ConvertToVector256Int16(gptr(src[offset]));
    }
}