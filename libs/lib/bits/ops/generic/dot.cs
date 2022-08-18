//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class gbits
    {
        /// <summary>
        /// Pretends that the operands are bitvectors and computes their scalar product
        /// </summary>
        /// <param name="x">The left scalar</param>
        /// <param name="y">The right scalar</param>
        /// <typeparam name="T">The primal unsigned integral type</typeparam>
        [MethodImpl(Inline), Dot, Closures(Integers)]
        public static bit dot<T>(T x, T y)
            where T : unmanaged
                => gmath.odd(pop(gmath.and(x,y)));
    }
}