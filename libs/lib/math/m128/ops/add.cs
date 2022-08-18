//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct Math128
    {
        /// <summary>
        /// Addition mod 2^128.
        /// </summary>
        /// <remarks>Taken from IntUtils.cs / Microsoft Machine Learning repository</remarks>
        [MethodImpl(Inline), Add]
        public static void add(ref ulong dstLo, ref ulong dstHi, ulong src)
        {
            if ((dstLo += src) < src)
                dstHi++;
        }

        /// <summary>
        /// Addition mod 2^128.
        /// </summary>
        /// <remarks>Adapted from IntUtils.cs / Microsoft Machine Learning repository</remarks>
        [MethodImpl(Inline), Add]
        public static void add(ref ulong dstLo, ref ulong dstHi, ulong srcLo, ulong srcHi)
        {
            if ((dstLo += srcLo) < srcLo)
                dstHi++;
            dstHi += srcHi;
        }

        /// <summary>
        /// Computes the sum of two 128-bit integers
        /// </summary>
        /// <param name="x">The first integer, represented via paired hi/lo components</param>
        /// <param name="y">The second integer, represented via paired hi/lo components</param>
        /// <remarks>Follows https://github.com/chfast/intx/include/intx/int128.hpp</remarks>
        [MethodImpl(Inline), Add]
        public static ref uint128 add(ref uint128 x, in uint128 y)
        {
            var lo = x.Lo + y.Lo;
            var carry = x.Lo > lo;
            x.Hi = x.Hi + y.Hi + uint32(carry);
            x.Lo = lo;
            return ref x;
        }

        /// <summary>
        /// Computes the sum c := a + b of 128-bit unsigned integers a and b
        /// </summary>
        /// <param name="a">A reference to the left 128-bits</param>
        /// <param name="b">A reference to the right 128-bits</param>
        /// <param name="c">A reference to the target 128-bits</param>
        /// <remarks>Follows https://github.com/chfast/intx/include/intx/int128.hpp</remarks>
        [MethodImpl(Inline), Op]
        public static void add(in ulong a, in ulong b, ref ulong c)
        {
            c = a + b;
            var carry = a > c;
            seek(c, 1) = skip(in a, 1) + skip(in b, 1) + u32(carry);
        }
    }
}