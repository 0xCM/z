//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct DigitParsers
    {
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
    }
}