//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Math128
    {
        /// <summary>
        /// Computes the bitwise OR of two 128-bit integers
        /// </summary>
        /// <param name="x">The first integer, represented via paired hi/lo components</param>
        /// <param name="y">The second integer, represented via paired hi/lo components</param>
        [MethodImpl(Inline), Or]
        public static uint128 or(in uint128 x, in uint128 y)
            => (x.Lo | y.Lo, x.Hi | y.Hi);

        /// <summary>
        /// Computes the bitwise complement of a 128-bit integer
        /// </summary>
        /// <param name="x">The integer, represented via paired hi/lo components</param>
        [MethodImpl(Inline), Not]
        public static uint128 not(in uint128 x)
        {
            return (~x.Lo, ~x.Hi);
        }

        /// <summary>
        /// Computes the bitwise XOR of two 128-bit integers
        /// </summary>
        /// <param name="x">The first integer, represented via paired hi/lo components</param>
        /// <param name="y">The second integer, represented via paired hi/lo components</param>
        [MethodImpl(Inline), Xor]
        public static uint128 xor(in uint128 x, in uint128 y)
            => (x.Lo ^ y.Lo, x.Hi ^ y.Hi);

        [MethodImpl(Inline), Nor]
        public static uint128 nor(in uint128 x, in uint128 y)
            => not(or(x,y));

        /// <summary>
        /// Computes the bitwise AND of two 128-bit integers
        /// </summary>
        /// <param name="x">The first integer, represented via paired hi/lo components</param>
        /// <param name="y">The second integer, represented via paired hi/lo components</param>
        [MethodImpl(Inline), And]
        public static uint128 and(in uint128 x, in uint128 y)
            => (x.Lo & y.Lo, x.Hi & y.Hi);

        /// <summary>
        /// Computes the bitwise NAND of two 128-bit integers
        /// </summary>
        /// <param name="x">The first integer, represented via paired hi/lo components</param>
        /// <param name="y">The second integer, represented via paired hi/lo components</param>
        [MethodImpl(Inline), Nand]
        public static uint128 nand(in uint128 x, in uint128 y)
            => not(and(x,y));

        /// <summary>
        /// Computes the bitwise XNOR of two 128-bit integers
        /// </summary>
        /// <param name="x">The first integer, represented via paired hi/lo components</param>
        /// <param name="y">The second integer, represented via paired hi/lo components</param>
        [MethodImpl(Inline), Xnor]
        public static uint128 xnor(in uint128 x, in uint128 y)
            => not(xor(x,y));
    }
}