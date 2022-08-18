//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [LiteralProvider(hex_digits)]
    public readonly struct HexDigitFacets
    {
        public const HexDigitCode MinScalarCode = HexDigitCode.x0;

        public const HexDigitCode MaxScalarCode = HexDigitCode.x9;

        public const HexDigitCode MinLetterCodeL = HexDigitCode.a;

        public const HexDigitCode MaxLetterCodeL = HexDigitCode.f;

        public const HexDigitCode MinLetterCodeU = HexDigitCode.A;

        public const HexDigitCode MaxLetterCodeU = HexDigitCode.F;

        public const HexDigitSym MinScalarSymbol = HexDigitSym.x0;

        public const HexDigitSym MaxScalarSymbol = HexDigitSym.x9;

        public const HexDigitSym MinLetterSymbolL = HexDigitSym.a;

        public const HexDigitSym MaxLetterSymbolL = HexDigitSym.f;

        public const HexDigitSym MinLetterSymbolU = HexDigitSym.A;

        public const HexDigitSym MaxLetterSymbolU = HexDigitSym.F;

        public const HexDigitValue MinDigit = HexDigitValue.x0;

        public const HexDigitValue MaxDigit = HexDigitValue.F;
    }
}