//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XBv
    {
        /// <summary>
        /// Applies a permutation to a copy of the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="p">The permutation</param>
        /// <typeparam name="T">The storage cell type</typeparam>
        [MethodImpl(Inline)]
        public static ScalarBits<T> Permute<T>(this ScalarBits<T> src, in Perm p)
            where T : unmanaged
                => BitVectors.perm(src,p);

        /// <summary>
        /// Applies a permutation to a copy of the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="p">The permutation</param>
        [MethodImpl(Inline)]
        public static ScalarBits<N,T> Permute<N,T>(this ScalarBits<N,T> src, in Perm p)
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => BitVectors.perm(src,p);

        /// <summary>
        /// Applies a permutation to copy of the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="p">The permutation</param>
        [MethodImpl(Inline)]
        public static BitVector4 Permute(this BitVector4 src, in Perm p)
            => BitVectors.perm(src,p);

        /// <summary>
        /// Applies a permutation to copy of the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="p">The permutation</param>
        [MethodImpl(Inline)]
        public static BitVector8 Permute(this BitVector8 src, in Perm p)
            => BitVectors.perm(src,p);

        /// <summary>
        /// Applies a permutation to copy of the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="p">The permutation</param>
        [MethodImpl(Inline)]
        public static BitVector16 Permute(this BitVector16 src, in Perm p)
            => BitVectors.perm(src,p);

        /// <summary>
        /// Applies a permutation to copy of the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="p">The permutation</param>
        [MethodImpl(Inline)]
        public static BitVector32 Permute(this BitVector32 src, in Perm p)
            => BitVectors.perm(src,p);

        /// <summary>
        /// Applies a permutation to a replicated vector
        /// </summary>
        /// <param name="p">The permutation</param>
        [MethodImpl(Inline)]
        public static BitVector64 Permute(this BitVector64 src, in Perm p)
            => BitVectors.perm(src,p);
    }
}