//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class Numbers
{
    [MethodImpl(Inline), Op]
    public static void split(num32 src, out num16 a, out num16 b)
    {
        a = (ushort)(src & 0x0000_FFFF);
        b = (ushort)((src & 0xFFFF_0000) >> 16);
    }
}