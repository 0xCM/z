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
        public static T scatter<T>(T src, T mask)
            where T : unmanaged
        {
            if(width<T>() == 8)
                return @as<byte,T>(bits.scatter(bw8(src), bw8(mask)));
            else if(width<T>() == 16)
                return @as<ushort,T>(bits.scatter(bw16(src), bw16(mask)));
            else if(width<T>() == 32)
                return @as<uint,T>(bits.scatter(bw32(src), bw32(mask)));
            else
                return @as<ulong,T>(bits.scatter(bw64(src), bw64(mask)));
        }
    }
}