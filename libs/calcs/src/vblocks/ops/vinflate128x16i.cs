//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    using static System.Runtime.Intrinsics.X86.Sse41;
    using static core;

    partial struct vblocks
    {
        /// <summary>
        /// PMOVSXBW xmm, m64
        /// 8x8i -> 8x16i
        /// </summary>
        /// <param name="src">The blocked memory source</param>
        [MethodImpl(Inline), Op(inflate)]
        public static unsafe Vector128<short> vinflate128x16i(in SpanBlock64<sbyte> src, uint offset)
            => ConvertToVector128Int16(gptr(src[offset]));

        /// <summary>
        /// PMOVZXBW xmm, m64
        /// 8x8u -> 8x16u
        /// </summary>
        /// <param name="src">The memory source</param>
        [MethodImpl(Inline), Op(inflate)]
        public static unsafe Vector128<short> vinflate128x16i(in SpanBlock64<byte> src, uint offset)
            => ConvertToVector128Int16(gptr(src[offset]));
    }
}