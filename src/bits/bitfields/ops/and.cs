//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct Bitfields
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T mask<T>(in Bitfield256<T> src, byte index)
            where T : unmanaged
                => BitMasks.lo<T>(src.SegWidth(index));

        [MethodImpl(Inline)]
        public static T mask<E,T>(in Bitfield256<E,T> src, E index)
            where E : unmanaged
            where T : unmanaged
                => BitMasks.lo<T>(src.SegWidth(index));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T and<T>(T a, T b)
            where T : unmanaged
        {
            if(width<T>() == 8)
                return @as<byte,T>(math.and(bw8(a), bw8(b)));
            else if(width<T>() == 16)
                return @as<ushort,T>(math.and(bw16(a), bw16(b)));
            else if(width<T>() == 32)
                return @as<uint,T>(math.and(bw32(a), bw32(b)));
            else
                return @as<ulong,T>(math.and(bw64(a), bw64(b)));
        }
    }
}