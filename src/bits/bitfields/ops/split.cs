//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Bitfields
    {
        [MethodImpl(Inline), Op]
        public static void split(byte src, out byte a, out byte b)
        {
            a = (byte)(src & 0x0F);
            b = (byte)((src & 0xF0) >> 4);
        }

        [MethodImpl(Inline), Op]
        public static void split(ushort src, out byte a, out byte b)
        {
            a = (byte)(src & 0x00FF);
            b = (byte)((src & 0xFF00) >> 8);
        }

        [MethodImpl(Inline), Op]
        public static void split(uint src, out ushort a, out ushort b)
        {
            a = (ushort)(src & 0x0000_FFFF);
            b = (ushort)((src & 0xFFFF_0000) >> 16);
        }

        [MethodImpl(Inline), Op]
        public static void split(uint src, out byte a, out byte b, out byte c, out byte d)
        {
            a = (byte)(src & 0x0000_00FF);
            b = (byte)((src & 0x0000_FF00) >> 8);
            c = (byte)((src & 0x00FF_0000) >> 16);
            d = (byte)((src & 0xFF00_0000) >> 24);
        }
    }
}