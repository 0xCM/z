//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [LiteralProvider]
    public static class HexFormatSpecs
    {
        /// <summary>
        /// The asci code of the '0' digit
        /// </summary>
        public const byte MinScalarCode = 48;

        /// <summary>
        /// The asci code of the '9' digit
        /// </summary>
        public const byte MaxScalarCode = 57;

        /// <summary>
        /// The asci code of the 'A' digit
        /// </summary>
        public const byte MinCharCodeU = 65;

        /// <summary>
        /// The asci code of the 'F' digit
        /// </summary>
        public const byte MaxCharCodeU = 70;

        /// <summary>
        /// The asci code of the 'a' digit
        /// </summary>
        public const byte MinCharCodeL = 97;

        /// <summary>
        /// The asci code of the 'f' digit
        /// </summary>
        public const byte MaxCharCodeL = 102;

        /// <summary>
        /// The uppercase hex format code
        /// </summary>
        public const string UC = CharText.X;

        /// <summary>
        /// The lowercase hex format code
        /// </summary>
        public const string LC = CharText.x;

        /// <summary>
        /// The delimiter used to separate hex numbers when rendering a hex data sequence
        /// </summary>
        public const char DataDelimiter = Chars.Space;

        /// <summary>
        /// The delimiter used to separate hex numbers when rendering a list of hex values
        /// </summary>
        public const char ListDelimiter = Chars.Comma;

        /// <summary>
        /// The maximum number of hex characters required to represent an 4-bit segment
        /// </summary>
        public const int Hex4Width = 1;

        /// <summary>
        /// The maximum number of hex characters required to represent an 8-bit segment
        /// </summary>
        public const int Hex8Width = 2;

        /// <summary>
        /// The maximum number of hex characters required to represent a 12-bit segment
        /// </summary>
        public const int Hex12Width = 3;

        /// <summary>
        /// The maximum number of hex characters required to represent a 16-bit segment
        /// </summary>
        public const int Hex16Width = 4;

        /// <summary>
        /// The maximum number of hex characters required to represent a 20-bit segment
        /// </summary>
        public const int Hex20Width = 5;

        /// <summary>
        /// The maximum number of hex characters required to represent a 24-bit segment
        /// </summary>
        public const int Hex24Width = 6;

        /// <summary>
        /// The maximum number of hex characters required to represent a 28-bit segment
        /// </summary>
        public const int Hex28Width = 7;

        /// <summary>
        /// The maximum number of hex characters required to represent a 32-bit segment
        /// </summary>
        public const int Hex32Width = 8;

        /// <summary>
        /// The maximum number of hex characters required to represent a 36-bit segment
        /// </summary>
        public const int Hex36Width = 9;

        /// <summary>
        /// The maximum number of hex characters required to represent a 40-bit segment
        /// </summary>
        public const int Hex40Width = 10;

        /// <summary>
        /// The maximum number of hex characters required to represent a 40-bit segment
        /// </summary>
        public const int Hex44Width = 11;

        /// <summary>
        /// The maximum number of hex characters required to represent a 40-bit segment
        /// </summary>
        public const int Hex48Width = 12;

        /// <summary>
        /// The maximum number of hex characters required to represent a 40-bit segment
        /// </summary>
        public const int Hex52Width = 13;

        /// <summary>
        /// The maximum number of hex characters required to represent a 64-bit number
        /// </summary>
        public const int Hex64Width = 16;

        /// <summary>
        /// Standard hex specifier that leads the numeric content
        /// </summary>
        public const string PreSpec = "0x";

        /// <summary>
        /// Standard hex specifier that trails the numeric content
        /// </summary>
        public const string PostSpec = "h";

        /// <summary>
        /// Standard hex specifier that trails the numeric content
        /// </summary>
        public const char PostSpecChar = Chars.h;

        public const char PreSpec0 = Chars.D0;

        public const char PreSpec1 = Chars.x;

        public const string SmallHexSpec = "x4";

        public const string HexSpec = "x";

        public const string HexSpecU = "X";

        /// <summary>
        /// Lowercase format specifier for a segment of width <see cref="Hex4Width"/>
        /// </summary>
        public const string Hex4Spec = "x1";

        /// <summary>
        /// Lowercase format specifier for a segment of width <see cref="Hex8Width"/>
        /// </summary>
        public const string Hex8Spec = "x2";

        /// <summary>
        /// Lowercase format specifier for a segment of width <see cref="Hex12Width"/>
        /// </summary>
        public const string Hex12Spec = "x3";

        /// <summary>
        /// Lowercase format specifier for a segment of width <see cref="Hex16Width"/>
        /// </summary>
        public const string Hex16Spec = "x4";

        /// <summary>
        /// Lowercase format specifier for a segment of width <see cref="Hex20Width"/>
        /// </summary>
        public const string Hex20Spec = "x5";

        /// <summary>
        /// Lowercase format specifier for a segment of width <see cref="Hex24Width"/>
        /// </summary>
        public const string Hex24Spec = "x6";

        /// <summary>
        /// Lowercase format specifier for a segment of width <see cref="Hex28Width"/>
        /// </summary>
        public const string Hex28Spec = "x7";

        /// <summary>
        /// Lowercase format specifier for a segment of width <see cref="Hex32Width"/>
        /// </summary>
        public const string Hex32Spec = "x8";

        /// <summary>
        /// Lowercase format specifier for a segment of bit-width 36
        /// </summary>
        public const string Hex36Spec = "x9";

        /// <summary>
        /// Lowercase format specifier for a segment of bit-width 40
        /// </summary>
        public const string Hex40Spec = "x10";

        /// <summary>
        /// Lowercase format specifier for a segment of bit-width 44
        /// </summary>
        public const string Hex44Spec = "x11";

        /// <summary>
        /// Lowercase format specifier for a segment of bit-width 48
        /// </summary>
        public const string Hex48Spec = "x12";

        /// <summary>
        /// Lowercase format specifier for a segment of bit-width 52
        /// </summary>
        public const string Hex52Spec = "x13";

        /// <summary>
        /// Lowercase format specifier for a segment of bit-width 56
        /// </summary>
        public const string Hex56Spec = "x14";

        /// <summary>
        /// Lowercase format specifier for a segment of bit-width 60
        /// </summary>
        public const string Hex60Spec = "x15";

        /// <summary>
        /// Lowercase format specifier for a segment of bit-width 64
        /// </summary>
        public const string Hex64Spec = "x16";

        /// <summary>
        /// Uppercase format specifier for a segment of width <see cref="Hex4Width"/>
        /// </summary>
        public const string Hex4SpecUC = "X1";

        /// <summary>
        /// Uppercase format specifier for a segment of width <see cref="Hex8Width"/>
        /// </summary>
        public const string Hex8SpecUC = "X2";

        /// <summary>
        /// Uppercase format specifier for a segment of width <see cref="Hex12Width"/>
        /// </summary>
        public const string Hex12SpecUC = "X3";

        /// <summary>
        /// Uppercase format specifier for a segment of bit-width 16
        /// </summary>
        public const string Hex16SpecUC = "X4";

        /// <summary>
        /// Uppercase format specifier for a segment of bit-width 20
        /// </summary>
        public const string Hex20SpecUC = "X5";

        /// <summary>
        /// Uppercase format specifier for a segment of bit-width 24
        /// </summary>
        public const string Hex24SpecUC = "X6";

        /// <summary>
        /// Uppercase format specifier for a segment of bit-width 28
        /// </summary>
        public const string Hex28SpecUC = "X7";

        /// <summary>
        /// Uppercase format specifier for a segment of bit-width 32
        /// </summary>
        public const string Hex32SpecUC = "X8";

        /// <summary>
        /// Uppercase format specifier for a segment of bit-width 36
        /// </summary>
        public const string Hex36SpecUC = "X9";

        /// <summary>
        /// Uppercase format specifier for a segment of bit-width 40
        /// </summary>
        public const string Hex40SpecUC = "X10";

        /// <summary>
        /// Uppercase format specifier for a segment of bit-width 44
        /// </summary>
        public const string Hex44SpecUC = "X11";

        /// <summary>
        /// Uppercase format specifier for a segment of bit-width 48
        /// </summary>
        public const string Hex48SpecUC = "X12";

        /// <summary>
        /// Uppercase format specifier for a segment of bit-width 52
        /// </summary>
        public const string Hex52SpecUC = "X13";

        /// <summary>
        /// Uppercase format specifier for a segment of bit-width 56
        /// </summary>
        public const string Hex56SpecUC = "X14";

        /// <summary>
        /// Uppercase format specifier for a segment of bit-width 60
        /// </summary>
        public const string Hex60SpecUC = "X15";

        /// <summary>
        /// Uppercase format specifier for a segment of bit-width 64
        /// </summary>
        public const string Hex64SpecUC = "X16";

        /// <summary>
        /// Selects either the uppercase format code 'X' or lowercase format code 'x'
        /// </summary>
        /// <param name="upper">True for uppercase, false for lowercase</param>
        [MethodImpl(Inline)]
        public static char CaseSpec(bool upper)
            => upper ? 'X' : 'x';

        [MethodImpl(Inline)]
        public static string CaseSpec(LetterCaseKind @case)
            => @case == LetterCaseKind.Upper ? "X" : "x";
    }
}