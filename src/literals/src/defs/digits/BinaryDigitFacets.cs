//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [LiteralProvider(binary_digits)]
    public readonly struct BinaryDigitFacets
    {
        public const BinaryDigitCode MinCode = BinaryDigitCode.b0;

        public const BinaryDigitCode MaxCode = BinaryDigitCode.b1;

        public const BinaryDigitSym MinSymbol = BinaryDigitSym.b0;

        public const BinaryDigitSym MaxSymbol = BinaryDigitSym.b0;

        public const BinaryDigitValue MinDigit = BinaryDigitValue.b0;

        public const BinaryDigitValue MaxDigit = BinaryDigitValue.b0;
    }
}