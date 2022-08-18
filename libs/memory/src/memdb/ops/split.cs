//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class MemDb
    {
        [MethodImpl(Inline), Op]
        public static void split(uint src, out ushort a, out ushort b)
        {
            a = (ushort)(src & 0x0000_FFFF);
            b = (ushort)((src & 0xFFFF_0000) >> 16);
        }
    }
}