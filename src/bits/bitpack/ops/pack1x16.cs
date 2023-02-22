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
        /// Packs the least significant bit from 16 32-bit unsigned integers to a 16-bit target
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="dst">The target value</param>
        [MethodImpl(Inline), Op]
        public static ref ushort pack1x16(in uint src, ref ushort dst)
        {
            var v0 = vload(w256, skip(src, 0*8));
            var v1 = vload(w256, skip(src, 1*8));
            dst = vpack.vpacklsb(vpack.vpack128x8u(v0, v1));
            return ref dst;
        }

        /// <summary>
        /// Packs the 16 leading source bits
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="n">The number of bits to pack</param>
        [MethodImpl(Inline), Op]
        public static ushort pack1x16(ReadOnlySpan<uint> src)
        {
            var buffer = z16;
            return pack1x16(first(src), ref buffer);
        }

        /// <summary>
        /// Packs the least significant bit from 16 32-bit unsigned integers to a 16-bit target
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="count">The number of bits to pack</param>
        /// <param name="dst">The target width</param>
        [MethodImpl(Inline), Op]
        public static ushort pack1x16(in uint src)
        {
            var buffer = z16;
            return pack1x16(src, ref buffer);
        }

        /// <summary>
        /// Packs the least significant bit from 16 32-bit source values to a 16-bit target
        /// </summary>
        /// <param name="src">The intput sequence</param>
        /// <param name="dst">The target</param>
        [MethodImpl(Inline), Op]
        public static ref ushort pack1x16(NatSpan<N16,uint> src, ref ushort dst)
        {
            dst = pack1x16(src.First);
            return ref dst;
        }

        /// <summary>
        /// Packs the least significant bit from 16 32-bit source values to a 16-bit target
        /// </summary>
        /// <param name="src">The intput sequence</param>
        /// <param name="dst">The target</param>
        [MethodImpl(Inline), Op]
        public static ref ushort pack1x16(ReadOnlySpan<uint> src, ref ushort dst, uint offset)
        {
            dst = pack1x16(skip(src, offset));
            return ref dst;
        }
    }
}