//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.Intrinsics.X86.Avx2;
    using static core;
    using static cpu;

    partial struct vblocks
    {
        /// <summary>
        ///  VPMOVSXBD ymm, m64
        /// 8x8i -> 8x32i
        /// </summary>
        /// <param name="src">The memory source</param>
        /// <param name="dst">The target vector</param>
        [MethodImpl(Inline), Op(inflate)]
        public static unsafe Vector256<int> vinflate256x32i(in SpanBlock64<sbyte> src, uint offset)
            => ConvertToVector256Int32(gptr(src[offset]));

        /// <summary>
        /// VPMOVZXWD ymm, m128
        /// 8x16u -> 8x32i
        /// </summary>
        /// <param name="src">The blocked memory source</param>
        /// <param name="dst">The target vector</param>
        [MethodImpl(Inline), Op(inflate)]
        public static unsafe Vector256<int> vinflate256x32i(in SpanBlock128<ushort> src, uint offset)
            => ConvertToVector256Int32(gptr(src[offset]));
    }
}