//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Globalization;

    [ApiHost]
    public readonly struct HexNumericParser
    {
        static string clear(string src)
            => src.Remove("0x").RemoveAny('h');

        public static ParseResult<ulong> parse64u(string src)
        {
            if(ulong.TryParse(clear(src), NumberStyles.HexNumber, null, out ulong value))
                return ParseResult.parsed(src,value);
            else
                return ParseResult.unparsed<ulong>(src);
        }
    }
}