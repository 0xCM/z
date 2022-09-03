//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.Intrinsics.X86.Sse41;
    using static System.Runtime.Intrinsics.X86.Avx;
    using static core;

    partial struct vblocks
    {
        /// <summary>
        /// PMOVSXBD xmm, m32
        /// 4x8i -> 4x32i
        /// </summary>
        /// <param name="src">The memory source</param>
        [MethodImpl(Inline), Op(inflate)]
        public static unsafe Vector128<int> vinflate128x32i(in SpanBlock32<sbyte> src, uint offset)
            => ConvertToVector128Int32(gptr(src[offset]));

        /// <summary>
        /// PMOVZXBD xmm, m32
        /// 4x8u -> 4x32i
        /// </summary>
        /// <param name="src">The memory source</param>
        [MethodImpl(Inline), Op(inflate)]
        public static unsafe Vector128<int> vinflate128x32i(in SpanBlock32<byte> src, uint offset)
            => ConvertToVector128Int32(gptr(src[offset]));

        /// <summary>
        /// PMOVSXWD xmm, m64
        /// 4x16i -> 4x32i
        /// </summary>
        /// <param name="src">The blocked memory source</param>
        /// <param name="dst">The target vector</param>
        [MethodImpl(Inline), Op(inflate)]
        public static unsafe Vector128<int> vinflate128x32i(in SpanBlock64<short> src, uint offset)
            => ConvertToVector128Int32(gptr(src[offset]));
    }
}