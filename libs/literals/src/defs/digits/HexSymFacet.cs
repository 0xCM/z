//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static HexLowerSym;
    using static HexUpperSym;

    using L = HexLowerSym;

    [SymSource(hex_digits, NBK.Base16)]
    public enum HexSymFacet : ushort
    {
        /// <summary>
        /// The 'x0' code
        /// </summary>
        FirstNumber = L.x0,

        /// <summary>
        /// The 'x9' code
        /// </summary>
        LastNumber = L.x9,

        /// <summary>
        /// The 'a' code
        /// </summary>
        FirstLetterLo = a,

        /// <summary>
        /// The 'f' code
        /// </summary>
        LastLetterLo = f,

        /// <summary>
        /// The 'a' code
        /// </summary>
        FirstLetterUp = A,

        /// <summary>
        /// The 'f' code
        /// </summary>
        LastLetterUp = B,

        /// <summary>
        /// The value to subtract from a symbolic digit [a..b] to compute an index in the range [0..15]
        /// </summary>
        LetterOffsetLo = FirstLetterLo - LastNumber + FirstNumber - 1,

        /// <summary>
        /// The value to subtract from a symbolic digit [A..F] to compute an index in the range [0..15]
        /// </summary>
        LetterOffsetUp = FirstLetterUp - LastNumber + FirstNumber - 1,

        /// <summary>
        /// The value to subtract from a symbolic digit [0..9] to compute an index in the range [0..15]
        /// </summary>
        NumberOffset = FirstNumber,

        /// <summary>
        /// The numeral declaration count
        /// </summary>
        NumberCount = LastNumber - FirstNumber + 1,

        /// <summary>
        /// The lettr declaration count
        /// </summary>
        LetterCount = LastLetterLo - FirstLetterLo + 1,
    }
}