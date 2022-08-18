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
        [MethodImpl(Inline), Srl, Closures(Closure)]
        public static ScalarBits<T> srl<T>(ScalarBits<T> x, byte offset)
            where T : unmanaged
                => gmath.srl(x.State,offset);

        /// <summary>
        /// Computes z := x >> s for a bitvector x and shift offset s
        /// </summary>
        /// <param name="x">The source bitvector</param>
        /// <param name="offset">The shift amount</param>
        [MethodImpl(Inline)]
        public static ScalarBits<N,T> srl<N,T>(ScalarBits<N,T> x, byte offset)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => gmath.srl(x.State, offset);

        /// <summary>
        /// Computes z := x >> s for a bitvector x and shift offset s
        /// </summary>
        /// <param name="x">The source bitvector</param>
        /// <param name="offset">The shift amount</param>
        [MethodImpl(Inline)]
        public static BitVector128<T> srl<T>(in BitVector128<T> x, byte offset)
            where T : unmanaged
                => gcpu.vsrlx(x.State, offset);

        /// <summary>
        /// Computes z := x >> s for a bitvector x and shift offset s
        /// </summary>
        /// <param name="x">The source bitvector</param>
        /// <param name="offset">The shift amount</param>
        [MethodImpl(Inline)]
        public static BitVector256<T> srl<T>(in BitVector256<T> x, byte offset)
            where T : unmanaged
                => gcpu.vsrlx(x.State, offset);
    }
}