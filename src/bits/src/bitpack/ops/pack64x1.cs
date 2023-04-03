//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static vcpu;

    partial struct BitPack
    {
        /// <summary>
        /// Packs the least significant bit from 64 32-bit unsigned integers to a 64-bit target
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="n">The number of bits to pack</param>
        /// <param name="w">The target width</param>
        [MethodImpl(Inline), Op]
        public static ulong pack64x1(in uint src)
        {
            var buffer = z64;
            return pack64x1(src, ref buffer);
        }

        /// <summary>
        /// Packs the least significant bit from 64 32-bit unsigned integers to a 64-bit target
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="dst">The target value</param>
        [MethodImpl(Inline), Op]
        public static ref ulong pack64x1(in uint src, ref ulong dst)
        {
            var w = w256;
            var v0 = vload(w, skip(src, 0*8));
            var v1 = vload(w, skip(src, 1*8));
            var x = vpack.vpack256x16u(v0, v1);
            v0 = vload(w, skip(src,2*8));
            v1 = vload(w, skip(src,3*8));

            var y = vpack.vpack256x16u(v0, v1);
            var packed = (ulong)vpack.vpacklsb(vpack.vpack256x8u(x,y));

            v0 = vload(w, skip(src,4*8));
            v1 = vload(w, skip(src,5*8));
            x = vpack.vpack256x16u(v0,v1);

            v0 = vload(w, skip(src,6*8));
            v1 = vload(w, skip(src,7*8));
            y = vpack.vpack256x16u(v0,v1);

            packed |= (ulong)vpack.vpacklsb(vpack.vpack256x8u(x,y)) << 32;

            dst = packed;
            return ref dst;
        }

        /// <summary>
        /// Packs the least significant bit from 64 source values to a 64-bit target
        /// </summary>
        /// <param name="src">The source sequence</param>
        /// <param name="dst">The target</param>
        [MethodImpl(Inline), Op]
        public static ref ulong pack64x1(in NatSpan<N64,uint> src, ref ulong dst)
        {
            dst = pack64x1(src.First);
            return ref dst;
        }

        /// <summary>
        /// Packs the 64 leading source bits
        /// </summary>
        /// <param name="src">The bit source</param>
        [MethodImpl(Inline), Op]
        public static ulong pack64x1(Span<uint> src)
            => pack64x1(first(src));
    }
}