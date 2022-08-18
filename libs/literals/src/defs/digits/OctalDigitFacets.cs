//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [LiteralProvider(octal_digits)]
    public readonly struct OctalDigitFacets
    {
        public const OctalDigitCode MinCode = OctalDigitCode.o0;

        public const OctalDigitCode MaxCode = OctalDigitCode.o7;

        public const OctalDigitSym MinSymbol = OctalDigitSym.o0;

        public const OctalDigitSym MaxSymbol = OctalDigitSym.o7;

        public const OctalDigitValue MinDigit = OctalDigitValue.o0;

        public const OctalDigitValue MaxDigit = OctalDigitValue.o7;
    }
}