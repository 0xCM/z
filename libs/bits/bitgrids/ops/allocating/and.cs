//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;
    using static BitGrid;

    partial class BitGridA
    {
        [MethodImpl(Inline), Ones, Closures(UnsignedInts)]
        public static BitSpanBlocks256<T> ones<T>(int rows, int cols, T zero = default)
            where T : unmanaged
        {
            var dst = alloc<T>(rows,cols);
            BitGrid.ones(dst);
            return dst;
        }

        /// <summary>
        /// Computes the two's complement negation of source grid and returns the allocated result
        /// </summary>
        /// <param name="x">The source grid</param>
        /// <param name="gz">The target grid</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Negate, Closures(UnsignedInts)]
        public static BitSpanBlocks256<T> negate<T>(in BitSpanBlocks256<T> x)
            where T : unmanaged
                => BitGrid.negate(x, alloc<T>(x.RowCount, x.ColCount));

        /// <summary>
        /// Computes the bitwise xor between unfixed generic bitgrids and returns the allocated result
        /// </summary>
        /// <param name="gx">The left grid</param>
        /// <param name="gy">The right grid</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Xor, Closures(UnsignedInts)]
        public static BitSpanBlocks256<T> xor<T>(in BitSpanBlocks256<T> gx, in BitSpanBlocks256<T> gy)
            where T : unmanaged
        {
            var gz = alloc<T>(gx.RowCount, gx.ColCount);
            BitGrid.xor(gx,gy,gz);
            return gz;
        }

        /// <summary>
        /// Computes the bitwise XNOR between generic bitgrids and returns the allocated result
        /// </summary>
        /// <param name="gx">The left grid</param>
        /// <param name="gy">The right grid</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Xnor, Closures(UnsignedInts)]
        public static BitSpanBlocks256<T> xnor<T>(in BitSpanBlocks256<T> gx, in BitSpanBlocks256<T> gy)
            where T : unmanaged
        {
            var gz = alloc<T>(gx.RowCount, gx.ColCount);
            BitGrid.xnor(gx,gy,gz);
            return gz;
        }

        /// <summary>
        /// Computes the bitwise OR between generic bitgrids and returns the allocated result
        /// </summary>
        /// <param name="gx">The left grid</param>
        /// <param name="gy">The right grid</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Or, Closures(UnsignedInts)]
        public static BitSpanBlocks256<T> or<T>(in BitSpanBlocks256<T> gx, in BitSpanBlocks256<T> gy)
            where T : unmanaged
        {
            var gz = alloc<T>(gx.RowCount, gx.ColCount);
            BitGrid.or(gx,gy,gz);
            return gz;
        }

        /// <summary>
        /// Computes the bitwise NOR between generic bitgrids and returns the allocated result
        /// </summary>
        /// <param name="gx">The left grid</param>
        /// <param name="gy">The right grid</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Nor, Closures(UnsignedInts)]
        public static BitSpanBlocks256<T> nor<T>(in BitSpanBlocks256<T> gx, in BitSpanBlocks256<T> gy)
            where T : unmanaged
        {
            var gz = alloc<T>(gx.RowCount, gx.ColCount);
            BitGrid.nor(gx,gy,gz);
            return gz;
        }

        /// <summary>
        /// Computes the bitwise AND between generic bitgrids and returns the allocated result
        /// </summary>
        /// <param name="a">The left grid</param>
        /// <param name="b">The right grid</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), And, Closures(UnsignedInts)]
        public static BitSpanBlocks256<T> and<T>(in BitSpanBlocks256<T> a, in BitSpanBlocks256<T> b)
            where T : unmanaged
        {
            var gz = alloc<T>(a.RowCount, a.ColCount);
            BitGrid.and(a,b,gz);
            return gz;
        }

        /// <summary>
        /// Computes the bitwise AND between generic bitgrids and returns the allocated result
        /// </summary>
        /// <param name="a">The left grid</param>
        /// <param name="b">The right grid</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static BitGrid<M,N,T> and<M,N,T>(in BitGrid<M,N,T> a, in BitGrid<M,N,T> b)
            where T : unmanaged
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
        {
            var dst = alloc<M,N,T>();
            BitGrid.and(a,b,dst);
            return dst;
        }

        /// <summary>
        /// Computes the bitwise NAND between generic bitgrids and returns the allocated result
        /// </summary>
        /// <param name="a">The left grid</param>
        /// <param name="b">The right grid</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(UnsignedInts)]
        public static BitSpanBlocks256<T> nand<T>(in BitSpanBlocks256<T> a, in BitSpanBlocks256<T> b)
            where T : unmanaged
        {
            var dst = BitGrid.alloc<T>(a.RowCount, a.ColCount);
            BitGrid.nand(a,b,dst);
            return dst;
        }
    }
}