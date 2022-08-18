//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using C = AsciCode;

    partial struct SymbolicQuery
    {
        /// <summary>
        /// Determines whether an asci code defines the <see cref='Chars.RBrace'/> character
        /// </summary>
        /// <param name="src">The value to test</param>
        [MethodImpl(Inline), Op]
        public static bit rbrace(C src)
            => src == C.RBrace;

        /// <summary>
        /// Determines whether an asci code defines the <see cref='Chars.RBrace'/> character
        /// </summary>
        /// <param name="src">The value to test</param>
        [MethodImpl(Inline), Op]
        public static bit rbrace(char src)
            => src == (char)C.RBrace;

        /// <summary>
        /// Determines whether an <see cref='AsciCharSym'/> symbol represents the <see cref='Chars.RBrace'/> character
        /// </summary>
        /// <param name="src">The value to test</param>
        [MethodImpl(Inline), Op]
        public static bit rbrace(AsciCharSym src)
            => rbrace((char)src);
    }
}