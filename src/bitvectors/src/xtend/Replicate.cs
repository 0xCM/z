//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XBv
    {
        /// <summary>
        /// Creates a copy of the vector
        /// </summary>
        [MethodImpl(Inline)]
        public static BitVector8 Replicate(this BitVector8 src)
            => src.Data;

        /// <summary>
        /// Creates a copy of the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline)]
        public static BitVector4 Replicate(this BitVector4 src)
            => BitVectors.replicate(src);

        /// <summary>
        /// Concatenates a 4-bit vector with itself to produce a 8-bit vector
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline)]
        public static BitVector8 Replicate(this BitVector4 src, N2 n)
            => BitVectors.replicate(src,n);

        /// <summary>
        /// Concatenates an 8-bit vector with itself to produce a 16-bit vector
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="n">The duplication factor</param>
        [MethodImpl(Inline)]
        public static BitVector16 Replicate(this BitVector8 src, N2 n)
            => BitVectors.replicate(src,n);

        /// <summary>
        /// Concatenates four copies of an 8-bit vector to produce a 32-bit vector
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="n">The duplication factor</param>
        [MethodImpl(Inline)]
        public static BitVector32 Replicate(this BitVector8 src, N4 n)
            => BitVectors.replicate(src,n);

        /// <summary>
        /// Concatenates eight copies of an 8-bit vector to produce a 64-bit vector
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="n">The duplication factor</param>
        [MethodImpl(Inline)]
        public static BitVector64 Replicate(this BitVector8 src, N8 n)
            => BitVectors.replicate(src,n);

        /// <summary>
        /// Creates a copy of the vector
        /// </summary>
        [MethodImpl(Inline)]
        public static BitVector16 Replicate(this BitVector16 src)
            => BitVectors.replicate(src);

        /// <summary>
        /// Concatenates a 16-bit vector with itself to produce a 32-bit vector
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="n">The duplication factor</param>
        [MethodImpl(Inline)]
        public static BitVector32 Replicate(this BitVector16 src, N2 n)
            => BitVectors.replicate(src,n);

        /// <summary>
        /// Creates a 64-bit vector by concatenating 4 source replicants
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="n">The duplication factor</param>
        [MethodImpl(Inline)]
        public static BitVector64 Replicate(this BitVector16 src, N4 n)
            => BitVectors.replicate(src,n);

        /// <summary>
        /// Creates a copy of the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline)]
        public static BitVector32 Replicate(this BitVector32 src)
            => BitVectors.replicate(src);

        /// <summary>
        /// Creates a 64-bit vector by concatenating the source vector with a replicant
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline)]
        public static BitVector64 Replicate(this BitVector32 src, N2 n)
            => BitVectors.replicate(src,n);

        /// <summary>
        /// Creates a copy of the source vector
        /// </summary>
        [MethodImpl(Inline)]
        public static BitVector64 Replicate(this BitVector64 src)
            => BitVectors.replicate(src);
    }
}