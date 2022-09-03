//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.Intrinsics.X86.Sse41;
    using static core;
    using static cpu;

    partial struct vblocks
    {
        /// <summary>
        /// PMOVZXBD xmm, m32
        /// 4x8u -> 4x32u
        /// </summary>
        /// <param name="src">The blocked memory source</param>
        /// <param name="dst">The target vector</param>
        [MethodImpl(Inline), Op(inflate)]
        public static unsafe Vector128<uint> vinflate128x32u(in SpanBlock32<byte> src, uint offset)
            => v32u(ConvertToVector128Int32(gptr(src[offset])));

        /// <summary>
        /// PMOVSXWD xmm, m64
        /// 4x16u -> 4x32u
        /// </summary>
        /// <param name="src">The blocked memory source</param>
        /// <param name="dst">The target vector</param>
        [MethodImpl(Inline), Op(inflate)]
        public static unsafe Vector128<uint> vinflate128x32u(in SpanBlock64<ushort> src, uint offset)
            => v32u(ConvertToVector128Int32(gptr(src[offset])));
    }
}