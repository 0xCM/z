//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Captures memory block statistics for blocks of natural width N over generic T-cells
    /// </summary>
    /// <typeparam name="T">The cell type</typeparam>
    public readonly struct BlockedGridStats<W,T>
        where W : unmanaged, ITypeWidth
        where T : unmanaged
    {
        /// <summary>
        /// The number of blocks being described
        /// </summary>
        public readonly int BlockCount;

        /// <summary>
        /// The bit-width of a block
        /// </summary>
        public readonly int BlockWidth;

        /// <summary>
        /// The bit-width of a cell
        /// </summary>
        public readonly int CellWidth;

        /// <summary>
        /// The number of cells in a block
        /// </summary>
        public readonly int BlockLength;

        /// <summary>
        /// The total number of covered cells
        /// </summary>
        public readonly int CellCount;

        /// <summary>
        /// The total number of covered bits
        /// </summary>
        public readonly int BitCount
            => CellCount * CellWidth;

        [MethodImpl(Inline)]
        public BlockedGridStats(int blocks)
        {
            BlockCount = blocks;
            BlockWidth = (int)Widths.type<W>();
            CellWidth = Unsafe.SizeOf<T>()*8;
            var calcs = new BlockedGridStats(BlockCount, BlockWidth, CellWidth);
            BlockLength = calcs.BlockLength;
            CellCount = calcs.CellCount;
        }
    }
}