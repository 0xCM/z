//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct Math128
    {
        /// <summary>
        /// Subtraction mod 2^128.
        /// </summary>
        /// <remarks>Adapted from IntUtils.cs / Microsoft Machine Learning repository</remarks>
        [MethodImpl(Inline), Sub]
        public static void sub(ref uint128 dst, ulong src)
        {
            if (dst.Lo < src)
                dst.Hi--;
            dst.Lo -= src;
        }

        /// <summary>
        /// Computes the difference c := a - b between 128-bit unsigned integers a and b
        /// </summary>
        /// <param name="a">A reference to the left 128-bits</param>
        /// <param name="b">A reference to the right 128-bits</param>
        /// <param name="c">A reference to the target 128-bits</param>
        /// <remarks>Adapted from https://github.com/chfast/intx/include/intx/int128.hpp</remarks>
        [MethodImpl(Inline), Sub]
        public static void sub(in ulong a, in ulong b, ref ulong c)
        {
            c = a - b;
            var borrow = a < c;
            seek(c, 1) = skip(in a, 1) - skip(in b, 1) - uint32(borrow);
        }

        /// <summary>
        /// Computes the difference of two 128-bit integers
        /// </summary>
        /// <param name="x">The first integer, represented via paired hi/lo components</param>
        /// <param name="y">The second integer, represented via paired hi/lo components</param>
        /// <remarks>Adapted from https://github.com/chfast/intx/include/intx/int128.hpp</remarks>
        [MethodImpl(Inline), Sub]
        public static ref uint128 sub(ref uint128 x, in uint128 y)
        {
            var lo = x.Lo - y.Lo;
            var borrow = x.Lo < lo;
            x.Hi = x.Hi - y.Hi - uint32(borrow);
            x.Lo = lo;
            return ref x;
        }
    }
}