//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.Intrinsics.X86.Avx2;
    using static core;
    using static cpu;

    partial struct vpack
    {
        /// <summary>
        /// 4x32u -> 4x64u
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="x0">The first target vector</param>
        /// <param name="x1">The second target vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<ulong> vinflate256x64u(Vector128<uint> src)
            => v64u(ConvertToVector256Int64(src));

        /// <summary>
        /// VPMOVZXBQ ymm, m32
        /// 4x8u -> 4x64u
        /// Projects four unsigned 8-bit integers onto 4 unsigned 64-bit integers
        /// </summary>
        /// <param name="src">The input component source</param>
        /// <param name="n">The source component count</param>
        /// <param name="dst">The target component width</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector256<ulong> vinflate256x64u(in byte src)
            => v64u(ConvertToVector256Int64(gptr(src)));

        /// <summary>
        /// VPMOVZXWQ ymm, m64
        /// 4x16u -> 4x64u
        /// Projects 4 unsigned 16-bit integers onto 4 unsigned 64-bit integers
        /// </summary>
        /// <param name="src">The input component source</param>
        /// <param name="n">The source component count</param>
        /// <param name="w">The target component width</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector256<ulong> vinflate256x64u(in ushort src)
            => v64u(ConvertToVector256Int64(gptr(src)));

        /// <summary>
        /// VPMOVZXBQ ymm, m32
        /// 4x8u -> 4x64u
        /// </summary>
        /// <param name="src">The blocked memory source</param>
        /// <param name="dst">The target vector</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector256<ulong> vinflate256x64u(in SpanBlock32<byte> src, uint offset)
            => v64u(ConvertToVector256Int64(gptr(src[offset])));

        /// <summary>
        /// VPMOVZXWQ ymm, m64
        /// 4x16u -> 4x64u
        /// </summary>
        /// <param name="src">The blocked memory source</param>
        /// <param name="dst">The target vector</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector256<ulong> vinflate256x64u(in SpanBlock64<ushort> src, uint offset)
            => v64u(ConvertToVector256Int64(gptr(src[offset])));

        /// <summary>
        /// VPMOVZXDQ ymm, m128
        /// 4x32u -> 4x64u
        /// </summary>
        /// <param name="src">The blocked memory source</param>
        /// <param name="dst">The target vector</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector256<ulong> vinflate256x64u(in SpanBlock128<uint> src, uint offset)
            => v64u(ConvertToVector256Int64(gptr(src[offset])));
    }
}