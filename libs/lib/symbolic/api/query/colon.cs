//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct SymbolicQuery
    {
        /// <summary>
        /// Tests whether a specified character is the ':' character
        /// </summary>
        /// <param name="c">The character to test</param>
        [MethodImpl(Inline), Op]
        public static bit colon(char c)
            => (char)AsciCode.Colon == c;

        /// <summary>
        /// Tests whether a specified code represents the ':' character
        /// </summary>
        /// <param name="c">The code to test</param>
        [MethodImpl(Inline), Op]
        public static bit colon(AsciCode c)
            => AsciCode.Colon == c;
    }
}