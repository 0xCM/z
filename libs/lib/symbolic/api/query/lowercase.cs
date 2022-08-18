//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using C = AsciCode;
    using F = AsciCodeFacets;
    using S = AsciSymbol;

    partial struct SymbolicQuery
    {
        /// <summary>
        /// Determines whether the source value is one of <see cref='AsciLetterLoCode'/>
        /// </summary>
        /// <param name="src">The value to test</param>
        [MethodImpl(Inline), Op]
        public static bool lowercase(C src)
            => contains(F.MinLowerLetter, F.MaxLowerLetter, src);

        /// <summary>
        /// Determines whether the source value is one of <see cref='AsciLetterLoCode'/>
        /// </summary>
        /// <param name="src">The value to test</param>
        [MethodImpl(Inline), Op]
        public static bool lowercase(AsciCharSym src)
            => contains(F.MinLowerLetter, F.MaxLowerLetter, (C)src);

        /// <summary>
        /// Determines whether the code of a specified character is one of <see cref='AsciLetterLoCode'/>
        /// </summary>
        /// <param name="src">The value to test</param>
        [MethodImpl(Inline), Op]
        public static bool lowercase(char src)
            => contains((char)F.MinLowerLetter, (char)F.MaxLowerLetter, src);
    }
}
