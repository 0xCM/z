//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
global using static global.literals;
global using static global.lib;
//global using static global.api;
using static Z0.ApiAtomic;
namespace global
{
    [ApiComplete(ApiName)]
    public partial class lib
    {
        public const string ApiName = globals + dot + nameof(lib);

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
