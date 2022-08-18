//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [LiteralProvider(decimal_digits)]
    public readonly struct DecimalDigitFacets
    {
        public const DecimalDigitCode MinCode = DecimalDigitCode.d0;

        public const DecimalDigitCode MaxCode = DecimalDigitCode.d9;

        public const DecimalDigitSym MinSymbol = DecimalDigitSym.d0;

        public const DecimalDigitSym MaxSymbol = DecimalDigitSym.d0;

        public const DecimalDigitValue MinDigit = DecimalDigitValue.d0;

        public const DecimalDigitValue MaxDigit = DecimalDigitValue.d0;
    }
}