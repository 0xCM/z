//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class math
    {
        [MethodImpl(Inline), Op]
        public static byte trim(byte src, byte width)
            => and(src,width);

        [MethodImpl(Inline), Op]
        public static sbyte trim(sbyte src, byte width)
            => mul((sbyte)and((byte)src,width), (sbyte)sign(src));

        [MethodImpl(Inline), Op]
        public static ushort trim(ushort src, byte width)
            => and(src,width);

        [MethodImpl(Inline), Op]
        public static short trim(short src, byte width)
            => mul((short)and((ushort)src,width), (short)sign(src));

        [MethodImpl(Inline), Op]
        public static uint trim(uint src, byte width)
            => and(src,width);

        [MethodImpl(Inline), Op]
        public static int trim(int src, byte width)
            => mul((int)and((uint)src,width), (int)sign(src));

        [MethodImpl(Inline), Op]
        public static long trim(long src, byte width)
            => mul((long)and((ulong)src,width), (long)sign(src));

        [MethodImpl(Inline), Op]
        public static ulong trim(ulong src, byte width)
            => and(src,width);
    }
}