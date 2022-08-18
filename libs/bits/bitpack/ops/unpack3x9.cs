//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static BitMaskLiterals;

    partial struct BitPack
    {
        /// <summary>
        /// Distributes the first 27-bits of a 32-bit source evenly over the lower 3 bit of 9 8-bit segments
        /// </summary>
        /// <param name="src">The source</param>
        /// <param name="dst">The target</param>
        [MethodImpl(Inline), Op]
        public static ref byte unpack3x9(uint src, ref byte dst)
        {
            seek64(dst, 0) = bits.scatter(src, Lsb64x8x3);
            seek16(dst, 4) = (byte)bits.scatter(src >> 24, Lsb64x8x3);
            return ref dst;
        }
    }
}