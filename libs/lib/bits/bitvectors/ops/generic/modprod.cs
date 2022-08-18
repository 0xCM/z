//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitVectors
    {
        /// <summary>
        /// Computes the Euclidean scalar product between two bitvectors using modular arithmetic
        /// </summary>
        /// <param name="x">The first vector</param>
        /// <param name="y">The second vector</param>
        /// <remarks>This should be considered a reference implementation; the dot operation is considerably faster</remarks>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static bit modprod<T>(ScalarBits<T> x, ScalarBits<T> y)
            where T : unmanaged
        {
            var result = 0;
            for(var i=0; i<x.Width; i++)
            {
                var a = x[i] ? 1 : 0;
                var b = y[i] ? 1 : 0;
                result += a*b;
            }
            return gmath.odd(result);
        }

        /// <summary>
        /// Computes the Euclidean scalar product between two bitvectors using modular arithmetic
        /// </summary>
        /// <param name="x">The first vector</param>
        /// <param name="y">The second vector</param>
        /// <remarks>This should be considered a reference implementation; the dot operation is considerably faster</remarks>
        [MethodImpl(Inline)]
        public static bit modprod<N,T>(ScalarBits<N,T> x, ScalarBits<N,T> y)
            where T : unmanaged
            where N : unmanaged, ITypeNat
        {
            var result = 0u;
            for(var i=0; i<x.Width; i++)
                result += ((uint)x[i]*(uint)y[i]);
            return gmath.odd(result);
        }
    }
}