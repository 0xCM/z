//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

partial struct Bitfields
{
    [MethodImpl(Inline), Op]
    public static BitMask mask(byte width, uint offset)
        => (ulong)Pow2.m1(width) << (int)offset;

    [MethodImpl(Inline), Op]
    public static BitMask mask(byte value)
        => new (value);

    [MethodImpl(Inline), Op]
    public static BitMask mask(ushort value)
        => new (value);

    [MethodImpl(Inline), Op]
    public static BitMask mask(uint value)
        => new (value);

    [MethodImpl(Inline), Op]
    public static BitMask mask(ulong value)
        => new (value);

    [MethodImpl(Inline), Op]
    public static BitMask mask(byte width, ulong value)
        => new (width, value);

    [MethodImpl(Inline), Op, Closures(Closure)]
    public static T mask<T>(byte width, uint offset)
        => generic<T>((ulong)Pow2.m1(width) << (int)offset);

    [MethodImpl(Inline), Op]
    public static BitMask mask(W8 w, byte i0, byte i1)
        => new ((byte)w, ones(w, i0, i1));

    [MethodImpl(Inline), Op]
    public static BitMask mask(W16 w, byte i0, byte i1)
        => new ((byte)w, ones(w, i0, i1));

    [MethodImpl(Inline), Op]
    public static BitMask mask(W32 w, byte i0, byte i1)
        => new ((byte)w, ones(w, i0, i1));

    [MethodImpl(Inline), Op]
    public static BitMask mask(W64 w, byte i0, byte i1)
        => new ((byte)w, ones(w, i0, i1));

    [Op]
    public static BitMask mask(NativeSize size, byte i0, byte i1)
        => size.Code switch{
            NativeSizeCode.W8 => mask(w8, i0, i1),
            NativeSizeCode.W16 => mask(w16, i0, i1),
            NativeSizeCode.W32 => mask(w32, i0, i1),
            NativeSizeCode.W64 => mask(w64, i0, i1),
            _ => BitMask.Empty
        };

    [MethodImpl(Inline), Op, Closures(Closure)]
    public static T mask<T>(in Bitfield256<T> src, byte index)
        where T : unmanaged
            => BitMasks.lo<T>(src.SegWidth(index));

    [MethodImpl(Inline)]
    public static T mask<E,T>(in Bitfield256<E,T> src, E index)
        where E : unmanaged
        where T : unmanaged
            => BitMasks.lo<T>(src.SegWidth(index));
}