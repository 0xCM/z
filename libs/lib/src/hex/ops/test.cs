//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using XF = HexSymFacet;

    partial struct Hex
    {
        /// <summary>
        /// Determines whether a character is an upper-cased hex digit
        /// </summary>
        /// <param name="c">The character to test</param>
        [MethodImpl(Inline), Op]
        public static bool test(UpperCased casing, char c)
            => hexscalar(c) || hexupper(c);

        /// <summary>
        /// Determines whether a character is an upper-cased hex digit
        /// </summary>
        /// <param name="c">The character to test</param>
        [MethodImpl(Inline), Op]
        public static bool test(UpperCased casing, AsciCode c)
            => hexscalar(c) || hexupper(c);

        /// <summary>
        /// Determines whether a character is a lower-cased hex digit
        /// </summary>
        /// <param name="c">The character to test</param>
        [MethodImpl(Inline), Op]
        public static bool test(LowerCased casing, char c)
            => hexscalar(c) || hexlower(c);

        /// <summary>
        /// Determines whether a character is a hex digit of any case
        /// </summary>
        /// <param name="c">The character to test</param>
        [MethodImpl(Inline), Op]
        public static bool test(char c)
            => hexscalar(c) || hexlower(c) || hexupper(c);

        /// <summary>
        /// Determines whether a character is one of [0..9]
        /// </summary>
        /// <param name="c">The character to test</param>
        [MethodImpl(Inline)]
        static bool hexscalar(char c)
            => (XF)c >= XF.FirstNumber && (XF)c <= XF.LastNumber;

        /// <summary>
        /// Determines whether a character is one of [0..9]
        /// </summary>
        /// <param name="c">The character to test</param>
        [MethodImpl(Inline)]
        static bool hexscalar(AsciCode c)
            => (XF)c >= XF.FirstNumber && (XF)c <= XF.LastNumber;

        /// <summary>
        /// Determines whether a character corresponds to one of the uppercase hex code characters
        /// </summary>
        /// <param name="c">The character to test</param>
        [MethodImpl(Inline)]
        static bool hexupper(char c)
            => (XF)c >= XF.FirstLetterUp && (XF)c <= XF.LastLetterUp;

        /// <summary>
        /// Determines whether a character corresponds to one of the uppercase hex code characters
        /// </summary>
        /// <param name="c">The character to test</param>
        [MethodImpl(Inline)]
        static bool hexupper(AsciCode c)
            => (XF)c >= XF.FirstLetterUp && (XF)c <= XF.LastLetterUp;

        /// <summary>
        /// Determines whether a character corresponds to one of the lowercase hex code characters
        /// </summary>
        /// <param name="c">The character to test</param>
        [MethodImpl(Inline)]
        static bool hexlower(char c)
            => (XF)c >= XF.FirstLetterLo && (XF)c <= XF.LastLetterUp;
    }
}