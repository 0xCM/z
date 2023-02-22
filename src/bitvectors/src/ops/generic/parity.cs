//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    partial class BitVectors
    {
        /// <summary>
        /// Computes the parity of the source vector
        /// </summary>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static bit parity<T>(in BitVector128<T> src)
            where T : unmanaged
                => math.odd(pop(src));

        /// <summary>
        /// Computes the parity of the source vector
        /// </summary>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static bit parity<T>(in BitVector256<T> src)
            where T : unmanaged
                => math.odd(pop(src));
    }
}