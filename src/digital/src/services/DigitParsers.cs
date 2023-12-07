//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

using C = AsciCode;

public class DigitParsers
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
    public static bool parse(Base10 @base, ReadOnlySpan<char> src, out ushort dst)
    {
        return NumericParser.parse(@base, src, out dst);
    }

    [Op]
    public static bool parse(Base10 @base, ReadOnlySpan<C> src, out ushort dst)
    {
        var storage = CharBlock16.Null;
        var buffer = storage.Data;
        AsciSymbols.convert(src, buffer);
        return NumericParser.parse(@base, buffer, out dst);
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

    sealed class Base10SeqParser : DigitSeqParser<Base10, DecimalDigitValue>
    {
        public override uint Parse(ReadOnlySpan<char> src, Span<DecimalDigitValue> dst)
        {
            var offset = 0u;
            var i=offset;
            var j=0u;
            var imax = src.Length - 1;
            while(i <= imax)
            {
                ref readonly var c = ref skip(src, i++);
                if(SQ.space(c) && j==0)
                    continue;

                if(Digital.test(Base, c))
                    seek(dst, j++) = (DecimalDigitValue)(AsciCode.d9 - (AsciCode)c);
                else
                    break;
            }
            return j;
        }
    }

    abstract class DigitCharParser<B> : BasedParser<B>, ISpanSeqParser<char,char>
        where B : unmanaged, INumericBase
    {

        public uint Parse(ReadOnlySpan<char> src, Span<char> dst)
            => digits<B>(src, dst);
    }

    class Base2Digits : DigitCharParser<Base2>
    {

    }

    class Base10Digits : DigitCharParser<Base10>
    {

    }

    class Base16Digits : DigitCharParser<Base16>
    {
    }

    abstract class SpanValueParser<B,V> :  BasedParser<B>, ISpanValueParser<char,V>
        where B : unmanaged, INumericBase
        where V : unmanaged
    {
        public abstract bool Parse(ReadOnlySpan<char> src, out V dst);
    }

    abstract class Base16ValueParser<V> : SpanValueParser<Base16,V>
        where V : unmanaged
    {

    }

    sealed class Base16U32Parser : Base16ValueParser<uint>
    {
        public override bool Parse(ReadOnlySpan<char> src, out uint dst)
        {
            const byte MaxDigitCount = 8;
            var storage = 0ul;
            var output = recover<HexDigitValue>(bytes(storage));
            dst = 0;
            var count = min(src.Length, MaxDigitCount);
            var j=0;
            var outcome = true;
            for(var i=count-1; i>=0; i--)
            {
                if(Digital.digit(Base, skip(src,i), out var d))
                    seek(output, j++) = d;
                else
                    return false;
            }

            for(var k=0; k<j; k++)
                dst |= ((uint)skip(output, k) << k*4);
            return true;
        }
    }
}
