//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitVectors
    {
        /// <summary>
        /// Computes z := x >> s for a bitvector x and shift offset s
        /// </summary>
        /// <param name="x">The source bitvector</param>
        /// <param name="offset">The shift amount</param>
        [MethodImpl(Inline), Sll, Closures(Closure)]
        public static BitVector128<T> sll<T>(in BitVector128<T> x, byte offset)
            where T : unmanaged
                => vgcpu.vsllx(x.State,offset);

        /// <summary>
        /// Computes z := x >> s for a bitvector x and shift offset s
        /// </summary>
        /// <param name="x">The source bitvector</param>
        /// <param name="offset">The shift amount</param>
        [MethodImpl(Inline), Sll, Closures(Closure)]
        public static BitVector256<T> sll<T>(in BitVector256<T> x, byte offset)
            where T : unmanaged
                => vgcpu.vsllx(x.State,offset);
    }
}