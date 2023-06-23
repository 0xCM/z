//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.Intrinsics.X86.Avx2;
    using static sys;
    using static vcpu;

    partial struct vblocks
    {
        /// <summary>
        /// VPMOVZXBW ymm, m128
        /// 32x8u -> 32x16u
        /// </summary>
        /// <param name="src">The memory source</param>
        /// <param name="lo">The lo target</param>
        /// <param name="hi">The hi target</param>
        [MethodImpl(Inline), Op(inflate)]
        public static unsafe void vinflate32x8u(SpanBlock256<byte> src, uint offset, Vector256<ushort> lo, Vector256<ushort> hi)
        {
            lo = v16u(ConvertToVector256Int16(gptr(src[offset])));
            hi = v16u(ConvertToVector256Int16(gptr(src[offset],16)));
        }
    }
}