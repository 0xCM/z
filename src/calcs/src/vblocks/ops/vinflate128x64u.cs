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
        /// PMOVZXBQ xmm, m16
        /// 2x8u -> 2x64u
        /// </summary>
        /// <param name="src">The blocked memory source</param>
        /// <param name="dst">The target vector</param>
        [MethodImpl(Inline), Op(inflate)]
        public static unsafe Vector128<ulong> vinflate128x64u(in SpanBlock16<byte> src, uint offset)
            => v64u(ConvertToVector128Int64(gptr(src[offset])));

        /// <summary>
        /// PMOVZXWQ xmm, m32
        /// 2x16u -> 2x64u
        /// </summary>
        /// <param name="src">The blocked memory source</param>
        /// <param name="dst">The target vector</param>
        [MethodImpl(Inline), Op(inflate)]
        public static unsafe Vector128<ulong> vinflate128x64u(in SpanBlock32<ushort> src, uint offset)
            => v64u(ConvertToVector128Int64(gptr(src[offset])));
    }
}