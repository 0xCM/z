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
        public static T xor<T>(T a, T b)
            where T : unmanaged
        {
            if(width<T>() == 8)
                return @as<byte,T>(math.xor(bw8(a), bw8(b)));
            else if(width<T>() == 16)
                return @as<ushort,T>(math.xor(bw16(a), bw16(b)));
            else if(width<T>() == 32)
                return @as<uint,T>(math.xor(bw32(a), bw32(b)));
            else
                return @as<ulong,T>(math.xor(bw64(a), bw64(b)));
        }
    }
}