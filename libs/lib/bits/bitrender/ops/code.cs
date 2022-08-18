//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using C = AsciCode;

    partial struct BitRender
    {
        /// <summary>
        /// Represents a source bit as its asci-encoded value
        /// </summary>
        /// <param name="b"></param>
        [MethodImpl(Inline), Op]
        public static C code(bit b)
            => b ? C.d1 : C.d0;

        /// <summary>
        /// Tests the state of an index-identified source bit and returns the corresponding '0' or '1' asci code
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="pos">The 0-based index of the bit to test</param>
        [MethodImpl(Inline), Op]
        public static C code(sbyte src, byte pos)
            => code(bit.test(src, pos));

        /// <summary>
        /// Tests the state of an index-identified source bit and returns the corresponding '0' or '1' asci code
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="pos">The 0-based index of the bit to test</param>
        [MethodImpl(Inline), Op]
        public static C code(byte src, byte pos)
            => code(bit.test(src, pos));

        /// <summary>
        /// Tests the state of an index-identified source bit and returns the corresponding '0' or '1' asci code
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="pos">The 0-based index of the bit to test</param>
        [MethodImpl(Inline), Op]
        public static C code(short src, byte pos)
            => code(bit.test(src, pos));

        /// <summary>
        /// Tests the state of an index-identified source bit and returns the corresponding '0' or '1' asci code
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="pos">The 0-based index of the bit to test</param>
        [MethodImpl(Inline), Op]
        public static C code(ushort src, byte pos)
            => code(bit.test(src, pos));

        /// <summary>
        /// Tests the state of an index-identified source bit and returns the corresponding '0' or '1' asci code
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="pos">The 0-based index of the bit to test</param>
        [MethodImpl(Inline), Op]
        public static C code(int src, byte pos)
            => code(bit.test(src, pos));

        /// <summary>
        /// Tests the state of an index-identified source bit and returns the corresponding '0' or '1' asci code
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="pos">The 0-based index of the bit to test</param>
        [MethodImpl(Inline), Op]
        public static C code(uint src, byte pos)
            => code(bit.test(src, pos));

        /// <summary>
        /// Tests the state of an index-identified source bit and returns the corresponding '0' or '1' asci code
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="pos">The 0-based index of the bit to test</param>
        [MethodImpl(Inline), Op]
        public static C code(long src, byte pos)
            => code(bit.test(src, pos));

        /// <summary>
        /// Tests the state of an index-identified source bit and returns the corresponding '0' or '1' asci code
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="pos">The 0-based index of the bit to test</param>
        [MethodImpl(Inline), Op]
        public static C code(ulong src, byte pos)
             => code(bit.test(src, pos));
   }
}