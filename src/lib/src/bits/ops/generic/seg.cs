//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class gbits
    {
        /// <summary>
        /// Extracts a T-valued segment, cross-cell or same-cell, from the source as determined by an inclusive position range
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="i0">The sequence-relative position of the first bit</param>
        /// <param name="i1">The sequence-relative position of the last bit</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), BitSeg, Closures(Closure)]
        public static T seg<T>(in Span<T> src, BitPos<T> i0, BitPos<T> i1)
            where T : unmanaged
                => extract(src, i0, i1);

        /// <summary>
        /// Extracts a T-valued segment, cross-cell or same-cell, from the source as determined by an inclusive linear index range
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="i0">The sequence-relative index of the first bit</param>
        /// <param name="i1">The sequence-relative index of the last bit</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), BitSeg, Closures(Closure)]
        public static T seg<T>(in Span<T> src, uint i0, uint i1)
            where T : unmanaged
                => extract(src, BitPos.bitpos<T>((uint)i0), BitPos.bitpos<T>((uint)i1));

        /// <summary>
        /// Extracts a contiguous range of bits from a primal source inclusively between two index positions
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="i0">The first position</param>
        /// <param name="i1">The last position</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline), BitSeg, Closures(AllNumeric)]
        public static T seg<T>(T src, byte i0, byte i1)
            where T : unmanaged
                => extract(src, i0, i1);
    }
}