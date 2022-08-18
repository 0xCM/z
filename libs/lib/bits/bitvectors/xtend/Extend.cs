//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    partial class XBv
    {
        /// <summary>
        /// Zero extends the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="n">The target width</param>
        [MethodImpl(Inline)]
        public static BitVector8 Extend(this BitVector4 src, N8 n)
            => BitVectors.extend(src,n);

        /// <summary>
        /// Zero extends the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="n">The target width</param>
        [MethodImpl(Inline)]
        public static BitVector16 Extend(this BitVector8 src, N16 n)
            => BitVectors.extend(src,n);

        /// <summary>
        /// Zero extends the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="n">The target width</param>
        [MethodImpl(Inline)]
        public static BitVector32 Extend(this BitVector16 src, N32 n)
            => BitVectors.extend(src,n);

        /// <summary>
        /// Zero extends the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="n">The target width</param>
        [MethodImpl(Inline)]
        public static BitVector64 Extend(this BitVector32 src, N64 n)
            => BitVectors.extend(src,n);
    }
}