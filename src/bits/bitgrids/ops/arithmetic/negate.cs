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
        /// Computes the two's complement negation of source grid
        /// </summary>
        /// <param name="x">The source grid</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Negate, Closures(UInt8x16k)]
        public static BitGrid16<T> negate<T>(BitGrid16<T> x)
            where T : unmanaged
                => init16<T>(math.negate(x));

        /// <summary>
        /// Computes the two's complement negation of source grid
        /// </summary>
        /// <param name="x">The source grid</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Negate, Closures(UInt8x16x32k)]
        public static BitGrid32<T> negate<T>(BitGrid32<T> x)
            where T : unmanaged
                => init32<T>(math.negate(x));

        /// <summary>
        /// Computes the two's complement negation of source grid
        /// </summary>
        /// <param name="x">The source grid</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Negate, Closures(UnsignedInts)]
        public static BitGrid64<T> negate<T>(BitGrid64<T> x)
            where T : unmanaged
                => init64<T>(math.negate(x));

        /// <summary>
        /// Computes the two's complement negation of the first grid and deposits the result into the second
        /// </summary>
        /// <param name="x">The source grid</param>
        /// <param name="gz">The target grid</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Negate, Closures(UnsignedInts)]
        public static ref readonly BitSpanBlocks256<T> negate<T>(in BitSpanBlocks256<T> x, in BitSpanBlocks256<T> gz)
            where T : unmanaged
        {
            var blocks = gz.BlockCount;
            for(var i=0; i<blocks; i++)
                gz[i] = gcpu.vnegate(x[i]);
            return ref gz;
        }

        /// <summary>
        /// Computes the two's complement negation of the source grid
        /// </summary>
        /// <param name="x">The source grid</param>
        /// <typeparam name="M">The row count type</typeparam>
        /// <typeparam name="N">The col count type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static BitGrid16<M,N,T> negate<M,N,T>(BitGrid16<M,N,T> x)
            where T : unmanaged
            where N : unmanaged, ITypeNat
            where M : unmanaged, ITypeNat
                => math.negate(x);

        /// <summary>
        /// Computes the two's complement negation of the source grid
        /// </summary>
        /// <param name="x">The source grid</param>
        /// <typeparam name="M">The row count type</typeparam>
        /// <typeparam name="N">The col count type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static BitGrid32<M,N,T> negate<M,N,T>(BitGrid32<M,N,T> x)
            where T : unmanaged
            where N : unmanaged, ITypeNat
            where M : unmanaged, ITypeNat
                => math.negate(x);

        /// <summary>
        /// Computes the two's complement negation of the source grid
        /// </summary>
        /// <param name="x">The source grid</param>
        /// <typeparam name="M">The row count type</typeparam>
        /// <typeparam name="N">The col count type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static BitGrid64<M,N,T> negate<M,N,T>(BitGrid64<M,N,T> x)
            where T : unmanaged
            where N : unmanaged, ITypeNat
            where M : unmanaged, ITypeNat
                => math.negate(x);

        /// <summary>
        /// Computes the two's complement negation of the source grid
        /// </summary>
        /// <param name="x">The source grid</param>
        /// <typeparam name="M">The row count type</typeparam>
        /// <typeparam name="N">The col count type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static BitGrid128<M,N,T> negate<M,N,T>(in BitGrid128<M,N,T> x)
            where T : unmanaged
            where N : unmanaged, ITypeNat
            where M : unmanaged, ITypeNat
                => gcpu.vnegate<T>(x);

        /// <summary>
        /// Computes the two's complement negation of the source grid
        /// </summary>
        /// <param name="x">The source grid</param>
        /// <typeparam name="M">The row count type</typeparam>
        /// <typeparam name="N">The col count type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static BitGrid256<M,N,T> negate<M,N,T>(in BitGrid256<M,N,T> x)
            where T : unmanaged
            where N : unmanaged, ITypeNat
            where M : unmanaged, ITypeNat
                => gcpu.vnegate<T>(x);

        /// <summary>
        /// Computes the two's complement negation of the first grid and deposits the result into the second
        /// </summary>
        /// <param name="x">The source grid</param>
        /// <param name="gz">The target grid</param>
        /// <typeparam name="M">The row count type</typeparam>
        /// <typeparam name="N">The col count type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static ref readonly BitGrid<M,N,T> negate<M,N,T>(in BitGrid<M,N,T> x, in BitGrid<M,N,T> gz)
            where T : unmanaged
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
        {
            var blocks = gz.BlockCount;
            for(var i=0; i<blocks; i++)
                gz[i] = gcpu.vnegate(x[i]);
            return ref gz;
        }

        /// <summary>
        /// Computes the two's complement negation of the source grid and returns the allocated result
        /// </summary>
        /// <param name="x">The source grid</param>
        /// <typeparam name="M">The row count type</typeparam>
        /// <typeparam name="N">The col count type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static BitGrid<M,N,T> negate<M,N,T>(in BitGrid<M,N,T> x)
            where T : unmanaged
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
                => negate(x, alloc<M,N,T>());
    }
}