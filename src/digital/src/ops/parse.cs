//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using C = AsciCode;

    partial struct Digital
    {
        [Op]
        public static Outcome parse(Base10 @base, ReadOnlySpan<char> src, out ushort dst)
            => NumericParser.parse(@base, src, out dst);

        [Op]
        public static Outcome parse(Base10 @base, ReadOnlySpan<C> src, out ushort dst)
        {
            var storage = CharBlock16.Null;
            var buffer = storage.Data;
            AsciSymbols.convert(src, buffer);
            return NumericParser.parse(@base, buffer, out dst);
        }

        // [Op]
        // public static bool parse(Base10 @base, ReadOnlySpan<C> src, ref uint i, out ushort dst)
        // {
        //     dst = default;
        //     var result = Outcome.Success;
        //     var input = slice(src,i);
        //     var length = input.Length;
        //     var dig = digits(n16, base10, input);
        //     if(dig.Length == 0)
        //         result = (false,"No digits found");
        //     else
        //     {
        //         result = parse(@base, dig, out dst);
        //         if(result.Ok)
        //             i += (uint)dig.Length;
        //     }
        //     return result;
        // }

        public static bool parse(string src, out BinaryDigit dst)
        {
            var chars = span((src ?? EmptyString).Trim());
            var count = chars.Length;
            dst = default;
            if(count != 1)
                return false;
            ref readonly var c = ref first(chars);
            if(c == Chars.D0)
            {
                dst = BinaryDigitCode.b0;
                return true;
            }
            else if(c == Chars.D1)
            {
                dst = BinaryDigitCode.b1;
                return true;
            }
            return false;
        }
    }
}