//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitVectors
    {
        /// <summary>
        /// Creates a copy of the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Replicate]
        public static BitVector4 replicate(BitVector4 src)
            => new BitVector4(n4, src.State);

        /// <summary>
        /// Creates an 8-bit vector by concatenating the source vector with a replicant
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Replicate]
        public static BitVector8 replicate(BitVector4 src, N2 n)
            => join(src,src);

        /// <summary>
        /// Creates a copy of the source vector
        /// </summary>
        /// <param name="x">The source vector</param>
        [MethodImpl(Inline), Replicate]
        public static BitVector8 replicate(BitVector8 src)
            => src;

        /// <summary>
        /// Creates a 16-bit vector by concatenating the source vector with a replicant
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="n">The duplication factor</param>
        [MethodImpl(Inline), Replicate]
        public static BitVector16 replicate(BitVector8 src, N2 n)
            => join(src,src);

        /// <summary>
        /// Creates a 32-bit vector by concatenating 4 source replicants
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="n">The duplication factor</param>
        [MethodImpl(Inline), Replicate]
        public static BitVector32 replicate(BitVector8 src, N4 n)
            => join(src,src,src,src);

        /// <summary>
        /// Creates a 64-bit vector by concatenating 8 source replicants
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="n">The duplication factor</param>
        [MethodImpl(Inline), Replicate]
        public static BitVector64 replicate(BitVector8 src, N8 n)
            => join(replicate(src,n4),replicate(src,n4));

        /// <summary>
        /// Creates a copy of the source vector
        /// </summary>
        /// <param name="x">The source vector</param>
        [MethodImpl(Inline), Replicate]
        public static BitVector16 replicate(BitVector16 src)
            => src;

        /// <summary>
        /// Creates a 32-bit vector by concatenating the source vector with a replicant
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="n">The duplication factor</param>
        [MethodImpl(Inline), Replicate]
        public static BitVector32 replicate(BitVector16 src, N2 n)
            => join(src,src);

        /// <summary>
        /// Creates a 64-bit vector by concatenating 4 source replicants
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="n">The duplication factor</param>
        [MethodImpl(Inline), Replicate]
        public static BitVector64 replicate(BitVector16 src, N4 n)
            => join(replicate(src,n2), replicate(src,n2));

        /// <summary>
        /// Creates a copy of the source vector
        /// </summary>
        /// <param name="x">The source vector</param>
        [MethodImpl(Inline), Replicate]
        public static BitVector32 replicate(BitVector32 src)
            => src;

        /// <summary>
        /// Creates a 64-bit vector by concatenating the source vector with a replicant
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="n">The duplication factor</param>
        [MethodImpl(Inline), Replicate]
        public static BitVector64 replicate(BitVector32 src, N2 n)
            => join(src,src);

        /// <summary>
        /// Creates a copy of the source vector
        /// </summary>
        /// <param name="x">The source vector</param>
        [MethodImpl(Inline), Replicate]
        public static BitVector64 replicate(BitVector64 src)
            => src;
    }
}