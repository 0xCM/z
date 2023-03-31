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
        public static byte seg(Bitfield8 src, byte i0, byte i1)
            => bits.extract(src.State, i0, i1);

        [MethodImpl(Inline), Op]
        public static ushort seg(Bitfield16 src, byte i0, byte i1)
            => bits.extract(src.State, i0, i1);

        [MethodImpl(Inline), Op]
        public static uint seg(Bitfield32 src, byte i0, byte i1)
            => bits.extract(src.State, i0, i1);

        [MethodImpl(Inline), Op]
        public static ulong seg(Bitfield64 src, byte i0, byte i1)
            => bits.extract(src.State, i0, i1);

        [MethodImpl(Inline), Op, Closures(UInt8k)]
        public static T seg<T>(Bitfield8<T> src, byte i0, byte i1)
            where T : unmanaged
                => @as<T>(bits.extract(src.State8u, i0, i1));

        [MethodImpl(Inline), Op, Closures(UInt8x16k)]
        public static T seg<T>(Bitfield16<T> src, byte i0, byte i1)
            where T : unmanaged
                => @as<T>(bits.extract(src.State16u, i0, i1));

        [MethodImpl(Inline), Op, Closures(UInt8x16x32k)]
        public static T seg<T>(Bitfield32<T> src, byte i0, byte i1)
            where T : unmanaged
                => @as<T>(bits.extract(src.State32u, i0, i1));

        [MethodImpl(Inline), Op, Closures(UnsignedInts)]
        public static T seg<T>(Bitfield64<T> src, byte i0, byte i1)
            where T : unmanaged
                => @as<T>(bits.extract(src.State, i0, i1));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T seg<T>(in Bitfield<T> src, byte index)
            where T : unmanaged
        {
            ref readonly var spec = ref skip(src.SegSpecs,index);
            return gbits.extract(src.State, (byte)spec.MinPos, (byte)spec.MaxPos);
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T seg<T,K>(in Bitfield<T,K> src, byte index)
            where T : unmanaged
            where K : unmanaged
        {
            ref readonly var spec = ref skip(src.SegSpecs, index);
            return gbits.extract(src.State, (byte)spec.MinPos, (byte)spec.MaxPos);
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T seg<T>(in Bitfield256<T> src, byte index)
            where T : unmanaged
                => gmath.and(cpu.vcell(src.State, index), src.Mask(index));

        [MethodImpl(Inline)]
        public static T seg<E,T>(in Bitfield256<E,T> src, E index)
            where E : unmanaged
            where T : unmanaged
                => gmath.and(cpu.vcell(src.State, bw8(index)), src.Mask(index));
    }
}