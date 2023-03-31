//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct Bitfields
    {
        [MethodImpl(Inline), Op]
        public static Bitfield8 hi(Bitfield16 src)
            => create((byte)(math.srl(src.State, Bitfield8.Width)));

        [MethodImpl(Inline), Op]
        public static Bitfield16 hi(Bitfield32 src)
            => create((ushort)(math.srl(src.State, Bitfield16.Width)));

        [MethodImpl(Inline), Op]
        public static Bitfield32 hi(Bitfield64 src)
            => create((uint)(math.srl(src.State, Bitfield32.Width)));

        [MethodImpl(Inline), Op, Closures(UInt8x16x32k)]
        public static Bitfield8<T> hi<T>(Bitfield16<T> src)
            where T : unmanaged
                => create(w8, generic<T>((byte)(math.srl(src.State16u, Bitfield8.Width))));

        [MethodImpl(Inline), Op, Closures(UInt8x16x32k)]
        public static Bitfield16<T> hi<T>(Bitfield32<T> src)
            where T : unmanaged
                => create(w16, generic<T>((ushort)(math.srl(src.State32u, Bitfield16.Width))));

        [MethodImpl(Inline), Op, Closures(UInt8x16x32k)]
        public static Bitfield32<T> hi<T>(Bitfield64<T> src)
            where T : unmanaged
                => create(w32, generic<T>((uint)(math.srl(src.State, Bitfield32.Width))));
    }
}