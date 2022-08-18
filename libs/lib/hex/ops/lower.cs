//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using X = HexDigitFacets;

    partial struct Hex
    {
        /// <summary>
        /// Determines whether a character corresponds to one of the lowercase hex code characters
        /// </summary>
        /// <param name="c">The character to test</param>
        [MethodImpl(Inline), Op]
        public static bool lower(AsciCode c)
            => (HexDigitCode)c >= X.MinLetterCodeL && (HexDigitCode)c <= X.MaxLetterCodeL;

        /// <summary>
        /// Determines whether a character corresponds to one of the lowercase hex code characters
        /// </summary>
        /// <param name="c">The character to test</param>
        [MethodImpl(Inline), Op]
        public static bool lower(char c)
            => lower((AsciCode)c);

        /// <summary>
        /// Retrieves the character corresponding to a specified <see cref='HexDigitValue'/>
        /// </summary>
        /// <param name="case">The case specifier</param>
        /// <param name="value">The digit value</param>
        [MethodImpl(Inline), Op]
        public static char lower(HexDigitValue value)
            => (char)symbol(LowerCase, value);
    }
}