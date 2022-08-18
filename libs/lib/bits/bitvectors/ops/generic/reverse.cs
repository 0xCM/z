//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitVectors
    {
        /// <summary>
        /// Reverses the bits in the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline)]
        public static ScalarBits<N,T> reverse<N,T>(ScalarBits<N,T> src)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => gmath.srl(gbits.reverse(src.State), (byte)(core.width<T>() - src.Width));

        /// <summary>
        /// Reverses the bits in the source vector
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline), Reverse, Closures(Closure)]
        public static ScalarBits<T> reverse<T>(ScalarBits<T> x)
            where T : unmanaged
                => gbits.reverse(x.State);
    }
}