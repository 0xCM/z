//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.Intrinsics.X86.Sse41;
    using static sys;
    using static vcpu;

    partial struct vblocks
    {
        /// <summary>
        /// PMOVZXBW xmm, m64
        /// 8x8u -> 8x16u
        /// </summary>
        /// <param name="src">The blocked memory source</param>
        [MethodImpl(Inline), Op(inflate)]
        public static unsafe Vector128<ushort> vinflate128x16u(in SpanBlock64<byte> src, uint offset)
            => v16u(ConvertToVector128Int16(gptr(src[offset])));
    }
}