//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Captures memory block statistics
    /// </summary>
    public readonly struct BlockedGridStats
    {
        /// <summary>
        /// Calculates memory block statistics for specified parameters
        /// </summary>
        /// <param name="bc">The block count</param>
        /// <param name="bw">The block width</param>
        /// <param name="cw">The cell width</param>
        [MethodImpl(Inline), Op]
        public static BlockedGridStats metrics(int bc, int bw, int cw)
            => new BlockedGridStats(bc, bw, cw);

        /// <summary>
        /// Calculates memory block statistics for specified function and type parameters
        /// </summary>
        /// <param name="bc">The block count</param>
        /// <param name="bw">The block width</param>
        /// <typeparam name="T">The type that determines cell width</typeparam>
        [MethodImpl(Inline), Op, Closures(UnsignedInts)]
        public static BLockedGridStats<T> metrics<T>(int bc, int bw)
            where T : unmanaged
                => new BLockedGridStats<T>(bc, bw);

        /// <summary>
        /// The number of blocks being described
        /// </summary>
        public int BlockCount {get;}

        /// <summary>
        /// The bit-width of a block
        /// </summary>
        public int BlockWidth {get;}

        /// <summary>
        /// The bit-width of a cell
        /// </summary>
        public int CellWidth {get;}

        /// <summary>
        /// The number of cells in a block
        /// </summary>
        public int BlockLength {get;}

        /// <summary>
        /// The total number of covered cells
        /// </summary>
        public int CellCount {get;}

        /// <summary>
        /// The total number of covered bits
        /// </summary>
        public readonly int BitCount
            => CellCount * CellWidth;

        [MethodImpl(Inline)]
        public BlockedGridStats(int blocks, int blockwidth, int cellwidth)
        {
            BlockCount = blocks;
            BlockWidth = blockwidth;
            CellWidth = cellwidth;
            BlockLength = BlockWidth / CellWidth;
            CellCount = (BlockWidth * BlockCount)/CellWidth;
        }
    }
}