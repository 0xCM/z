//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using C = AsciCode;
    using S = AsciLetterSym;

    [LiteralProvider(text)]
    public readonly struct AsciCodeFacets
    {
        /// <summary>
        /// The first asci code
        /// </summary>
        public const C MinCode = 0;

        /// <summary>
        /// The last asci code
        /// </summary>
        public const C MaxCode = (C)127;

        /// <summary>
        /// The code of the first lowercase letter
        /// </summary>
        public const C MinLowerLetter = C.a;

        /// <summary>
        /// The code of the last lowercase letter
        /// </summary>
        public const C MaxLowerLetter = C.z;

        /// <summary>
        /// The code of the first uppercase letter
        /// </summary>
        public const C MinUpperLetter = C.A;

        /// <summary>
        /// The code of the last uppercase letter
        /// </summary>
        public const C MaxUpperLetter = C.Z;

        /// <summary>
        /// The first decimal digit code, '0'
        /// </summary>
        public const C MinDigitCode = (C)C.d0;

        /// <summary>
        /// The last decimal digit code, '9'
        /// </summary>
        public const C MaxDigitCode = (C)C.d9;

        /// <summary>
        /// The first binary digit code
        /// </summary>
        public const C MinBinaryDigitCode = (C)C.d0;

        /// <summary>
        /// The last binary digit code
        /// </summary>
        public const C MaxBinaryDigitCode = (C)C.d1;

        /// <summary>
        /// The first binary digit code
        /// </summary>
        public const C MinOctalDigitCode = (C)C.d0;

        /// <summary>
        /// The last binary digit code
        /// </summary>
        public const C MaxOctalDigitCode = (C)C.d7;

        /// <summary>
        /// The first digit code
        /// </summary>
        public const C MinHexDigitCode = (C)C.d0;

        /// <summary>
        /// The last declared code
        /// </summary>
        public const C MaxHexDigitCode = (C)C.d9;

        /// <summary>
        /// The code of the first lowercase hex letter
        /// </summary>
        public const S MinLowerHexLetter = S.a;

        /// <summary>
        /// The code of the first lowercase hex letter
        /// </summary>
        public const S MaxLowerHexLetter = S.f;

        /// <summary>
        /// The code of the first uppercase hex letter
        /// </summary>
        public const S MinUpperHexLetter = S.A;

        /// <summary>
        /// The code of the first uppercase hex letter
        /// </summary>
        public const S MaxUpperHexLetter = S.F;

        /// <summary>
        /// The numeric value of the last asci code
        /// </summary>
        public const byte MinCodeValue = 0;

        /// <summary>
        /// The numeric value of the last asci code
        /// </summary>
        public const byte MaxCodeValue = 127;

        /// <summary>
        /// The count of lowercase letters
        /// </summary>
        public const byte LowerLetterCount = MaxLowerLetter - MinLowerLetter + 1;

        /// <summary>
        /// The count of uppercase letters
        /// </summary>
        public const byte UpperLetterCount = MaxUpperLetter - MinUpperLetter + 1;

        /// <summary>
        /// The count of binary digits
        /// </summary>
        public const byte BinaryDigitCount = MaxBinaryDigitCode - MinBinaryDigitCode + 1;

        /// <summary>
        /// The count of octal digits
        /// </summary>
        public const byte OctalDigitCount = MaxOctalDigitCode - MinOctalDigitCode + 1;

        /// <summary>
        /// The count of decimal digits
        /// </summary>
        public const byte DecimalDigitCount = MaxDigitCode - MinDigitCode + 1;

        /// <summary>
        /// The count of hex digits (excluding letters)
        /// </summary>
        public const byte HexDigitCount = MaxHexDigitCode - MinHexDigitCode + 1;

        /// <summary>
        /// The count of lowercase hex letters
        /// </summary>
        public const byte HexLowerLetterCount = MaxLowerHexLetter - MinLowerHexLetter + 1;

        /// <summary>
        /// The count of uppercase hex letters
        /// </summary>
        public const byte HexUpperLetterCount = MaxUpperHexLetter - MinUpperHexLetter + 1;

        /// <summary>
        /// The count of hex symbols using lowercase letters
        /// </summary>
        public const byte HexLowerSymbolCount = HexDigitCount + HexLowerLetterCount;

        /// <summary>
        /// The count of hex symbols using uppercase letters
        /// </summary>
        public const byte HexUpperSymbolCount = HexDigitCount + HexUpperLetterCount;
    }
}