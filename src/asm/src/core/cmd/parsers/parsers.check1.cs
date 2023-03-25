//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class AsmCoreCmd
    {
        [CmdOp("parsers/check")]
        void CheckParsers()
        {
            CheckDigitParsers();
        }

        void CheckDigitParsers()
        {
            var input = "01001101";
            // var count = Digital.parse(input, out GBlock64<BinaryDigit> dst);
            // var digits = dst.Segment(0,count);
            // var parsed = Digital.format(digits);
            //Write(Demand.eq(input,parsed));
            CheckDigitParser(base2);
            CheckDigitParser(base10);
            CheckDigitParser(base16);
        }

        void CheckDigitParser(Base10 @base)
        {
            var parser = DigitParsers.chars(@base);
            var input = span("346610");
            var buffer = CharBlock32.Null;
            var count = parser.Parse(input, buffer.Data);
            var parsed = slice(buffer.Data,0,count);
            Write(text.format(Demand.eq(input,parsed)));
        }

        void CheckDigitParser(Base16 @base)
        {
            var parser = DigitParsers.chars(@base);
            var input = span("FA34CA");
            var buffer = CharBlock32.Null;
            var count = parser.Parse(input, buffer.Data);
            var parsed = slice(buffer.Data,0,count);
            Write(text.format(Demand.eq(input,parsed)));
        }

        void CheckDigitParser(Base2 @base)
        {
            var parser = DigitParsers.chars(@base);
            var input = span("11001101");
            var buffer = CharBlock32.Null;
            var count = parser.Parse(input, buffer.Data);
            var parsed = slice(buffer.Data,0,count);
            Write(text.format(Demand.eq(input,parsed)));
        }
    }
}