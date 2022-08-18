//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class math
    {
        /// <summary>
        /// Computes the bitwise disjunction of the source operands
        /// </summary>
        /// <param name="a">The first operand</param>
        /// <param name="b">The second operand</param>
        /// <param name="c">The third operand</param>
        /// <param name="d">The fourth operand</param>
        [MethodImpl(Inline), Op]
        public static int or(int a, int b, int c, int d)
            => a | b | c | d;

        /// <summary>
        /// Computes the bitwise or c := a | b for operands a and b
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [MethodImpl(Inline), Or]
        public static uint or(uint a, uint b)
            => a | b;

        [MethodImpl(Inline), Op]
        public static uint or(uint a, uint b, uint c)
            => a | b | c;

        [MethodImpl(Inline), Op]
        public static uint or(uint a, uint b, uint c, uint d)
            => a | b | c | d;

        [MethodImpl(Inline), Op]
        public static uint or(uint a, uint b, uint c, uint d, uint e)
            => a | b | c | d | e;

        [MethodImpl(Inline), Op]
        public static uint or(uint a, uint b, uint c, uint d, uint e, uint f)
            => a | b | c | d | e | f;

        [MethodImpl(Inline), Op]
        public static uint or(uint a, uint b, uint c, uint d, uint e, uint f, uint g)
            => a | b | c | d | e | f | g;

        [MethodImpl(Inline), Op]
        public static uint or(uint a, uint b, uint c, uint d, uint e, uint f, uint g, uint h)
            => a | b | c | d | e | f | g | h;
    }
}