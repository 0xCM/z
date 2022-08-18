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
        /// Tests whether a character code represents <see cref='AsciCharSym.NL'/>
        /// </summary>
        /// <param name="src">The character to test</param>
        [MethodImpl(Inline), Op]
        public static bit nl(byte src)
            => (byte)C.NL == src;

        /// <summary>
        /// Tests whether a character code represents <see cref='AsciCharSym.NL'/>
        /// </summary>
        /// <param name="src">The character to test</param>
        [MethodImpl(Inline), Op]
        public static bit nl(C src)
            => C.NL == src;

        /// <summary>
        /// Tests whether a source character is a <see cref='AsciCharSym.NL'/>
        /// </summary>
        /// <param name="src">The character to test</param>
        [MethodImpl(Inline), Op]
        public static bit nl(char src)
            => (char)C.NL == src;
    }
}