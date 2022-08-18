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
        /// Determines whether an asci code defines the <see cref='Chars.Space'/> character
        /// </summary>
        /// <param name="src">The value to test</param>
        [MethodImpl(Inline), Op]
        public static bit space(C src)
            => src == C.Space;

        /// <summary>
        /// Determines whether an asci code defines the <see cref='Chars.Space'/> character
        /// </summary>
        /// <param name="src">The value to test</param>
        [MethodImpl(Inline), Op]
        public static bit space(char src)
            => src == (char)C.Space;
    }
}