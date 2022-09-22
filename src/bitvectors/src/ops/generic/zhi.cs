//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitVectors
    {
        /// <summary>
        /// Disables the high bits starting at a specified position
        /// </summary>
        /// <param name="pos">The bit position</param>
        [MethodImpl(Inline), MsbOff, Closures(Closure)]
        public static ScalarBits<T> zhi<T>(ScalarBits<T> src, byte pos)
            where T : unmanaged
                => gbits.zhi(src.State, pos);

        /// <summary>
        /// Disables the high bits starting at a specified position
        /// </summary>
        /// <param name="pos">The bit position</param>
        [MethodImpl(Inline)]
        public static ScalarBits<N,T> zhi<N,T>(ScalarBits<N,T> src, byte pos)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => gbits.zhi(src.State, pos);

        /// <summary>
        /// Computes z := x >> s for a bitvector x and shift offset s
        /// </summary>
        /// <param name="x">The source bitvector</param>
        /// <param name="s">The shift amount</param>
        [MethodImpl(Inline)]
        public static BitVector128<T> zhi<T>(in BitVector128<T> x)
            where T : unmanaged
                => gcpu.vzhi(x.State);
    }
}