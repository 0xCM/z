//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static BitMaskLiterals;
    using static vcpu;

    partial struct vpack
    {
        /// <summary>
        /// Projects 32 packed bits into the least bit of 32 bytes
        /// </summary>
        /// <param name="src">The bit source</param>
        [MethodImpl(Inline), Op]
        public static Vector256<byte> vunpack32x8(uint src)
        {
            var b0 = src & Lo8x8;
            var b1 = (src >> 8) & Lo8x8;
            var b2 = (src >> 16) & Lo8x8;
            var b3 = (src >> 24) & Lo8x8;
            var v0 = vscalar(w128, bits.scatter(b0, Lsb64x8x1));
            v0 = vinsert(bits.scatter(b1, Lsb64x8x1),v0, 1);
            var v1 = vscalar(w128, bits.scatter(b2, Lsb64x8x1));
            v1 = vinsert(bits.scatter(b3, Lsb64x8x1), v1, 3);
            var v = vconcat(v0,v1);
            return v8u(v);
        }

        /// <summary>
        /// Partitions a 32-bit source value into 32 8-bit pieces each with an effective width of 1
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static Vector256<byte> vunpack1x32(uint src)
        {
            var a = vbroadcast(w256, src);
            var b = vbroadcast(w256, Msb32x8x7);
            return v8u(cpu.vand(a,b));
        }

        /// <summary>
        /// Distributes each source bit to to a specified bit of each byte in a 256-bit target vector
        /// </summary>
        /// <param name="src">The source bits</param>
        [MethodImpl(Inline), Op]
        public static Vector256<byte> vunpack1x32(uint src, byte index)
        {
            var m = Lsb64x8x1 << index;
            var lo = v8u(vparts(BitMasks.maskpart(src, 0, m), BitMasks.maskpart(src, 8, m)));
            var hi = v8u(vparts(BitMasks.maskpart(src, 16, m), BitMasks.maskpart(src, 24, m)));
            return vconcat(lo,hi);
        }
    }
}