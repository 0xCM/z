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
        /// Determines whether a character corresponds to one of the uppercase hex code characters
        /// </summary>
        /// <param name="c">The character to test</param>
        [MethodImpl(Inline), Op]
        public static bool upper(AsciCode c)
            => (HexDigitCode)c >= X.MinLetterCodeU && (HexDigitCode)c <= X.MaxLetterCodeU;

        /// <summary>
        /// Determines whether a character corresponds to one of the uppercase hex code characters
        /// </summary>
        /// <param name="c">The character to test</param>
        [MethodImpl(Inline), Op]
        public static bool upper(char c)
            => upper((AsciCode)c);

        /// <summary>
        /// Retrieves the character corresponding to a specified <see cref='HexDigitValue'/>
        /// </summary>
        /// <param name="case">The case specifier</param>
        /// <param name="value">The digit value</param>
        [MethodImpl(Inline), Op]
        public static char upper(HexDigitValue value)
            => (char)symbol(UpperCase, value);
    }
}