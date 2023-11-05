//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

partial struct Bitfields
{
    [MethodImpl(Inline), Op]
    public static Bitfield8 create(byte state)
        => new (state);

    [MethodImpl(Inline), Op]
    public static Bitfield16 create(ushort state)
        => new (state);

    [MethodImpl(Inline), Op]
    public static Bitfield32 create(uint state)
        => new (state);

    [MethodImpl(Inline), Op]
    public static Bitfield64 create(ulong state)
        => new (state);

    [MethodImpl(Inline), Op, Closures(UInt8k)]
    public static Bitfield8<T> create<T>(W8 w, T state)
        where T : unmanaged
            => new (state);

    [MethodImpl(Inline), Op, Closures(UInt8x16k)]
    public static Bitfield16<T> create<T>(W16 w, T state)
        where T : unmanaged
            => new (state);

    [MethodImpl(Inline), Op, Closures(UInt8x16x32k)]
    public static Bitfield32<T> create<T>(W32 w, T state)
        where T : unmanaged
            => new (state);

    [MethodImpl(Inline), Op, Closures(UnsignedInts)]
    public static Bitfield64<T> create<T>(W64 w, T state)
        where T : unmanaged
            => new (state);

    [MethodImpl(Inline), Op, Closures(Closure)]
    public static Bitfield<T> create<T>(BfDef model, T state)
        where T : unmanaged
            => new (model,state);

    [MethodImpl(Inline)]
    public static Bitfield<T,K> create<T,K>(string name, BfSegDef<K>[] segs, T state)
        where T : unmanaged
        where K : unmanaged
            => new (new BfDef<K>(name, segs, minsize(@readonly(segs))), state);

    [MethodImpl(Inline), Op, Closures(Closure)]
    public static Bitfield256<T> create<T>(Vector256<byte> widths, Vector256<T> state)
        where T : unmanaged
            => new (widths, state);

    [MethodImpl(Inline)]
    public static Bitfield256<E,T> create<E,T>(Vector256<byte> widths, Vector256<T> state)
        where E : unmanaged
        where T : unmanaged
            => new (widths, state);
}
