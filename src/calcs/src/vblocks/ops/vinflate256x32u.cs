//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.Intrinsics.X86.Avx2;
    using static sys;
    using static cpu;

    partial struct vblocks
    {
        /// <summary>
        /// VPMOVZXBD ymm, m64
        /// 8x8u -> 8x32u
        /// </summary>
        /// <param name="src">The blocked memory source</param>
        /// <param name="dst">The target vector</param>
        [MethodImpl(Inline), Op(inflate)]
        public static unsafe Vector256<uint> vinflate256x32u(in SpanBlock64<byte> src, uint offset)
            => v32u(ConvertToVector256Int32(gptr(src.First)));

        /// <summary>
        /// VPMOVZXWD ymm, m128
        /// 8x16u -> 8x32u
        /// </summary>
        /// <param name="src">The blocked memory source</param>
        /// <param name="dst">The target vector</param>
        [MethodImpl(Inline), Op(inflate)]
        public static unsafe Vector256<uint> vinflate256x32u(SpanBlock128<ushort> src, uint offset)
            => v32u(ConvertToVector256Int32(gptr(src.First)));
    }
}