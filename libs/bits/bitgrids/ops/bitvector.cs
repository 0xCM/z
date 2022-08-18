//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class BitGrid
    {
        /// <summary>
        /// Presents a fixed 16-bit grid as a 16-bit bitvector
        /// </summary>
        /// <param name="g">The source grid</param>
        /// <typeparam name="T">The grid cell type</typeparam>
        [MethodImpl(Inline)]
        public static ScalarBits<N16,uint> bitvector<M,N,T>(BitGrid16<M,N,T> g)
            where T : unmanaged
            where N : unmanaged, ITypeNat
            where M : unmanaged, ITypeNat
                => g.Content;

        /// <summary>
        /// Presents a fixed 32-bit grid as a 32-bit bitvector
        /// </summary>
        /// <param name="g">The source grid</param>
        /// <typeparam name="T">The grid cell type</typeparam>
        [MethodImpl(Inline)]
        public static ScalarBits<N32,uint> bitvector<M,N,T>(BitGrid32<M,N,T> g)
            where T : unmanaged
            where N : unmanaged, ITypeNat
            where M : unmanaged, ITypeNat
                => g.Content;

        /// <summary>
        /// Presents a fixed 64-bit grid as a 64-bit bitvector
        /// </summary>
        /// <param name="g">The source grid</param>
        /// <typeparam name="T">The grid cell type</typeparam>
        [MethodImpl(Inline)]
        public static ScalarBits<N64,ulong> bitvector<M,N,T>(BitGrid64<M,N,T> g)
            where T : unmanaged
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
                => g.Content;

        /// <summary>
        /// Presents a fixed 128-bit grid as a 128-bit bitvector
        /// </summary>
        /// <param name="g">The source grid</param>
        /// <typeparam name="T">The grid cell type</typeparam>
        [MethodImpl(Inline)]
        public static BitVector128<T> bitvector<M,N,T>(BitGrid128<M,N,T> g)
            where T : unmanaged
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
                => g.Content;
    }
}