//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Perm
    {
        /// <summary>
        /// Defines a transposition for a permutation of natural length
        /// </summary>
        /// <param name="i">The first index</param>
        /// <param name="j">The second index</param>
        /// <typeparam name="N">The length type</typeparam>
        [MethodImpl(Inline)]
        public static NatSwap<N,T> swap<N,T>(T i, T j, N n = default)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => (i,j);

        /// <summary>
        /// Defines a transposition for a permutation of natural length
        /// </summary>
        /// <param name="i">The first index</param>
        /// <param name="j">The second index</param>
        /// <typeparam name="N">The length type</typeparam>
        [MethodImpl(Inline)]
        public static NatSwap<N> swap<N>(int i, int j)
            where N : unmanaged, ITypeNat
                => (i,j);
    }
}