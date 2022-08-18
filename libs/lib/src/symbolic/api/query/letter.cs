//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using C = AsciCode;
    using S = AsciSymbol;

    partial struct SymbolicQuery
    {
        /// <summary>
        /// Determines whether a specified code is one of <see cref='AsciLetterCode'/>
        /// </summary>
        /// <param name="src">The value to test</param>
        [MethodImpl(Inline), Op]
        public static bool letter(C src)
            => lowercase(src) || uppercase(src);

        /// <summary>
        /// Determines whether the code of a specified character is one of <see cref='AsciLetterCode'/>
        /// </summary>
        /// <param name="src">The value to test</param>
        [MethodImpl(Inline), Op]
        public static bool letter(char src)
            => lowercase(src) || uppercase(src);

        /// <summary>
        /// Tests whether a character is an uppercase asci letter character
        /// </summary>
        /// <param name="c">The character to test</param>
        [MethodImpl(Inline), Op]
        public static bool letter(UpperCased @case, char c)
            => (C)c >= AsciCodeFacets.MinUpperLetter && (C)c <= AsciCodeFacets.MaxUpperLetter;

        /// <summary>
        /// Tests whether a character is a lowercase asci letter character
        /// </summary>
        /// <param name="c">The character to test</param>
        [MethodImpl(Inline), Op]
        public static bool letter(LowerCased @case, char c)
            => (C)c >= AsciCodeFacets.MinLowerLetter && (C)c <= AsciCodeFacets.MaxLowerLetter;
    }
}