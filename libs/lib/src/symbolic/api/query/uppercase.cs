//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using C = AsciCode;
    using F = AsciCodeFacets;

    partial struct SymbolicQuery
    {
        /// <summary>
        /// Determines whether the source value is one of <see cref='AsciLetterUpCode'/>
        /// </summary>
        /// <param name="src">The value to test</param>
        [MethodImpl(Inline), Op]
        public static bit uppercase(C src)
            => contains(F.MinUpperLetter, F.MaxUpperLetter, src);

        /// <summary>
        /// Determines whether the source value is one of <see cref='AsciLetterUpCode'/>
        /// </summary>
        /// <param name="src">The value to test</param>
        [MethodImpl(Inline), Op]
        public static bit uppercase(AsciCharSym src)
            => contains(F.MinUpperLetter, F.MaxUpperLetter, (C)src);

        /// <summary>
        /// Determines whether the code of a specified character is one of <see cref='AsciLetterUpCode'/>
        /// </summary>
        /// <param name="src">The value to test</param>
        [MethodImpl(Inline), Op]
        public static bit uppercase(char src)
            => contains((char)F.MinUpperLetter, (char)F.MaxUpperLetter, src);
    }
}