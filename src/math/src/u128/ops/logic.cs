//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct zUInt128
    {
        /// <summary>
        /// Computes the bitwise OR of two 128-bit integers
        /// </summary>
        /// <param name="x">The first integer, represented via paired hi/lo components</param>
        /// <param name="y">The second integer, represented via paired hi/lo components</param>
        [MethodImpl(Inline), Or]
        public static zUInt128 or(in zUInt128 x, in zUInt128 y)
            => (x.Lo | y.Lo, x.Hi | y.Hi);

        /// <summary>
        /// Computes the bitwise complement of a 128-bit integer
        /// </summary>
        /// <param name="x">The integer, represented via paired hi/lo components</param>
        [MethodImpl(Inline), Not]
        public static zUInt128 not(in zUInt128 x)
        {
            return (~x.Lo, ~x.Hi);
        }

        /// <summary>
        /// Computes the bitwise XOR of two 128-bit integers
        /// </summary>
        /// <param name="x">The first integer, represented via paired hi/lo components</param>
        /// <param name="y">The second integer, represented via paired hi/lo components</param>
        [MethodImpl(Inline), Xor]
        public static zUInt128 xor(in zUInt128 x, in zUInt128 y)
            => (x.Lo ^ y.Lo, x.Hi ^ y.Hi);

        [MethodImpl(Inline), Nor]
        public static zUInt128 nor(in zUInt128 x, in zUInt128 y)
            => not(or(x,y));

        /// <summary>
        /// Computes the bitwise AND of two 128-bit integers
        /// </summary>
        /// <param name="x">The first integer, represented via paired hi/lo components</param>
        /// <param name="y">The second integer, represented via paired hi/lo components</param>
        [MethodImpl(Inline), And]
        public static zUInt128 and(in zUInt128 x, in zUInt128 y)
            => (x.Lo & y.Lo, x.Hi & y.Hi);

        /// <summary>
        /// Computes the bitwise NAND of two 128-bit integers
        /// </summary>
        /// <param name="x">The first integer, represented via paired hi/lo components</param>
        /// <param name="y">The second integer, represented via paired hi/lo components</param>
        [MethodImpl(Inline), Nand]
        public static zUInt128 nand(in zUInt128 x, in zUInt128 y)
            => not(and(x,y));

        /// <summary>
        /// Computes the bitwise XNOR of two 128-bit integers
        /// </summary>
        /// <param name="x">The first integer, represented via paired hi/lo components</param>
        /// <param name="y">The second integer, represented via paired hi/lo components</param>
        [MethodImpl(Inline), Xnor]
        public static zUInt128 xnor(in zUInt128 x, in zUInt128 y)
            => not(xor(x,y));
    }
}