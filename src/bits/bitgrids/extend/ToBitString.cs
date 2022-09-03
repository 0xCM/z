//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class XTend
    {
        /// <summary>
        /// Converts a grid to an equivalent linear bitstring representation
        /// </summary>
        /// <param name="g">The source grid</param>
        [MethodImpl(Inline)]
        public static BitString ToBitString<T>(this BitGrid16<T> g)
            where T : unmanaged
                => BitGrid.bitstring(g);

        /// <summary>
        /// Converts a grid to an equivalent linear bitstring representation
        /// </summary>
        /// <param name="g">The source grid</param>
        [MethodImpl(Inline)]
        public static BitString ToBitString<T>(this BitGrid32<T> g)
            where T : unmanaged
                => BitGrid.bitstring(g);

        /// <summary>
        /// Converts a grid to an equivalent linear bitstring representation
        /// </summary>
        /// <param name="g">The source grid</param>
        [MethodImpl(Inline)]
        public static BitString ToBitString<T>(this BitGrid64<T> g)
            where T : unmanaged
                => BitGrid.bitstring(g);

        /// <summary>
        /// Converts a grid to an equivalent linear bitstring representation
        /// </summary>
        /// <param name="g">The source grid</param>
        /// <typeparam name="M">The row type</typeparam>
        /// <typeparam name="N">The col type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static BitString ToBitString<M,N,T>(this BitGrid<M,N,T> g)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => BitGrid.bitstring(g);

        /// <summary>
        /// Converts a grid to an equivalent linear bitstring representation
        /// </summary>
        /// <param name="g">The source grid</param>
        [MethodImpl(Inline)]
        public static BitString ToBitString<T>(this BitSpanBlocks256<T> g)
            where T : unmanaged
                => BitGrid.bitstring(g);

        /// <summary>
        /// Converts a grid to an equivalent linear bitstring representation
        /// </summary>
        /// <param name="g">The source grid</param>
        /// <typeparam name="M">The row type</typeparam>
        /// <typeparam name="N">The col type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static BitString ToBitString<M,N,T>(this BitGrid16<M,N,T> g)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => BitGrid.bitstring(g);

        /// <summary>
        /// Converts a grid to an equivalent linear bitstring representation
        /// </summary>
        /// <param name="g">The source grid</param>
        /// <typeparam name="M">The row type</typeparam>
        /// <typeparam name="N">The col type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static BitString ToBitString<M,N,T>(this BitGrid32<M,N,T> g)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => BitGrid.bitstring(g);

        /// <summary>
        /// Converts a grid to an equivalent linear bitstring representation
        /// </summary>
        /// <param name="g">The source grid</param>
        /// <typeparam name="M">The row type</typeparam>
        /// <typeparam name="N">The col type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static BitString ToBitString<M,N,T>(this BitGrid64<M,N,T> g)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => BitGrid.bitstring(g);

        /// <summary>
        /// Converts a grid to an equivalent linear bitstring representation
        /// </summary>
        /// <param name="g">The source grid</param>
        /// <typeparam name="M">The row type</typeparam>
        /// <typeparam name="N">The col type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static BitString ToBitString<M,N,T>(this BitGrid128<M,N,T> g)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => BitGrid.bitstring(g);

        /// <summary>
        /// Converts a grid to an equivalent linear bitstring representation
        /// </summary>
        /// <param name="g">The source grid</param>
        /// <typeparam name="M">The row type</typeparam>
        /// <typeparam name="N">The col type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static BitString ToBitString<M,N,T>(this BitGrid256<M,N,T> g)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => BitGrid.bitstring(g);
    }
}