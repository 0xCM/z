//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public readonly partial struct Hex
    {
        const NumericKind Closure = UnsignedInts;
    }
}

namespace global
{
    using Z0;
    
    [ApiComplete(ApiName)]
    public partial class hex
    {
        public const string ApiName = "globals.hex";

        [Parser]
        public static bool parse(string src, out Hash8 dst)
        {
            var result = HexParser.parse(src, out byte hex);
            dst = 0;
            if(result)
                dst = hex;
            return result;
        }

        [Parser]
        public static bool parse(string src, out Hash16 dst)
        {
            var result = HexParser.parse(src, out ushort hex);
            dst = 0;
            if(result)
                dst = hex;
            return result;
        }

        [Parser]
        public static bool parse(string src, out Hash32 dst)
        {
            var result = HexParser.parse(src, out uint hex);
            dst = 0;
            if(result)
                dst = hex;
            return result;
        }

        [Parser]
        public static bool parse(string src, out Hash64 dst)
        {
            var result = HexParser.parse(src, out ulong hex);
            dst = 0;
            if(result)
                dst = hex;
            return result;
        }
    }
}