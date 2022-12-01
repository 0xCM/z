//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static CalcHosts;
    using static SFx;
    using static ApiClassKind;

    partial struct Calcs
    {
        [MethodImpl(Inline), Factory(BitSeg), Closures(Closure)]
        public static BitSeg<T> bitseg<T>()
            where T : unmanaged
                => sfunc<BitSeg<T>>();

        /// <summary>
        /// Extracts a T-valued segment, cross-cell or same-cell, from the source as determined by an inclusive position range
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="i0">The sequence-relative position of the first bit</param>
        /// <param name="i1">The sequence-relative position of the last bit</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), BitSeg, Closures(Closure)]
        public static T bitseg<T>(in SpanBlock256<T> src, BitPos<T> i0, BitPos<T> i1)
            where T : unmanaged
                => gbits.extract(src.Storage, i0, i1);

        /// <summary>
        /// Extracts a T-valued segment, cross-cell or same-cell, from the source as determined by an inclusive linear index range
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="i0">The sequence-relative index of the first bit</param>
        /// <param name="i1">The sequence-relative index of the last bit</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), BitSeg, Closures(Closure)]
        public static T bitseg<T>(in SpanBlock256<T> src, int i0, int i1)
            where T : unmanaged
                => gbits.extract(src.Storage, BitPos.bitpos<T>((uint)i0), BitPos.bitpos<T>((uint)i1));
    }
}