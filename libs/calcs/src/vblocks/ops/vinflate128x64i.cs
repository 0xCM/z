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
        /// PMOVSXBQ xmm, m16
        /// 2x8i -> 2x64i
        /// </summary>
        /// <param name="src">The memory source</param>
        [MethodImpl(Inline), Op(inflate)]
        public static unsafe Vector128<long> vinflate128x64i(in SpanBlock16<sbyte> src, uint offset)
            => ConvertToVector128Int64(gptr(src[offset]));

        /// <summary>
        /// PMOVZXBQ xmm, m16
        /// 2x8u -> 2x64i
        /// </summary>
        /// <param name="src">The memory source</param>
        /// <param name="dst">The target vector</param>
        [MethodImpl(Inline), Op(inflate)]
        public static unsafe Vector128<long> vinflate128x64i(in SpanBlock16<byte> src, uint offset)
            => ConvertToVector128Int64(gptr(src[offset]));

        /// <summary>
        /// PMOVSXWQ xmm, m32
        /// 2x16i -> 2x64u
        /// </summary>
        /// <param name="src">The memory source</param>
        /// <param name="dst">The target vector</param>
        [MethodImpl(Inline), Op(inflate)]
        public static unsafe Vector128<long> vinflate128x64i(in SpanBlock32<short> src, uint offset)
            => ConvertToVector128Int64(gptr(src[offset]));

        /// <summary>
        /// PMOVZXWQ xmm, m32
        /// </summary>
        /// <param name="src">The memory source</param>
        /// <param name="dst">The target vector</param>
        [MethodImpl(Inline), Op(inflate)]
        public static unsafe Vector128<long> vinflate128x64i(in SpanBlock32<ushort> src, uint offset)
            => ConvertToVector128Int64(gptr(src.First));
    }
}