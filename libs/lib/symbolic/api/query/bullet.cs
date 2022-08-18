//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct SymbolicQuery
    {
        /// <summary>
        /// Tests whether a 2-byte sequence represents the character '•'
        /// </summary>
        /// <param name="b0">The first byte</param>
        /// <param name="b1">The second byte</param>
        [MethodImpl(Inline), Op]
        public static bit bullet(byte b0, byte b1)
            => ((uint)b0 | (uint)b1 << 8) == CharValues.Bullet;

        /// <summary>
        /// Tests whether a specified character is the '•' character
        /// </summary>
        /// <param name="c">The character to test</param>
        [MethodImpl(Inline), Op]
        public static bit bullet(char c)
            => c == CharValues.Bullet;
    }
}