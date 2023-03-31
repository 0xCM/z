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
        public static T not<T>(T a)
            where T : unmanaged
        {
            if(width<T>() == 8)
                return @as<byte,T>(math.not(bw8(a)));
            else if(width<T>() == 16)
                return @as<ushort,T>(math.not(bw16(a)));
            else if(width<T>() == 32)
                return @as<uint,T>(math.not(bw32(a)));
            else
                return @as<ulong,T>(math.not(bw64(a)));
        }
    }
}