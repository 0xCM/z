//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static HexSymFacet;

    using XF = HexSymFacet;

    partial struct Hex
    {
        [MethodImpl(Inline), Op]
        public static HexDigitValue digit(char src)
        {
            if(number(src))
                return (HexDigitValue)((HexSymFacet)src - NumberOffset);
            else
            {
                if(test(UpperCase, src))
                    return (HexDigitValue)((XF)src - LetterOffsetUp);
                else
                    return (HexDigitValue)((XF)src - LetterOffsetLo);
            }
        }

        [MethodImpl(Inline), Op]
        public static HexDigitValue digit(AsciCode src)
        {
            if(number(src))
                return (HexDigitValue)((HexSymFacet)src - NumberOffset);
            else
            {
                if(test(UpperCase, src))
                    return (HexDigitValue)((XF)src - LetterOffsetUp);
                else
                    return (HexDigitValue)((XF)src - LetterOffsetLo);
            }
        }

        /// <summary>
        /// Computes the numeric value in in the range [0,..F] identified by a lowercase hex symbol
        /// </summary>
        /// <param name="src">The source symbol</param>
        [MethodImpl(Inline), Op]
        public static HexDigitValue digit(LowerCased @case, char src)
            => number(src) ? (HexDigitValue)((XF)src - NumberOffset) : (HexDigitValue)((XF)src - LetterOffsetLo);

        /// <summary>
        /// Computes the numeric value in in the range [0,..F] identified by a lowercase hex symbol
        /// </summary>
        /// <param name="src">The source symbol</param>
        [MethodImpl(Inline), Op]
        public static HexDigitValue digit(UpperCased @case, char src)
            => number(src) ? (HexDigitValue)((XF)src - NumberOffset) : (HexDigitValue)((XF)src - LetterOffsetUp);

        /// <summary>
        /// Computes the numeric value in in the range [0,..F] identified by a lowercase hex symbol
        /// </summary>
        /// <param name="src">The source symbol</param>
        [MethodImpl(Inline), Op]
        public static HexDigitValue digit(HexLowerSym src)
            => number(src) ? (HexDigitValue)((XF)src - NumberOffset) : (HexDigitValue)((XF)src - LetterOffsetLo);

        /// <summary>
        /// Computes the numeric value in in the range [0,..F] identified by an uppercase hex symbol
        /// </summary>
        /// <param name="src">The source symbol</param>
        [MethodImpl(Inline), Op]
        public static HexDigitValue digit(HexUpperSym src)
            => number(src) ? (HexDigitValue)((XF)src - NumberOffset) : (HexDigitValue)((XF)src - LetterOffsetUp);
    }
}