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
        /// Computes the bitwise complement of the source grid
        /// </summary>
        /// <param name="gx">The source grid</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(UInt8x16k)]
        public static BitGrid16<T> not<T>(BitGrid16<T> gx)
            where T : unmanaged
                => init16<T>(math.not(gx));

        /// <summary>
        /// Computes the bitwise complement of the source grid
        /// </summary>
        /// <param name="gx">The source grid</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(UInt8x16x32k)]
        public static BitGrid32<T> not<T>(BitGrid32<T> gx)
            where T : unmanaged
                => init32<T>(math.not(gx));

        /// <summary>
        /// Computes the bitwise complement of the source grid
        /// </summary>
        /// <param name="gx">The source grid</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(UnsignedInts)]
        public static BitGrid64<T> not<T>(BitGrid64<T> gx)
            where T : unmanaged
                => init64<T>(math.not(gx));

        /// <summary>
        /// Computes the bitwise complement of the source grid
        /// </summary>
        /// <param name="gx">The source grid</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static BitGrid16<M,N,T> not<M,N,T>(BitGrid16<M,N,T> gx)
            where T : unmanaged
            where N : unmanaged, ITypeNat
            where M : unmanaged, ITypeNat
                => math.not(gx);

        /// <summary>
        /// Computes the bitwise complement of the source grid
        /// </summary>
        /// <param name="gx">The source grid</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static BitGrid32<M,N,T> not<M,N,T>(BitGrid32<M,N,T> gx)
            where T : unmanaged
            where N : unmanaged, ITypeNat
            where M : unmanaged, ITypeNat
                => math.not(gx);

        /// <summary>
        /// Computes the bitwise complement of the source grid
        /// </summary>
        /// <param name="gx">The source grid</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static BitGrid64<M,N,T> not<M,N,T>(BitGrid64<M,N,T> gx)
            where T : unmanaged
            where N : unmanaged, ITypeNat
            where M : unmanaged, ITypeNat
                => math.not(gx);

        /// <summary>
        /// Computes the bitwise complement of the source grid
        /// </summary>
        /// <param name="gx">The source grid</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static BitGrid128<M,N,T> not<M,N,T>(in BitGrid128<M,N,T> gx)
            where T : unmanaged
            where N : unmanaged, ITypeNat
            where M : unmanaged, ITypeNat
                => gcpu.vnot<T>(gx);

        /// <summary>
        /// Computes the bitwise complement of the source grid
        /// </summary>
        /// <param name="gx">The source grid</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static BitGrid256<M,N,T> not<M,N,T>(in BitGrid256<M,N,T> gx)
            where T : unmanaged
            where N : unmanaged, ITypeNat
            where M : unmanaged, ITypeNat
                => gcpu.vnot<T>(gx);

        /// <summary>
        /// Computes the bitwise complement of the source grid and stores the result to a caller-supplied target
        /// </summary>
        /// <param name="gx">The source grid</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static ref readonly BitGrid<M,N,T> not<M,N,T>(in BitGrid<M,N,T> gx, in BitGrid<M,N,T> gz)
            where T : unmanaged
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
        {
            var blocks = gz.BlockCount;
            for(var i=0; i<blocks; i++)
                gz[i] = gcpu.vnot(gx[i]);
            return ref gz;
        }

        /// <summary>
        /// Computes the bitwise complement of the source grid
        /// </summary>
        /// <param name="gx">The source grid</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static BitGrid<M,N,T> not<M,N,T>(in BitGrid<M,N,T> gx)
            where T : unmanaged
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
                => not(gx, alloc<M,N,T>());

        /// <summary>
        /// Computes the bitwise complement of the source grid and deposits the result int a caller-supplied target
        /// </summary>
        /// <param name="gx">The source grid</param>
        /// <param name="gz">The target grid</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static ref readonly BitSpanBlocks256<T> not<T>(in BitSpanBlocks256<T> gx, in BitSpanBlocks256<T> gz)
            where T : unmanaged
        {
            var blocks = gz.BlockCount;
            for(var i=0; i<blocks; i++)
                gz[i] = gcpu.vnot(gx[i]);
            return ref gz;
        }

        /// <summary>
        /// Computes the bitwise complement of the source grid
        /// </summary>
        /// <param name="gx">The source grid</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static BitSpanBlocks256<T> not<T>(in BitSpanBlocks256<T> gx)
            where T : unmanaged
                => not(gx, alloc<T>(gx.RowCount, gx.ColCount));
    }
}