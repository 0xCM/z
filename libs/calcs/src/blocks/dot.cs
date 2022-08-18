//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitBlocks
    {
        /// <summary>
        /// Computes the scalar product between two bitblocks
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static bit dot<T>(in BitBlock<T> x, in BitBlock<T> y)
            where T : unmanaged
        {
            var count = x.BitCount;
            var result = bit.Off;
            for(var i=0; i<count; i++)
                result ^= x[i] & y[i];
            return result;
        }

        /// <summary>
        /// Computes the scalar product between this vector and another
        /// </summary>
        /// <param name="rhs">The other vector</param>
        /// <typeparam name="N">The bitwidth type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static bit dot<N,T>(in BitBlock<N,T> x, in BitBlock<N,T> y)
            where T : unmanaged
            where N : unmanaged, ITypeNat
        {
            var count = x.Width;
            var result = bit.Off;
            for(var i=0; i<count; i++)
                result ^= x[i] & y[i];
            return result;
        }
    }
}