//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class BitVectors
    {
        /// <summary>
        /// Computes the effective width of the bitvector as determined by the number of leading zero bits
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline), EffWidth, Closures(Closure)]
        public static int effwidth<T>(ScalarBits<T> x)
            where T : unmanaged
                => (int)width<T>() - nlz(x);

        /// <summary>
        /// Computes the effective width of the bitvector as determined by the number of leading zero bits
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline)]
        public static int effwidth<N,T>(ScalarBits<N,T> x)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => x.Width - nlz(x);
    }
}