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
    /// Captures statistics for memory blocks over generic T-cells
    /// </summary>
    /// <typeparam name="T">The cell type</typeparam>
    public readonly struct BLockedGridStats<T>
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
        public readonly int BitCount;

        [MethodImpl(Inline)]
        public BLockedGridStats(int bc, int bw)
        {
            var calcs = new BlockedGridStats(bc, bw, Unsafe.SizeOf<T>()*8);
            BlockCount = calcs.BlockCount;
            BlockWidth = calcs.BlockWidth;
            BlockLength = calcs.BlockLength;
            CellCount = calcs.CellCount;
            CellWidth = calcs.CellWidth;
            BitCount = CellCount * CellWidth;
        }
    }
}