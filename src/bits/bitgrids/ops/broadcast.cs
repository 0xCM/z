//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitGrid
    {
        /// <summary>
        /// Fills a caller-allocated generic grid
        /// </summary>
        /// <param name="cell">The data to replicate across all grid cells</param>
        /// <param name="dst">The target grid</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Broadcast, Closures(Closure)]
        public static BitSpanBlocks256<T> broadcast<T>(T cell, in BitSpanBlocks256<T> dst)
            where T : unmanaged
        {
            dst.Content.Fill(cell);
            return dst;
        }
    }
}