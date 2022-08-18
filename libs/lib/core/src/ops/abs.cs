//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct core
    {
        /// <summary>
        /// Computes the absolute value of the source without branching
        /// </summary>
        /// <param name="a">The source value</param>
        [MethodImpl(Inline), Abs]
        public static sbyte abs(sbyte a)
            => (sbyte)(a + (a >> 7)^(a >> 7));

        /// <summary>
        /// Computes the absolute value of the source without branching
        /// </summary>
        /// <param name="a">The source value</param>
        [MethodImpl(Inline), Abs]
        public static short abs(short a)
            => (short)(a + (a >> 15)^(a >> 15));

        /// <summary>
        /// Computes the absolute value of the source without branching
        /// </summary>
        /// <param name="a">The source value</param>
        [MethodImpl(Inline), Abs]
        public static int abs(int a)
            => (a + (a >> 31)^(a >> 31));

        /// <summary>
        /// Computes the absolute value of the source without branching
        /// </summary>
        /// <param name="a">The source value</param>
        [MethodImpl(Inline), Abs]
        public static long abs(long a)
            => (a + (a >> 63)^(a >> 63));
   }
}