//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct bit
    {
        [MethodImpl(Inline), Op]
        internal static byte hi(byte src)
            => (byte)((byte)src >> 4);

        [MethodImpl(Inline), Op]
        internal static byte hi(ushort src)
            => (byte)(src >> 8);

        [MethodImpl(Inline), Op]
        internal static ushort hi(uint src)
            => (ushort)(src >> 16);

        [MethodImpl(Inline), Op]
        internal static uint hi(ulong src)
            => (uint)(src >> 32);

        [MethodImpl(Inline), Op]
        internal static byte lo(byte src)
            => (byte)((byte)src & 0xF);

        [MethodImpl(Inline), Op]
        internal static byte lo(ushort src)
            => (byte)src;

        [MethodImpl(Inline), Op]
        internal static ushort lo(uint src)
            => (ushort)src;

        [MethodImpl(Inline), Op]
        internal static uint lo(ulong src)
            => (uint)src;
    }
}