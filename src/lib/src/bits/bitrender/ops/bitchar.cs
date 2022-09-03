//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct BitRender
    {
        /// <summary>
        /// Tests the state of an index-identified source bit and returns the corresponding '0' or '1' character
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="pos">The 0-based index of the bit to test</param>
        [MethodImpl(Inline), Op]
        public static char bitchar(sbyte src, byte pos)
            => bit.test(src, pos).ToChar();

        /// <summary>
        /// Tests the state of an index-identified source bit and returns the corresponding '0' or '1' character
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="pos">The 0-based index of the bit to test</param>
        [MethodImpl(Inline), Op]
        public static char bitchar(byte src, byte pos)
            => bit.test(src, pos).ToChar();

        /// <summary>
        /// Tests the state of an index-identified source bit and returns the corresponding '0' or '1' character
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="pos">The 0-based index of the bit to test</param>
        [MethodImpl(Inline), Op]
        public static char bitchar(short src, byte pos)
            => bit.test(src, pos).ToChar();

        /// <summary>
        /// Tests the state of an index-identified source bit and returns the corresponding '0' or '1' character
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="pos">The 0-based index of the bit to test</param>
        [MethodImpl(Inline), Op]
        public static char bitchar(ushort src, byte pos)
            => bit.test(src, pos).ToChar();

        /// <summary>
        /// Tests the state of an index-identified source bit and returns the corresponding '0' or '1' character
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="pos">The 0-based index of the bit to test</param>
        [MethodImpl(Inline), Op]
        public static char bitchar(int src, byte pos)
            => bit.test(src, pos).ToChar();

        /// <summary>
        /// Tests the state of an index-identified source bit and returns the corresponding '0' or '1' character
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="pos">The 0-based index of the bit to test</param>
        [MethodImpl(Inline), Op]
        public static char bitchar(uint src, byte pos)
            => bit.test(src, pos).ToChar();

        /// <summary>
        /// Tests the state of an index-identified source bit and returns the corresponding '0' or '1' character
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="pos">The 0-based index of the bit to test</param>
        [MethodImpl(Inline), Op]
        public static char bitchar(long src, byte pos)
            => bit.test(src, pos).ToChar();

        /// <summary>
        /// Tests the state of an index-identified source bit and returns the corresponding '0' or '1' character
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="pos">The 0-based index of the bit to test</param>
        [MethodImpl(Inline), Op]
        public static char bitchar(ulong src, byte pos)
            => bit.test(src, pos).ToChar();
    }
}