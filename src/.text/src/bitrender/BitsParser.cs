//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost]
    public class BitsParser
    {
        public static bool parse<N,T>(string src, out bits<N,T> dst)
            where N : unmanaged, ITypeNat
            where T : unmanaged
        {
            var result = parse<N,T>(src, default(N), out var bits);
            dst = bits.Packed;
            return result;
        }

        public static bool parse<N,T>(string src, N n, out bits<T> dst)
            where N : unmanaged, ITypeNat
            where T : unmanaged
        {
            var result = false;
            var width = (byte)n.NatValue;
            if(size<T>() == 1)
            {
                result = BitParser.parse(src, width, out byte x);
                dst = @as<byte,T>(x);
            }
            else if (size<T>() == 2)
            {
                result = BitParser.parse(src, width, out ushort x);
                dst = @as<ushort,T>(x);
            }
            else if (size<T>() == 4)
            {
                result = BitParser.parse(src, width, out uint x);
                dst = @as<uint,T>(x);
            }
            else if (size<T>() == 8)
            {
                result = BitParser.parse(src, width, out ulong x);
                dst = @as<ulong,T>(x);
            }
            else
            {
                dst = default;
                sys.@throw(no<T>());
            }

            return result;
        }
    }
}