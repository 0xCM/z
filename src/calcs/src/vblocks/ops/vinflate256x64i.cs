//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.Intrinsics.X86.Avx2;
    using static core;

    partial struct vblocks
    {
        /// <summary>
        ///  VPMOVSXBQ ymm, m32
        /// 4x8i -> 4x64i
        /// </summary>
        /// <param name="src">The memory source</param>
        /// <param name="dst">The target vector</param>
        [MethodImpl(Inline), Op(inflate)]
        public static unsafe Vector256<long> vinflate256x64i(in SpanBlock32<sbyte> src, uint offset)
            => ConvertToVector256Int64(gptr(src[offset]));

        /// <summary>
        /// VPMOVZXBQ ymm, m32
        /// 4x8u -> 4x64i
        /// </summary>
        /// <param name="src">The memory source</param>
        /// <param name="dst">The target vector</param>
        [MethodImpl(Inline), Op(inflate)]
        public static unsafe Vector256<long> vinflate256x64i(in SpanBlock32<byte> src, uint offset)
            => ConvertToVector256Int64(gptr(src[offset]));

        /// <summary>
        /// VPMOVZXWQ ymm, m64
        /// 4x16u -> 4x64i
        /// </summary>
        /// <param name="src">The memory source</param>
        /// <param name="dst">The target vector</param>
        [MethodImpl(Inline), Op(inflate)]
        public static unsafe Vector256<long> vinflate256x64i(in SpanBlock64<ushort> src, uint offset)
            => ConvertToVector256Int64(gptr(src[offset]));

        /// <summary>
        /// VPMOVZXDQ ymm, m128
        /// 4x32u -> 4x64i
        /// </summary>
        /// <param name="src">The memory source</param>
        /// <param name="dst">The target vector</param>
        [MethodImpl(Inline), Op(inflate)]
        public static unsafe Vector256<long> vinflate256x64i(in SpanBlock128<uint> src, uint offset)
            => ConvertToVector256Int64(gptr(src[offset]));

        /// <summary>
        /// VPMOVSXDQ ymm, m128
        /// 4x32i -> 4x64i
        /// </summary>
        /// <param name="src">The memory source</param>
        /// <param name="dst">The target vector</param>
        [MethodImpl(Inline), Op(inflate)]
        public static unsafe Vector256<long> vinflate256x64i(in SpanBlock128<int> src, uint offset)
            => ConvertToVector256Int64(gptr(src[offset]));
    }
}