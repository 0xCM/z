//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct Bitfields
    {
        [MethodImpl(Inline), Op]
        public static Bitfield8 create(byte state)
            => new Bitfield8(state);

        [MethodImpl(Inline), Op]
        public static Bitfield16 create(ushort state)
            => new Bitfield16(state);

        [MethodImpl(Inline), Op]
        public static Bitfield32 create(uint state)
            => new Bitfield32(state);

        [MethodImpl(Inline), Op]
        public static Bitfield64 create(ulong state)
            => new Bitfield64(state);

        [MethodImpl(Inline), Op, Closures(UInt8k)]
        public static Bitfield8<T> create<T>(W8 w, T state)
            where T : unmanaged
                => new Bitfield8<T>(state);

        [MethodImpl(Inline), Op, Closures(UInt8x16k)]
        public static Bitfield16<T> create<T>(W16 w, T state)
            where T : unmanaged
                => new Bitfield16<T>(state);

        [MethodImpl(Inline), Op, Closures(UInt8x16x32k)]
        public static Bitfield32<T> create<T>(W32 w, T state)
            where T : unmanaged
                => new Bitfield32<T>(state);

        [MethodImpl(Inline), Op, Closures(UnsignedInts)]
        public static Bitfield64<T> create<T>(W64 w, T state)
            where T : unmanaged
                => new Bitfield64<T>(state);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Bitfield<T> create<T>(BfModel model, T state)
            where T : unmanaged
                => new Bitfield<T>(model,state);

        [MethodImpl(Inline)]
        public static Bitfield<T,K> create<T,K>(BfOrigin origin, string name, BfSegModel<K>[] segs, T state)
            where T : unmanaged
            where K : unmanaged
                => new Bitfield<T,K>(new BfModel<K>(origin, name, segs, PolyBits.minsize(@readonly(segs))), state);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Bitfield256<T> create<T>(Vector256<byte> widths, Vector256<T> state)
            where T : unmanaged
                => new Bitfield256<T>(widths, state);

        [MethodImpl(Inline)]
        public static Bitfield256<E,T> create<E,T>(Vector256<byte> widths, Vector256<T> state)
            where E : unmanaged
            where T : unmanaged
                => new Bitfield256<E,T>(widths, state);
    }
}