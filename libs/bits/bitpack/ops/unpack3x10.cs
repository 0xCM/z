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
        [MethodImpl(Inline), Op]
        public static ref byte unpack3x10(uint src, ref byte dst)
        {
            seek64(dst, 0) = bits.scatter(src, Lsb64x8x3);
            seek16(dst, 4) = (ushort)bits.scatter(src >> 24, Lsb64x8x3);
            return ref dst;
        }
    }
}