//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using C = AsciCode;

    public readonly partial struct DigitParsers
    {
        public static ISpanSeqParser<char,char> chars(Base2 @base)
            => new Base2Digits();

        public static ISpanSeqParser<char,char> chars(Base10 @base)
            => new Base10Digits();

        public static ISpanSeqParser<char,char> chars(Base16 @base)
            => new Base16Digits();

        public static ISpanSeqParser<char,DecimalDigitValue> values(Base10 @base)
            => new Base10SeqParser();

        public static ISpanValueParser<char,uint> value(Base16 @base, W32 w)
            => new Base16U32Parser();

        public static uint digits<B>(ReadOnlySpan<char> src, Span<char> dst)
            where B : unmanaged, INumericBase
        {
            var count = 0u;
            if(typeof(B) == typeof(Base2))
                count = Digital.digits(@base2, src, dst);
            else if(typeof(B) == typeof(Base10))
                count = Digital.digits(@base10, src, dst);
            else if(typeof(B) == typeof(Base16))
                count = Digital.digits(@base16, src, dst);
            else
                throw no<B>();
            return count;
        }

        [Op]
        public static bool parse(Base10 @base, ReadOnlySpan<C> src, out ushort dst)
        {
            var storage = CharBlock16.Null;
            var buffer = storage.Data;
            Asci.convert(src, buffer);
            return NumericParser.parse(@base, buffer, out dst);
        }

        [Op]
        public static Outcome parse(Base10 @base, ReadOnlySpan<C> src, ref uint i, out ushort dst)
        {
            dst = default;
            var result = Outcome.Success;
            var input = slice(src,i);
            var length = input.Length;
            var digits = Digital.digits(n16, base10, input);
            if(digits.Length == 0)
                result = (false,"No digits found");
            else
            {
                result = parse(@base, digits, out dst);
                if(result.Ok)
                    i += (uint)digits.Length;
            }
            return result;
        }

        public static Outcome parse(Base10 @base, in AsciLineCover src, ref uint i, out ushort dst)
        {
            var i0 = i;
            var result = Outcome.Success;
            dst = default;
            var data = slice(src.Codes, i);
            var length = data.Length;
            for(; i<length; i++)
            {
                ref readonly var c = ref skip(data,i);
                if(SQ.whitespace(c))
                    continue;

                if(Digital.test(@base, c))
                {
                    result = parse(@base, slice(data,i), out dst);
                    break;
                }
            }
            return result;
        }
    }
}