//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

partial struct Bitfields
{
    [MethodImpl(Inline), Op]
    public static ulong extract<E>(BfInterval<E> field, ulong src)
        where E : unmanaged, Enum
            => bits.extract(src, (byte)field.MinPos, field.MaxPos);

    [MethodImpl(Inline), Op]
    public static byte extract(Bitfield8 src, byte i0, byte i1)
        => bits.extract(src.State, i0, i1);

    [MethodImpl(Inline), Op]
    public static ushort extract(Bitfield16 src, byte i0, byte i1)
        => bits.extract(src.State, i0, i1);

    [MethodImpl(Inline), Op]
    public static uint extract(Bitfield32 src, byte i0, byte i1)
        => bits.extract(src.State, i0, i1);

    [MethodImpl(Inline), Op]
    public static ulong extract(Bitfield64 src, byte i0, byte i1)
        => bits.extract(src.State, i0, i1);

    [MethodImpl(Inline), Op, Closures(UInt8k)]
    public static T extract<T>(Bitfield8<T> src, byte i0, byte i1)
        where T : unmanaged
            => @as<T>(bits.extract(src.State8u, i0, i1));

    [MethodImpl(Inline), Op, Closures(UInt8x16k)]
    public static T extract<T>(Bitfield16<T> src, byte i0, byte i1)
        where T : unmanaged
            => @as<T>(bits.extract(src.State16u, i0, i1));

    [MethodImpl(Inline), Op, Closures(UInt8x16x32k)]
    public static T extract<T>(Bitfield32<T> src, byte i0, byte i1)
        where T : unmanaged
            => @as<T>(bits.extract(src.State32u, i0, i1));

    [MethodImpl(Inline), Op, Closures(UnsignedInts)]
    public static T extract<T>(Bitfield64<T> src, byte i0, byte i1)
        where T : unmanaged
            => @as<T>(bits.extract(src.State, i0, i1));

    [MethodImpl(Inline), Op, Closures(Closure)]
    public static T extract<T>(in Bitfield<T> src, byte index)
        where T : unmanaged
    {
        ref readonly var spec = ref skip(src.SegSpecs,index);
        return gbits.extract(src.State, (byte)spec.MinPos, (byte)spec.MaxPos);
    }

    [MethodImpl(Inline)]
    public static T extract<F,S,T>(BfDataset<F> dataset, F field, S src)
        where F : unmanaged, Enum
        where T : unmanaged
        where S : unmanaged
            => @as<S,T>(gpack.extract(dataset.Offset(field), dataset.Width(field), src));

    [MethodImpl(Inline)]
    public static T extract<F,T>(BfDataset<F,T> dataset, F field, T src)
        where F : unmanaged, Enum
        where T : unmanaged
            => gpack.extract(dataset.Offset(field), dataset.Width(field), src);

    [MethodImpl(Inline), Op, Closures(Closure)]
    public static T extract<T>(T src, byte offset, byte width)
        where T : unmanaged
            => generic<T>(bits.extract(@bw64(src), offset, math.add(offset, width)));

    [MethodImpl(Inline), Op, Closures(Closure)]
    public static T extract<T,K>(in Bitfield<T,K> src, byte index)
        where T : unmanaged
        where K : unmanaged
    {
        ref readonly var spec = ref skip(src.SegSpecs, index);
        return gbits.extract(src.State, (byte)spec.MinPos, (byte)spec.MaxPos);
    }

    [MethodImpl(Inline), Op, Closures(Closure)]
    public static T extract<T>(in Bitfield256<T> src, byte index)
        where T : unmanaged
            => gmath.and(vcpu.vcell(src.State, index), src.Mask(index));

    [MethodImpl(Inline)]
    public static T extract<E,T>(in Bitfield256<E,T> src, E index)
        where E : unmanaged
        where T : unmanaged
            => gmath.and(vcpu.vcell(src.State, bw8(index)), src.Mask(index));            
}
