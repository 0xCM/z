//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Globalization;

    using static core;

    partial struct Math128
    {
        public static Outcome parse(string src, out uint128 dst)
        {
            const NumberStyles ParseFlags = NumberStyles.HexNumber;

            dst = default;
            if(empty(src))
                return (false, "Empty input");

            var input = HexFormatter.ClearPrespec(src);
            var digits = input.Length;
            var result = Outcome.Failure;

            if(digits <= 16)
            {
                if(ulong.TryParse(input, ParseFlags, null, out var lo))
                {
                    dst = lo;
                    result = true;
                }
                else
                {
                    result = (false, string.Format("Unable to parse '{0}' to fill the low target bits", text.format(input)));
                }
            }
            else
            {
                var hiSrc = slice(input,0,16);
                var loSrc = slice(input,16);
                if(ulong.TryParse(hiSrc, ParseFlags, null, out var hi) && ulong.TryParse(loSrc, ParseFlags, null, out var lo))
                {
                    dst = (lo,hi);
                    result = true;
                }

            }
            return result;
        }
    }
}