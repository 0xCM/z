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

    partial struct CellCalcs
    {
        /// <summary>
        /// Computes the number of T-cells that comprise an N-block
        /// </summary>
        /// <param name="w">The block width representative</param>
        /// <param name="t">The cell type representative</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static int cells<W,T>()
            where W : unmanaged, IDataWidth
            where T : unmanaged
                => (int)((NatCalc.wdiv(default(W), default(N8)))/size<T>());

        /// <summary>
        /// Computes the minimum number of 8-bit blocks required to cover a specified number of cells
        /// </summary>
        /// <param name="cellcount">The number of cells to cover</param>
        /// <typeparam name="T">The element type</typeparam>
        /// <remarks>If a constant/literal value is supplied for the cellcount parameter, the jitter will
        /// resolve the computation to a constant an no runtime computations will occur</remarks>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ulong cellcover<T>(W8 w, ulong cellcount)
            where T : unmanaged
        {
            var blockcount = cellcount / (ulong)cells<T>(w);
            return cellcount % (ulong)cells<T>(w) == 0 ? blockcount : blockcount + 1;
        }

        /// <summary>
        /// Computes the minimum number of 32-bit blocks required to cover a specified number of cells
        /// </summary>
        /// <param name="cellcount">The number of cells to cover</param>
        /// <typeparam name="T">The element type</typeparam>
        /// <remarks>If a constant/literal value is supplied for the cellcount parameter, the jitter will
        /// resolve the computation to a constant an no runtime computations will occur</remarks>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ulong cellcover<T>(W16 w, ulong cellcount)
            where T : unmanaged
        {
            var blockcount = cellcount / (ulong)cells<T>(w);
            return cellcount % (ulong)cells<T>(w) == 0 ? blockcount : blockcount + 1;
        }

        /// <summary>
        /// Computes the minimum number of 32-bit blocks required to cover a specified number of cells
        /// </summary>
        /// <param name="cellcount">The number of cells to cover</param>
        /// <typeparam name="T">The element type</typeparam>
        /// <remarks>If a constant/literal value is supplied for the cellcount parameter, the jitter will
        /// resolve the computation to a constant an no runtime computations will occur</remarks>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ulong cellcover<T>(W32 w, ulong cellcount)
            where T : unmanaged
        {
            var blockcount = cellcount / (ulong)cells<T>(w);
            return cellcount % (ulong)cells<T>(w) == 0 ? blockcount : blockcount + 1ul;
        }

        /// <summary>
        /// Computes the minimum number of 64-bit blocks required to cover a specified number of cells
        /// </summary>
        /// <param name="cellcount">The number of cells to cover</param>
        /// <typeparam name="T">The element type</typeparam>
        /// <remarks>If a constant/literal value is supplied for the cellcount parameter, the jitter will
        /// resolve the computation to a constant an no runtime computations will occur</remarks>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ulong cellcover<T>(W64 w, ulong cellcount)
            where T : unmanaged
        {
            var blockcount = cellcount / (ulong)cells<T>(w);
            return cellcount % (ulong)cells<T>(w) == 0 ? blockcount : blockcount + 1;
        }

        /// <summary>
        /// Computes the minimum number of 128-bit blocks required to cover a specified number of cells
        /// </summary>
        /// <param name="cellcount">The number of cells to cover</param>
        /// <typeparam name="T">The element type</typeparam>
        /// <remarks>If a constant/literal value is supplied for the cellcount parameter, the jitter will
        /// resolve the computation to a constant an no runtime computations will occur</remarks>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ulong cellcover<T>(W128 w, ulong cellcount)
            where T : unmanaged
        {
            var blockcount = cellcount / (ulong)cells<T>(w);
            return cellcount % (ulong)cells<T>(w) == 0 ? blockcount : blockcount + 1;
        }

        /// <summary>
        /// Computes the minimum number of 256-bit blocks required to cover a specified number of cells
        /// </summary>
        /// <param name="cellcount">The number of cells to cover</param>
        /// <typeparam name="T">The element type</typeparam>
        /// <remarks>If a constant/literal value is supplied for the cellcount parameter, the jitter will
        /// resolve the computation to a constant an no runtime computations will occur</remarks>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ulong cellcover<T>(W256 w, ulong cellcount)
            where T : unmanaged
        {
            var blockcount = cellcount / (ulong)cells<T>(w);
            return cellcount % (ulong)cells<T>(w) == 0 ? blockcount : blockcount + 1;
        }

        /// <summary>
        /// Computes the minimum number of 512-bit blocks required to cover a specified number of cells
        /// </summary>
        /// <param name="cellcount">The number of cells to cover</param>
        /// <typeparam name="T">The element type</typeparam>
        /// <remarks>If a constant/literal value is supplied for the cellcount parameter, the jitter will
        /// resolve the computation to a constant an no runtime computations will occur</remarks>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ulong cellcover<T>(W512 w, ulong cellcount)
            where T : unmanaged
        {
            var blockcount = cellcount / (ulong)cells<T>(w);
            return cellcount % (ulong)cells<T>(w) == 0 ? blockcount : blockcount + 1;
        }

        /// <summary>
        /// Computes the minimum numbet of W-blocks over T-cells required to cover a grid of natural dimensions MxN
        /// </summary>
        /// <param name="w">The block width represntative</param>
        /// <param name="m">The col count representative</param>
        /// <param name="n">The row count representative</param>
        /// <param name="t">The cell type representative</param>
        /// <typeparam name="W">The block type</typeparam>
        /// <typeparam name="M">The row type</typeparam>
        /// <typeparam name="N">The col type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static int cellcover<W,M,N,T>(W w = default, M m = default, N n = default, T t = default)
            where W : unmanaged, IDataWidth
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
        {
            var cellblocks = cells<W,T>();
            var blockcount = cellblocks/Unsafe.SizeOf<T>();
            return blockcount + cellblocks % Unsafe.SizeOf<T>() == 0 ? 0 : 1;
        }
    }
}