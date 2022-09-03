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
        /// Converts a grid to an equivalent linear bitstring representation
        /// </summary>
        /// <param name="g">The source grid</param>
        [MethodImpl(Inline)]
        public static BitString bitstring<T>(BitGrid16<T> g)
            where T : unmanaged
                => g.Data.ToBitString(g.BitCount);

        /// <summary>
        /// Converts a grid to an equivalent linear bitstring representation
        /// </summary>
        /// <param name="g">The source grid</param>
        [MethodImpl(Inline)]
        public static BitString bitstring<T>(BitGrid32<T> g)
            where T : unmanaged
                => g.Data.ToBitString(g.BitCount);

        /// <summary>
        /// Converts a grid to an equivalent linear bitstring representation
        /// </summary>
        /// <param name="g">The source grid</param>
        [MethodImpl(Inline)]
        public static BitString bitstring<T>(BitGrid64<T> g)
            where T : unmanaged
                => g.Data.ToBitString();

        /// <summary>
        /// Converts a grid to an equivalent linear bitstring representation
        /// </summary>
        /// <param name="g">The source grid</param>
        /// <typeparam name="M">The row type</typeparam>
        /// <typeparam name="N">The col type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static BitString bitstring<M,N,T>(BitGrid16<M,N,T> g)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => g.Data.ToBitString(g.BitCount);

        /// <summary>
        /// Converts a grid to an equivalent linear bitstring representation
        /// </summary>
        /// <param name="g">The source grid</param>
        /// <typeparam name="M">The row type</typeparam>
        /// <typeparam name="N">The col type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static BitString bitstring<M,N,T>(BitGrid32<M,N,T> g)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => g.Data.ToBitString(g.BitCount);

        /// <summary>
        /// Converts a grid to an equivalent linear bitstring representation
        /// </summary>
        /// <param name="g">The source grid</param>
        /// <typeparam name="M">The row type</typeparam>
        /// <typeparam name="N">The col type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static BitString bitstring<M,N,T>(BitGrid64<M,N,T> g)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => g.Data.ToBitString(g.BitCount);

        /// <summary>
        /// Converts a grid to an equivalent linear bitstring representation
        /// </summary>
        /// <param name="g">The source grid</param>
        /// <typeparam name="M">The row type</typeparam>
        /// <typeparam name="N">The col type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static BitString bitstring<M,N,T>(in BitGrid128<M,N,T> g)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => g.Data.ToBitString(g.BitCount);

        /// <summary>
        /// Converts a grid to an equivalent linear bitstring representation
        /// </summary>
        /// <param name="g">The source grid</param>
        /// <typeparam name="M">The row type</typeparam>
        /// <typeparam name="N">The col type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static BitString bitstring<M,N,T>(in BitGrid256<M,N,T> g)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => g.Data.ToBitString(g.BitCount);

        /// <summary>
        /// Converts a grid to an equivalent linear bitstring representation
        /// </summary>
        /// <param name="g">The source grid</param>
        /// <typeparam name="M">The row type</typeparam>
        /// <typeparam name="N">The col type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static BitString bitstring<M,N,T>(in BitGrid<M,N,T> g)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => g.Data.ToBitString(g.BitCount);

         /// <summary>
        /// Converts a grid to an equivalent linear bitstring representation
        /// </summary>
        /// <param name="g">The source grid</param>
        [MethodImpl(Inline)]
        public static BitString bitstring<T>(in BitSpanBlocks256<T> g)
            where T : unmanaged
                => g.Data.ToBitString(g.BitCount);
    }
}