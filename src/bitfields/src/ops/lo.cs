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
        public static Bitfield8 lo(Bitfield16 src)
            => create(((byte)src.State));

        [MethodImpl(Inline), Op]
        public static Bitfield16 lo(Bitfield32 src)
            => create(((ushort)src.State));

        [MethodImpl(Inline), Op]
        public static Bitfield32 lo(Bitfield64 src)
            => create(((uint)src.State));

        [MethodImpl(Inline), Op, Closures(UInt8x16x32k)]
        public static Bitfield8<T> lo<T>(Bitfield16<T> src)
            where T : unmanaged
                => create(w8, generic<T>((byte)src.State16u));

        [MethodImpl(Inline), Op, Closures(UInt8x16x32k)]
        public static Bitfield16<T> lo<T>(Bitfield32<T> src)
            where T : unmanaged
                => create(w16, generic<T>((ushort)src.State32u));

        [MethodImpl(Inline), Op, Closures(UInt8x16x32k)]
        public static Bitfield32<T> lo<T>(Bitfield64<T> src)
            where T : unmanaged
                => create(w32, generic<T>((uint)src.State));
    }
}