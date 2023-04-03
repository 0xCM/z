//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static CellCalcs;

    partial class XSb
    {
        /// <summary>
        /// Extracts the upper half of an index-identified block
        /// </summary>
        /// <param name="src">The source block container</param>
        /// <param name="block">The 64-bit block-relative index</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> HiBlock<T>(this SpanBlock128<T> src, int block)
            where T : unmanaged
                => src.Slice(block * src.BlockLength + blocklength<T>(w64), blocklength<T>(w64));
    }
}