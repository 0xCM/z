//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct BitPack
    {
        [MethodImpl(Inline), Unpack]
        public static ref ulong unpack1x8x32(uint src, ref ulong dst)
        {
            unpack1x8x16((ushort)src, ref dst);
            unpack1x16x8((ushort)(src >> 16), ref seek8(dst, 16));
            return ref dst;
        }
    }
}