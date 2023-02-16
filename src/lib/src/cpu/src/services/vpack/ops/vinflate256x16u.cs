//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.Intrinsics.X86.Avx2;
    using static sys;
    using static vcpu;

    partial struct vpack
    {
        /// <summary>
        /// __m256i _mm256_cvtepu8_epi16 (__m128i a)
        /// VPMOVZXBW ymm, xmm
        /// </summary>
        /// <param name="src"></param>
        /// <param name="w"></param>
        [MethodImpl(Inline), Op]
        public static Vector256<ushort> vinflate256x16u(in byte src)
            => v16u(ConvertToVector256Int16(vload(w128, src)));

        /// <summary>
        ///  __m256i _mm256_cvtepu8_epi16 (__m128i a)
        /// VPMOVZXBW ymm, xmm
        /// 16x8u -> 16x16u
        /// src[i] -> dst[i], i = 0,...,15
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<ushort> vinflate256x16u(Vector128<byte> src)
            => v16u(ConvertToVector256Int16(src));

        /// <summary>
        /// VPMOVZXBW ymm, m128
        /// 16x8u -> 16x16u
        /// </summary>
        /// <param name="src">The blocked memory source</param>
        /// <param name="w">The target width</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector256<ushort> vinflate256x16u(SpanBlock128<byte> src, uint offset)
            => v16u(ConvertToVector256Int16(gptr(src[offset])));

        [MethodImpl(Inline), Op]
        public static Vector256<ushort> vinflatelo256x16u(Vector256<byte> src)
            => vinflate256x16u(vlo(src));

        [MethodImpl(Inline), Op]
        public static Vector256<ushort> vinflatehi256x16u(Vector256<byte> src)
            => vinflate256x16u(vhi(src));

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> inflate16u(in ByteBlock8 src)
            => recover<char>(bytes(vcpu.vlo(vpack.vinflate256x16u(vcpu.vbytes(w128, u64(src))))));

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> inflate16u(in ByteBlock16 src)
            => recover<char>(bytes(vcpu.vlo(vpack.vinflate256x16u(vcpu.vbytes(w128, u64(src))))));

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> inflate16u(in ByteBlock32 src)
        {
            var v = vload(w256, src.Bytes);
            var lo = vpack.vinflatelo256x16u(v);
            var hi = vpack.vinflatehi256x16u(v);
            return recover<char>(sys.bytes(new V256x2(lo,hi)));
        }
    }
}