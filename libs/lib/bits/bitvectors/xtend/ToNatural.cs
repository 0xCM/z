//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XBv
    {
        /// <summary>
        /// Converts the source bitvector to an equivalent natural bitvector
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline)]
        public static ScalarBits<N4,byte> ToNatural(this BitVector4 src)
            => BitVectors.inject(src.Data,n4);

        /// <summary>
        /// Converts the source bitvector to an equivalent natural bitvector
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline)]
        public static ScalarBits<N8,byte> ToNatural(this BitVector8 src)
            => BitVectors.inject(src.Data,n8);

        /// <summary>
        /// Converts the source bitvector to an equivalent natural/generic bitvector
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline)]
        public static ScalarBits<N32,uint> ToNatural(this BitVector32 src)
            => BitVectors.inject(src.Data,n32);

        /// <summary>
        /// Converts the source bitvector to an equivalent natural/generic bitvector
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline)]
        public static ScalarBits<N64,ulong> ToNatural(this BitVector64 src)
            => BitVectors.inject(src.Data,n64);

        /// <summary>
        /// Converts a generic bitvector to natural bitvector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="N">The natural type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static ScalarBits<N,T> ToNatural<N,T>(this ScalarBits<T> src, N n = default)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => BitVectors.natural<N,T>(src.State);
    }
}