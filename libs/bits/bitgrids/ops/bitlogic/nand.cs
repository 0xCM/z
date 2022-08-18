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
        /// Computes the bitwise nand between generic bitgrids
        /// </summary>
        /// <param name="x">The left grid</param>
        /// <param name="y">The right grid</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Nand, Closures(UInt8x16k)]
        public static BitGrid16<T> nand<T>(BitGrid16<T> x, BitGrid16<T> y)
            where T : unmanaged
                => init16<T>(math.nand(x,y));

        /// <summary>
        /// Computes the bitwise nand between generic bitgrids
        /// </summary>
        /// <param name="x">The left grid</param>
        /// <param name="y">The right grid</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Nand, Closures(UInt8x16x32k)]
        public static BitGrid32<T> nand<T>(BitGrid32<T> x, BitGrid32<T> y)
            where T : unmanaged
                => init32<T>(math.nand(x,y));

        /// <summary>
        /// Computes the bitwise nand between generic bitgrids
        /// </summary>
        /// <param name="x">The left grid</param>
        /// <param name="y">The right grid</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Nand, Closures(UnsignedInts)]
        public static BitGrid64<T> nand<T>(BitGrid64<T> x, BitGrid64<T> y)
            where T : unmanaged
                => init64<T>(math.nand(x,y));

        /// <summary>
        /// Computes the bitwise NAND between generic bitgrids and stores the result to a caller-supplied target
        /// </summary>
        /// <param name="x">The left grid</param>
        /// <param name="y">The right grid</param>
        /// <param name="gz">The target grid</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Nand, Closures(UnsignedInts)]
        public static ref readonly BitSpanBlocks256<T> nand<T>(in BitSpanBlocks256<T> x, in BitSpanBlocks256<T> y, in BitSpanBlocks256<T> gz)
            where T : unmanaged
        {
            var blocks = gz.BlockCount;
            for(var i=0; i<blocks; i++)
                gz[i] = gcpu.vnand(x[i],y[i]);
            return ref gz;
        }

        /// <summary>
        /// Computes the bitwise nand between natural bitgrids
        /// </summary>
        /// <param name="x">The left grid</param>
        /// <param name="y">The right grid</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static BitGrid16<M,N,T> nand<M,N,T>(BitGrid16<M,N,T> x, BitGrid16<M,N,T> y)
            where T : unmanaged
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
                => math.nand(x,y);

        /// <summary>
        /// Computes the bitwise nand between natural bitgrids
        /// </summary>
        /// <param name="x">The left grid</param>
        /// <param name="y">The right grid</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static BitGrid32<M,N,T> nand<M,N,T>(BitGrid32<M,N,T> x, BitGrid32<M,N,T> y)
            where T : unmanaged
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
                => math.nand(x,y);

        /// <summary>
        /// Computes the bitwise nand between natural bitgrids
        /// </summary>
        /// <param name="x">The left grid</param>
        /// <param name="y">The right grid</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static BitGrid64<M,N,T> nand<M,N,T>(BitGrid64<M,N,T> x, BitGrid64<M,N,T> y)
            where T : unmanaged
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
                => math.nand(x,y);

        /// <summary>
        /// Computes the bitwise nand between natural bitgrids
        /// </summary>
        /// <param name="x">The left grid</param>
        /// <param name="y">The right grid</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static BitGrid128<M,N,T> nand<M,N,T>(in BitGrid128<M,N,T> x, in BitGrid128<M,N,T> y)
            where T : unmanaged
            where N : unmanaged, ITypeNat
            where M : unmanaged, ITypeNat
                => gcpu.vnand<T>(x,y);

        /// <summary>
        /// Computes the bitwise nand between natural bitgrids
        /// </summary>
        /// <param name="x">The left grid</param>
        /// <param name="y">The right grid</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static BitGrid256<M,N,T> nand<M,N,T>(in BitGrid256<M,N,T> x, in BitGrid256<M,N,T> y)
            where T : unmanaged
            where N : unmanaged, ITypeNat
            where M : unmanaged, ITypeNat
                => gcpu.vnand<T>(x,y);

        /// <summary>
        /// Computes the bitwise NAND between natural bitgrids and stores the result to a caller-supplied target
        /// </summary>
        /// <param name="x">The left grid</param>
        /// <param name="y">The right grid</param>
        /// <param name="gz">The target grid</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static ref readonly BitGrid<M,N,T> nand<M,N,T>(in BitGrid<M,N,T> x, in BitGrid<M,N,T> y, in BitGrid<M,N,T> gz)
            where T : unmanaged
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
        {
            var blocks = (int)CellCalcs.blockcount<M,N,T>(W256.W);
            for(var i=0; i<blocks; i++)
                gz[i] = gcpu.vnand(x[i],y[i]);
            return ref gz;
        }

        /// <summary>
        /// Computes the bitwise NAND between generic bitgrids and returns the allocated result
        /// </summary>
        /// <param name="x">The left grid</param>
        /// <param name="y">The right grid</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static BitGrid<M,N,T> nand<M,N,T>(in BitGrid<M,N,T> x, in BitGrid<M,N,T> y)
            where T : unmanaged
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
        {
            var gz = alloc<M,N,T>();
            nand(x,y,gz);
            return gz;
        }
    }
}